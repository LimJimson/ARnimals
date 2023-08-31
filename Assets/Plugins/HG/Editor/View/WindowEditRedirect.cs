using UnityEditor;

namespace HG
{
    [CustomEditor(typeof(AndroidManifestToolSettings))]
    public class AndroidManifestToolSettingsDrawer : WindowEditRedirect
    {
    }

    [CustomEditor(typeof(SettingsScriptableObject))]
    public class SettingsScriptableObjectDrawer : WindowEditRedirect
    {
    }

    // Note: derive from this class & add a [CustomEditor(typeof(YourType))]
    public class WindowEditRedirect : CustomEditorDrawer
    {
        private void OnEnable()
        {
            _drawer.AddDrawer(new Label.Label("All modifications are performed via the plugin window"));
            _drawer.AddDrawer(new Button.Button("Open Window",
                PermissionsEditorWindow.ShowWindow));
        }
    }
}