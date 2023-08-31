using UnityEngine;

namespace Plugins.HG.Editor.General.Utils
{
    public class EditorSingletonMonoBehaviour<T> : MonoBehaviour where T: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        
        private static T _instance;
        public static T Instance {
            get{
                if (_instance == null)
                {
                    _instance = Create<T>(typeof(T).ToString());
                }
                return _instance;
            }
        }
        

        public static TComponent Create<TComponent>(string uniqueName) where TComponent : MonoBehaviour
        {
            var component = GameObject.FindObjectOfType<TComponent>();
            if (component != null) return component;
                
            return CreateFast<TComponent>(uniqueName);
        }
        
        public static TComponent CreateFast<TComponent>(string uniqueName) where TComponent : MonoBehaviour
        {
            GameObject go = new GameObject("~~" + uniqueName);
            go.hideFlags = HideFlags.HideAndDontSave;
            return go.AddComponent<TComponent>();
        }
    }
}