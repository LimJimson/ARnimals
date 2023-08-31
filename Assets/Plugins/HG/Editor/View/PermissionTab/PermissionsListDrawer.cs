using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HG.Autocomplete;
using HG.Button;
using HG.Extensions;
using HG.List;
using UnityEditor;
using UnityEngine;

namespace HG
{
    internal class PermissionsListController
    {
        private readonly IPermissionsManipulator _permissionsManipulator;
        
        public PermissionsListController(IPermissionsManipulator permissionsManipulator)
        {
            _permissionsManipulator = permissionsManipulator;
        }

        public void RemovePermission(IPermissionInfo permission)
        {
            _permissionsManipulator.RemovePermission(permission);
        }
    }

    internal class PermissionsListDrawer : VerticalSequenceDrawer
    {
        Foldout _dangerousFoldout = new Foldout("Dangerous Permissions");
        //Foldout _normalFoldout = new Foldout("Normal Permissions");
        Foldout _otherlFoldout = new Foldout("Other Permissions");

        private readonly IPermissionsManipulator _permissionsManipulator;
        private PermissionsListController _controller;
        private DataHolder _data;
        
        public PermissionsListDrawer(IPermissionsManipulator permissionsManipulator, PermissionsListController permissionsListController, DataHolder data)
        {
            _permissionsManipulator = permissionsManipulator;
            _controller = permissionsListController;
            _data = data;

            _permissionsManipulator.OnRefreshRequired += OnPermissionsChanged;
            OnPermissionsChanged();

            SetupSequence();
        }

        private void SetupSequence()
        {
            var sdkVersionNotice =
                new HelpBox.RichHelpbox(
                    "Note: Dangerous permissions only effect you if your target sdk is >= 23 and the target device is running android 6 or later.\nClick <color=#FF00AAFF><b>here</b></color> to read more").EnableRichText();            
            AddDrawer(new Clickable(sdkVersionNotice, OnSdkNoticeClicked));

            AddDrawer(_dangerousFoldout);
            AddDrawer(new Space(10));
            /*AddDrawer(_normalFoldout);
            AddDrawer(new Space(10));*/
            
            AddDrawer(_otherlFoldout);
            AddDrawer(new Space(10));
            
            AddDrawer(new Label.Label("Add Permission"));
            AddDrawer(new PermissionAdderDrawer(_permissionsManipulator, _data));
        }

        private void OnSdkNoticeClicked()
        {
            Application.OpenURL("http://letsmakeagame.net/documentation-permission-manager/#dangerous-and-normal-permissions");
        }

        private void OnPermissionsChanged()
        {
            var allPermissions = _permissionsManipulator.GetAllPermissions().OrderBy(p => p.FullName);
            
            var dangerousPermissions = allPermissions.Where(p => p.IsDangerous);
//            var normalPermissions = allPermissions.Where(p => p.IsNormal);
//            var otherPermissions = allPermissions.Where(p => !p.IsDangerous && !p.IsNormal);
            var otherPermissions = allPermissions.Where(p => !p.IsDangerous);
            
            
            _dangerousFoldout.RemoveAllDrawers();
            //_normalFoldout.RemoveAllDrawers();
            _otherlFoldout.RemoveAllDrawers();

            _dangerousFoldout.AddDrawer(CreatePermissionListDrawer(dangerousPermissions));
            //_normalFoldout.AddDrawer(CreatePermissionListDrawer(normalPermissions));
            _otherlFoldout.AddDrawer(CreatePermissionListDrawer(otherPermissions));
        }

        private IDrawer CreatePermissionListDrawer(IEnumerable<IPermissionInfo> permissions)
        {
            return ListDrawer<IPermissionInfo>.CreateButtonedLabelList(permissions,
                s => s.FullName,
                PermissionTooltip,
                new List<ButtonInfo<IPermissionInfo>> {new ButtonInfo<IPermissionInfo>("x", UIConst.X_BUTTON_WIDTH, OnRemovePressed)}
            ).SetEmptyDrawer(new Label.Label("No permissions found"));
        }

        private string PermissionTooltip(IPermissionInfo permission)
        {
            if (!string.IsNullOrEmpty(permission.Description))
            {
                return string.Format("[{0}] - {1}",permission.GetShortName(), permission.Description);
            }

            return "[no description]";
        }

        private void OnRemovePressed(IPermissionInfo permission)
        {
            _controller.RemovePermission(permission);
        }
    }
}