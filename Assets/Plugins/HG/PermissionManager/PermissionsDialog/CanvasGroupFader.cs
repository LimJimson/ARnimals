using System;
using HG.Extensions;
using UnityEngine;

namespace Plugins.HG.PermissionManager
{
    enum FadeState
    {
        FadingIn,
        FadingOut,
        Idle
    }
    
    public class CanvasGroupFader: MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup = null;
        [SerializeField] private float _initialAlpha = 1f;
        [SerializeField] private float _fadeSpeedMultiplier = 12f;

        private FadeState state = FadeState.Idle;

        private event Action OnFadedOut;
        private event Action OnFadedIn;
        
        private void Awake()
        {
            _canvasGroup.alpha = _initialAlpha;
        }

        public void FadeIn(Action onFinish = null)
        {
            if(onFinish != null) OnFadedIn += onFinish;
            
            state = FadeState.FadingIn;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public void FadeOut(Action onFinish = null)
        {
            if(onFinish != null) OnFadedOut += onFinish;
            
            state = FadeState.FadingOut;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private void Update()
        {
            switch (state)
            {
                case FadeState.FadingIn:                   
                    _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 1f, Time.unscaledDeltaTime * _fadeSpeedMultiplier);
                    if (_canvasGroup.alpha >= 0.999f)
                    {
                        _canvasGroup.alpha = 1f;
                        state = FadeState.Idle;
                        OnFadedIn.InvokeSafe();
                        OnFadedIn = null;
                    }

                    break;
                case FadeState.FadingOut:
                    _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 0f, Time.unscaledDeltaTime * _fadeSpeedMultiplier);
                    if (_canvasGroup.alpha <= 0.0001f)
                    {
                        _canvasGroup.alpha = 0f;
                        state = FadeState.Idle;
                        OnFadedOut.InvokeSafe();
                        OnFadedOut = null;
                    }
                    
                    break;
                case FadeState.Idle:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}