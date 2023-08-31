using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.HG.General;
using Plugins.HG.General.Utils;
using UnityEngine;

namespace HG
{
	public class SettingsHolder : Singleton<SettingsHolder>
	{
		// @LATER what if ManifestSettings or PermissionsState change via git pull?
		private const string SettingsFilename = "ManifestSettings";
		private const string PermissionsStateFilename = "PermissionsState";

		private SettingsScriptableObject loadedSettings;

		private Settings _settings; // Stores all the settings
		private TestingSettings _testingSettings; // just a wrapper for Settings that privides convinient methods
		public TestingSettings TestingSettings {
			get { return _testingSettings; }
		}

		private PermissionsStateScriptable permissionsState;
		private PermissionsState _permissionsState;
		public PermissionsState PermissionsState {
			get { return _permissionsState; }
		}

		private DataHolder _dataHolder;

		public SettingsHolder()
		{
			loadedSettings = ScriptableHelper.Load<SettingsScriptableObject>(SettingsFilename, "Assets/Plugins/HG/Settings/Resources");
			
			Debug.Assert(loadedSettings != null, "Failed to load the " + SettingsFilename);
			_settings = loadedSettings.setttings;
			_testingSettings = new TestingSettings(_settings);
			
			_settings.OnDictionaryChanged += () => loadedSettings.Save();

			permissionsState = ScriptableHelper.Load<PermissionsStateScriptable>(PermissionsStateFilename, "Assets/Plugins/HG/Settings/Resources");
			permissionsState.Init(GetDataHolder().Permissions);
			
			Debug.Assert(permissionsState != null, "Failed to load the " + PermissionsStateFilename);
			_permissionsState = permissionsState.PermissionsState;
			
			_permissionsState.OnDictionaryChanged += () => permissionsState.Save();
		}
		
		public DataHolder GetDataHolder()
		{
			if (_dataHolder == null)
			{
				_dataHolder = DataHolderFactory.CreateData();
			}

			return _dataHolder;
		}

		public void Reset()
		{
			_testingSettings.Dispose();
			_settings.Dispose();
			_permissionsState.Dispose();
			_instance = null;
		}
	}
}

