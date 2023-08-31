using System.Linq;
using HG.Autocomplete;
using HG.Button;
using HG.Extensions;
using HG.ManifestManipulator;
using UnityEngine;

namespace HG
{
    public class PermissionAdderDrawer : VerticalSequenceDrawer
    {
        private TimedDrawer _permissionAddSuccessDrawer;

        private readonly IPermissionsManipulator _permissionsManipulator;
        private DataHolder _data;
        private AutocompletedTextField _textField;

        public PermissionAdderDrawer(IPermissionsManipulator permissionsManipulator, DataHolder data)
        {
            _permissionsManipulator = permissionsManipulator;
            _data = data;
            _permissionAddSuccessDrawer = new TimedDrawer(new Label.Label("Permission successfuly added"));

            _textField = new AutocompletedTextField(
                _data.Permissions.GetAllPermissions().Select(s => s.FullName).ToList(), maxShownCount: 4,
                levenshteinDistance: 0.7f);
            _textField.OnOptionClicked += AddPermission;
            
            SetupSequence();
        }

        private void SetupSequence()
        {
            AddDrawer(new HorizontalSequenceDrawer(
                _textField,
                new Space(15),
                new ButtonWithData<AutocompletedTextField>("Add", OnAddPermissionPressed, _textField).SetWidth(100))); 
            AddDrawer(_permissionAddSuccessDrawer);
        }

        private void AddPermission(string text)
        {
            if (text.IsNullOrEmpty())
            {
                return;
            }

            _textField.ClearInput();
            var added = _permissionsManipulator.AddPermission(text); 
            if (added == AddPermissionResult.OK)
            {
                _permissionAddSuccessDrawer.Trigger(2f);
            }
            else
            {
                HGLogger.LogError("Failed to add permission with error:" + added.ToString());
            }
        }

        private void OnAddPermissionPressed(AutocompletedTextField textField)
        {
            var text = textField.GetCurrentText();
            AddPermission(text);
        }

    }
}