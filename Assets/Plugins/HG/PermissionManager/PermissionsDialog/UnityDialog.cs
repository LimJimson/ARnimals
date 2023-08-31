using System;
using HG.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plugins.HG.PermissionManager
{
    public class UnityDialog : MonoBehaviour
    {
        [SerializeField] protected Text messageLabel;
       
        [SerializeField] protected Button leftButton;
        [SerializeField] protected Button rightButton;

        protected Action _onLeftPressed;
        protected Action _onRightPressed;

        protected virtual void Awake()
        {
            leftButton.onClick.AddListener(new UnityAction(() => { OnButtonPressed(_onLeftPressed); }));
            rightButton.onClick.AddListener(new UnityAction(() => { OnButtonPressed(_onRightPressed); }));
        }

        protected virtual void OnDestroy()
        {
        }

        protected virtual void Update()
        {
        }

        protected virtual void OnButtonPressed(Action dlg)
        {
            dlg.InvokeSafe();
            DestorySelf();
        }

        protected virtual void DestorySelf()
        {
            Destroy(gameObject);
        }

        public void Setup(string message, Action onLeftPressed, Action onRightPressed)
        {
            messageLabel.text = message;
            
            _onLeftPressed = onLeftPressed;
            _onRightPressed = onRightPressed;
        }
        
    }
}