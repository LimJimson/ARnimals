using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using HG.Extensions;
using HG.List;
using HG.Utils;
using UnityEditor;
using UnityEngine;

namespace HG
{    
    public class ManifestListDrawer : IDrawer
    {
        private IManifestCollection _manifests;
        private ManifestListController _controller;

        private ListDrawer<IManifestInfo> _manifestDrawer;
        private ManifestFinder _manifestFinder;

        
        public ManifestListDrawer(IManifestCollection manifests, ManifestListController controller)
        {
            _manifests = manifests;
            _controller = controller;
            
            _manifestFinder = new ManifestFinder(new UnityPathsProvider());

            manifests.OnManifestListChanged += OnManifestListChanged;
            OnManifestListChanged();
        }

        private void OnManifestListChanged()
        {
            var buttonInfo = new List<ButtonInfo<IManifestInfo>>{new ButtonInfo<IManifestInfo>("...", 40, OpenManifestLocation),
                new ButtonInfo<IManifestInfo>("-", UIConst.X_BUTTON_WIDTH, onRemovePressed)};
            
            _manifestDrawer = ListDrawer<IManifestInfo>.CreateButtonedLabelList(_manifests.GetAllManifests().OrderBy(m => m.XmlPath),
                GetDisplayPath,
                null,
                buttonInfo
            ).SetEmptyDrawer(new Label.Label("No manifests added"));
            
            // @LATER rewrite it this way?
            // manifestDrawer = new ListDrawer<ManifestInfo>(_manifests.GetAllManifests())
            // manifestDrawer.AddLabel(m => ".../" + m.path);
            // manifestDrawer.AddButton("...", 40, OpenManifestLocation); // will add this button for each in a list
            // manifestDrawer.AddButton("x", UIConst.X_BUTTON_WIDTH, onRemovePressed);
            
            // or via builder
            // CreateList<ManifestInfo>(allmanifests).AddLabel().AddButton().AddButton().Build();
            // but this will limit the ability to change it at runtime, but maybe this is good?
            
            // or we add a AddButtonDelegate which is called for each item in a list. (mb look at how Obj-C reusable lists are implemented)
        }

        private string GetDisplayPath(IManifestInfo info)
        {
            StringBuilder displayPath = new StringBuilder(info.XmlPath);

            var genericPath = "Assets/Plugins/Android";
            if (info.XmlPath.StartsWith(genericPath, StringComparison.InvariantCultureIgnoreCase))
            {
                displayPath.Replace(genericPath, "<color=grey>../Android</color>");
            }

            return displayPath.ToString();
        }

        private void OpenManifestLocation(IManifestInfo m)
        {
            EditorUtility.RevealInFinder(m.ContainerPath);
        }

        private void onRemovePressed(IManifestInfo m)
        {
            _controller.Remove(m);
        }

        public void Draw()
        {
            GUILayout.Label ("Manifests", EditorStyles.boldLabel);
            

            _manifestDrawer.Draw();
        
            
            GUILayout.Space(10);
            
            if (GUILayout.Button("Add manifest"))
            {
                _controller.AddManifest();
            }
            
            //GUILayout.Space(8);
            if (GUILayout.Button("Find all manifests (Experimental)"))
            {
                LongProcess.Run(AutodetectManifests, "Searching for Manifests", "Please wait...");
            }
            
            GUILayout.Space(15);
        }

        private void AutodetectManifests()
        {
            bool addedNew = false; 
            var manifests = _manifestFinder.FindAllManifests();
            foreach (var m in manifests)
            {
                addedNew |= _controller.AddManifest(m, AddManifestResult.SamePathExists, AddManifestResult.InvalidManifest);
            }

            if (!addedNew)
            {
                HGLogger.LogWarn("No new manifest was found");
            } 
        }
    }
    
    public class ManifestListController
    {
        private IManifestCollection _manifests;
        public ManifestListController(IManifestCollection manifests)
        {
            _manifests = manifests;
        }

        public void AddManifest()
        {
            var extentions = new[] {"xml"}.Concat(ArchiveManifestInfo.ArchiveExtensions).ToArray();
            var path = UnityPathHelper.SelectFileRelative("Select manifest", "Assets/Plugins/Android", extentions);
            if (path.IsNullOrEmpty()) return;
            
            AddManifest(ManifestInfoFactory.CreateManifestInfo(path));
        }

        // returns true if manifest was successfully added
        public bool AddManifest(IManifestInfo manifest, params AddManifestResult[] ignoredErrors)
        {
            var resultHolder = _manifests.Add(manifest);
            
            // @LATER show a dialog depending on the result
            if (resultHolder.Result != AddManifestResult.OK && !ignoredErrors.Contains(resultHolder.Result))
            {
                ManifestAdditionErrorHandler.HandleError(resultHolder);
            }

            return resultHolder.Result == AddManifestResult.OK;
        }

        public void Remove(IManifestInfo manifest)
        {
            _manifests.Remove(manifest);
        }
        
    }
}