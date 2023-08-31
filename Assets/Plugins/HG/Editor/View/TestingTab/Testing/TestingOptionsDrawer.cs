using System;
using HG.Button;
using HG.Dropdown;
using HG.ManifestManipulator;
using HG.Window;
using UnityEditor;
using UnityEngine;

namespace HG.Testing
{
    public class TestingOptionsDrawer : VerticalSequenceDrawer
    {
        private TestingSettings _settings;
        private readonly ISkipPermissionsDialogManipulator _skipDialogManipulator;

        private DisabledDrawer _disalableSettingsDrawer;
        
        public TestingOptionsDrawer(TestingSettings settings, ISkipPermissionsDialogManipulator skipDialogManipulator)
        {
            _settings = settings;
            _skipDialogManipulator = skipDialogManipulator;

            AddDrawer(new Toggle("In-Editor Testing Enabled", 
                 settings.TestingEnabled, 
                OnTestingEnabledToggleChanged));


            var settingsDrawer = new VerticalSequenceDrawer();
            
            var testAndroid6Plus = new TextField.TextField("Test Api Level", _settings.TestingApiLevel.ToString(), OnTestAndroid6PlusValueChanged);
            
            settingsDrawer.AddDrawer(testAndroid6Plus);
            settingsDrawer.AddDrawer(new ConditionalDrawer(
                                        new Clickable(
                                            new HelpBox.HelpBox("Testing for api level 23 and higher is not availible while Unity’s default behaviour of Auto-requesting permissions at application start is enabled. You can disable it in this plugin in 'General->Settings->Auto-Request' or by clicking on this message",
                                            MessageType.Warning),
                                        OnTestingDisabledClicked),
                                    ShowTestingDisabledWarning));
            settingsDrawer.AddDrawer(new Space(15));
            settingsDrawer.AddDrawer(new Label.Label("Permissions State").SetBold(true));
            settingsDrawer.AddDrawer(new Toggle("Store persistently*", 
                _settings.TestingStorePersistently, 
                OnStorePersistentlyToggleChanged).SetTooltip("If disabled the state will be reset each time you enter/exit playmode\n(This only effects in-editor testing)"));
            settingsDrawer.AddDrawer(new Space(6));
            settingsDrawer.AddDrawer(new Button.Button("Reset test permissions state", OnResetPermissionsStatePressed));
            settingsDrawer.AddDrawer(new Button.Button("Edit test permissions state", OnEditPermissionsStatePressed));
            
            _disalableSettingsDrawer = new DisabledDrawer(settingsDrawer).SetEnabled(!settings.TestingEnabled);
            AddDrawer(_disalableSettingsDrawer);
        }

        private void OnTestingDisabledClicked()
        {
            _skipDialogManipulator.AddSkipPermissionDialog();
        }

        private bool ShowTestingDisabledWarning()
        {
            if (!_settings.TestingEnabled) return false;
            if (_settings.TestingApiLevel < 23) return false;

            if (_skipDialogManipulator.IsPermissionDialogsSkipped()) return false;
            return true;
        }

        private void OnStorePersistentlyToggleChanged(bool isChecked)
        {
            _settings.TestingStorePersistently = isChecked;  
        }

        private void OnEditPermissionsStatePressed()
        {
            AssetHelper.SelectAssetByType<PermissionsStateScriptable>();
        }

        private void OnResetPermissionsStatePressed()
        {
            DisplayDialog.Create("Clear All States", "Are you sure you want to delete all states?", "OK", () =>
            {
                SettingsHolder.Instance.PermissionsState.Clear();
            }, "Cancel");      
        }

        private void OnTestAndroid6PlusValueChanged(string text)
        {
            int apiLevel;

            if (int.TryParse(text, out apiLevel))
            {
                _settings.TestingApiLevel = apiLevel;
            }
            else
            {
                HGLogger.LogError("api level should be a number");
            }
        }

        private void OnTestingEnabledToggleChanged(bool isChecked)
        {
            _settings.TestingEnabled = isChecked;
            _disalableSettingsDrawer.SetEnabled(!isChecked);
        }
    }
}