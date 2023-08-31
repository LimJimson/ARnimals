#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace HG
{
    public enum LogLevel
    {
        Info = 1, 
        Warning,
        Error,
        None
    }
    
    public static class HGLogger
    {
        private static string _prefix = "[PermissionManager]";
        private const string PrefsKey = "HGLogger_SelectedLoggingLevel";
        private static LogLevel? _selectedLogLevel;
        public static LogLevel SelectedLoggingLevel
        {
            get
            {
                if (!_selectedLogLevel.HasValue)
                {
                    #if UNITY_EDITOR
                        _selectedLogLevel = (LogLevel) EditorPrefs.GetInt(PrefsKey, (int)LogLevel.Info);
                    #else
                        _selectedLogLevel = LogLevel.None;
                    #endif
                }

                return _selectedLogLevel.Value;
            }
            set
            {
                _selectedLogLevel = value;
                #if UNITY_EDITOR
                EditorPrefs.SetInt(PrefsKey, (int) value);
                #endif
            }
        }

        public static void SetGlobalPrefix(string prefix)
        {
            _prefix = string.Format("[{0}]", prefix);
        }
        
        public static void LogInfo(string message)
        {
            if (!CanLog(LogLevel.Info)) return;
            
            Debug.Log(PrepareMessage(message));
        }
        
        public static void LogInfo(string format, params object[] args)
        {
            if (!CanLog(LogLevel.Info)) return;
            
            Debug.LogFormat(PrepareMessage(format), args);
        }

        public static void LogWarn(string message)
        {
            if (!CanLog(LogLevel.Warning)) return;
            
            Debug.LogWarning(PrepareMessage(message));
        }
        
        public static void LogWarn(string format, params object[] args)
        {
            if (!CanLog(LogLevel.Warning)) return;
            
            Debug.LogWarningFormat(PrepareMessage(format), args);
        }

        public static void LogError(string message)
        {
            if (!CanLog(LogLevel.Error)) return;
            
            Debug.LogError(PrepareMessage(message));
        }
        
        public static void LogError(string format, params object[] args)
        {
            if (!CanLog(LogLevel.Error)) return;
            
            Debug.LogErrorFormat(PrepareMessage(format), args);
        }

        private static bool CanLog(LogLevel level)
        {
            return (int)SelectedLoggingLevel <= (int)level;
        }

        private static string PrepareMessage(string message)
        {
            return string.Format("{0} {1}", _prefix, message);
        }
    }
}