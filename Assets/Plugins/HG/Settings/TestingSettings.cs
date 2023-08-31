using System;
using HG.Extensions;

namespace HG
{
    public class TestingSettings : IDisposable
    {
        private readonly Settings _settings;
        
        private const string _TestingEnabled = "TestingEnabled";
        private const string _TestingApiLevel = "TestingApiLevel";
        private const string _TestingStorePersistently = "TestingStorePersistent";

        public event Action OnTestingEnabledChanged; 
        public event Action OnTestingApiLevelChanged; 
        
        public bool TestingEnabled {
            get
            {
                #if !UNITY_EDITOR
                    return false;
                #else                
                    return _settings.GetBool(_TestingEnabled, true);
                #endif
            }
            set { _settings.SetBool(_TestingEnabled, value); }
        }
        
        public int TestingApiLevel {
            get { return _settings.GetInt(_TestingApiLevel, 23); }
            set { _settings.SetInt(_TestingApiLevel, value); }
        }
        
        public bool TestingStorePersistently {
            get { return _settings.GetBool(_TestingStorePersistently, true); }
            set { _settings.SetBool(_TestingStorePersistently, value); }
        }

        public TestingSettings(Settings settings)
        {
            _settings = settings;

            _settings.OnValueChanged += OnValueChanged;
        }

        private void OnValueChanged(string s)
        {
            // @LATER improve this by subsribing to specific stuff?
            // Take my EventDispatcher?
            if (s == _TestingEnabled)
            {
                OnTestingEnabledChanged.InvokeSafe();
            }
            else if (s == _TestingApiLevel)
            {
                OnTestingApiLevelChanged.InvokeSafe();
            }
        }

        public void Clear()
        {
            _settings.Clear();
        }

        public void Dispose()
        {
            if (_settings != null) _settings.Dispose();
            OnTestingEnabledChanged = null;
            OnTestingApiLevelChanged = null;
        }
    }
}