using System;
using HG.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.HG.PermissionManager
{
    public interface IPermissionsDialog
    {
        bool IsChecked();
    }



    public class PermissionsDialog : UnityDialog, IPermissionsDialog
    {

        [SerializeField] private Toggle dontAskAgainCheckbox = null;
        [SerializeField] private CanvasGroupFader _canvasFader = null;
        private bool _buttonWasPressed;

        protected override void Awake()
        {
            DontDestroyOnLoad(this);
            base.Awake();
            
            _canvasFader.FadeIn();
        }


        protected override void OnButtonPressed(Action dlg)
        {
            _buttonWasPressed = true;
            base.OnButtonPressed(dlg);
        }

        protected override void DestorySelf()
        {
            _canvasFader.FadeOut(() =>
            {
                Destroy(gameObject);
            });
            
        }

        // @LATER consider moving into a base class
        protected override void OnDestroy()
        {
            if (!_buttonWasPressed)
            {
                _onLeftPressed.InvokeSafe();
            }
            base.OnDestroy();
        }

        public void SetupCheckbox(bool visible, bool isChecked)
        {
            dontAskAgainCheckbox.gameObject.SetActive(visible);
            dontAskAgainCheckbox.isOn = isChecked;
            dontAskAgainCheckbox.onValueChanged.AddListener(UpdateButtons);

            UpdateButtons(isChecked);
        }

        private void UpdateButtons(bool isChecked)
        {
            rightButton.interactable = !isChecked;
        }

        public bool IsChecked()
        {
            return dontAskAgainCheckbox.isOn;
        }
    }
}