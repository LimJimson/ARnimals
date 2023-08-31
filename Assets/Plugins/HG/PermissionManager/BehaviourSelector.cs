using Assets.Plugins.HG.General;
using HG;
using Plugins.HG.PermissionManager;

namespace Assets.Plugins.HG.PermissionManager
{
    public class BehaviourSelector : Singleton<BehaviourSelector>
    {
        private const int ANDROID_6_API_LEVEL = 23;
        private IPermissionManagerBehaviour _currentBehaviour;
        public static IPermissionManagerBehaviour CurrentBehaviour
        {
            get { return Instance._currentBehaviour; }
        }
        
        public BehaviourSelector()
        {           
            SwitchBehaviour();
            // Avoid calls to SettingsHolder here, to avoid its creation on Android
        }

        public void Reset()
        {
            _instance = null;
        }

        // disable as it used but not on all platforms
        #pragma warning disable 0414
        private IPermissionsManipulator _permissionsManipulator;
        private ISkipPermissionsDialogManipulator _skipManipulator;
        private bool _manipulatorsSet;
#pragma warning restore 0414
        
        // @Later Find a better way to allow specific behaviours to actually get permissions info
        public void SetManipulators(IPermissionsManipulator permissionsManipulator, ISkipPermissionsDialogManipulator skipManipulator)
        {
            _permissionsManipulator = permissionsManipulator;

            if (_skipManipulator != null) _skipManipulator.OnRefreshRequired -= SwitchBehaviourAndLog;
            _skipManipulator = skipManipulator;
            _skipManipulator.OnRefreshRequired += SwitchBehaviourAndLog;

            SetupExternalListeners();
            _manipulatorsSet = true;
                        
            SwitchBehaviour(); // recreate behaviour with set manipulator
        }

        private void SetupExternalListeners()
        {
            SettingsHolder.Instance.TestingSettings.OnTestingEnabledChanged -= SwitchBehaviourAndLog;
            SettingsHolder.Instance.TestingSettings.OnTestingApiLevelChanged -= SwitchBehaviourAndLog;
            SettingsHolder.Instance.TestingSettings.OnTestingEnabledChanged += SwitchBehaviourAndLog;
            SettingsHolder.Instance.TestingSettings.OnTestingApiLevelChanged += SwitchBehaviourAndLog; 
        }

        private bool SwitchBehaviour()
        {
            var newBehaviour = GetBehaviour();

            if (_currentBehaviour == null || _currentBehaviour.GetType() != newBehaviour.GetType())
            {
                _currentBehaviour = newBehaviour;
                return true;
            }

            return false;
        }

        private void SwitchBehaviourAndLog()
        {
            if (SwitchBehaviour())
            {
                HGLogger.LogInfo("Switched to Behaviour: " + _currentBehaviour.GetType().Name);
            }
        }

        // Note: we try to avoid SettingsHolder.Instance calls to not create it if testing is diabled
        private IPermissionManagerBehaviour GetBehaviour()
        {
            #if UNITY_ANDROID && !UNITY_EDITOR
                return new AndroidBehaviour();
            #elif !UNITY_EDITOR
                return new NullBehaviour();
            #else

            if(!_manipulatorsSet) return new NullBehaviour();
            
            var settings = SettingsHolder.Instance.TestingSettings;
            if (!SettingsHolder.Instance.TestingSettings.TestingEnabled)
            {
                return new NullBehaviour();
            }
            
            if (settings.TestingApiLevel >= ANDROID_6_API_LEVEL && _skipManipulator.IsPermissionDialogsSkipped())
            {
                return new AndroidSixBehaviour(_permissionsManipulator, new UnityPermissionsDialogFactory(), SettingsHolder.Instance.PermissionsState, SettingsHolder.Instance.GetDataHolder().Permissions);
            }
            else
            {
                return new PreAndroidSixBehaviour(_permissionsManipulator);
            }
            
            #endif
        }
    }
}