using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.HG.PermissionManager;
using HG.Window;
using Plugins.HG.Editor.General.Utils;

namespace HG
{
    public class PermissionsEditorWindow : HGEditorWindow
    {
        [MenuItem("Window/Android Permission Manager/Settings")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(PermissionsEditorWindow), false, "Permissions");
        }
        
        [MenuItem("Window/Android Permission Manager/Support")]
        public static void OpenSupport()
        {
            Application.OpenURL("http://letsmakeagame.net/support");
        }
        
        [MenuItem("Window/Android Permission Manager/Documentation")]
        public static void OpenDocumentation()
        {
            var originalDocPath = "/Plugins/HG/APM_Documentation.pdf";
            LocalFileOpener.OpenLocalFile(originalDocPath, "APM_Documentation");
        }
        
        public override IDrawer CreateDrawer()
        {
            // @LATER - get a single object that contains the collection + Manipulator?
            var manifestCollection = ManifestCollectionHolder.ManifestCollection;
            var manipulators = ManifestCollectionHolder.Manipulators;
            
            var tabBar = new TabBar();
            tabBar.AddTab(GeneralTabFactory.CreateTab(manifestCollection, manipulators.SkipPermissionsDialogManipulator));
            tabBar.AddTab(PermissionsTabFactory.CreateTab(manipulators.PermissionsManipulator, SettingsHolder.Instance.GetDataHolder()));
            tabBar.AddTab(TestingTabFactory.CreateTab(manipulators.SkipPermissionsDialogManipulator, SettingsHolder.Instance.TestingSettings));

            return tabBar;
        }
    }
}