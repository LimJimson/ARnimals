using System;
using HG.Extensions;
using HG.Window;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public static class ManifestAdditionErrorHandler
    {
        public static void HandleError(AddManifestResultHolder holder)
        {
            if (!holder.ErrorMessage.IsNullOrEmpty())
            {
                ShowErrorDialog(holder.ErrorMessage);
                return;
            }

            switch (holder.Result)
            {
                case AddManifestResult.OK:
                    return;
                case AddManifestResult.SamePathExists:
                    ShowErrorDialog("Manifest with the same path was already added");
                    break;
                case AddManifestResult.InvalidPath:
                    ShowErrorDialog("Invalid Manifest Path");
                    break;
                case AddManifestResult.PathOutsideAndroidFolder:
                    ShowErrorDialog("Manifest is outside of /Assets/Plugins/Android folder");
                    break;
                case AddManifestResult.InvalidManifest:
                    ShowErrorDialog("Manifest seems to be invalid");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("result", holder.Result, null);
            }
            
        }

        private static void ShowErrorDialog(string message)
        {
            ModalDialog.CreateOneButtonDialog("Error adding manifest", new Vector2(300, 100),
                new VerticalSequenceDrawer(
                    new HelpBox.HelpBox(message, MessageType.Error)));

        }
    }
}