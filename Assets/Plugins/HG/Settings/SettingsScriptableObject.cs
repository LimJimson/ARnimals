using Plugins.HG.General.Utils;

using UnityEngine;

namespace HG
{
	public class SettingsScriptableObject : ScriptableObject
	{
		public Settings setttings = new Settings();

		public void Save()
		{
			ScriptableHelper.Save(this);
		}
	}
}