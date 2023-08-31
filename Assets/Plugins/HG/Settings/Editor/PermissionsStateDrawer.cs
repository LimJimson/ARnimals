using System;
using UnityEngine;
using System.Text;
using HG.Dropdown;
using HG.Extensions;
using HG.List;
using HG.Window;
using UnityEditor;

namespace HG.InspectorDrawer
{
public class PermissionStateLineDrawer : HorizontalSequenceDrawer
{
    public PermissionStateLineDrawer(string name, PermissionState state, Action<PermissionState> OnStateChanged,
        DataHolder.PermissionsData permissionsData)
    {
        AddDrawer(new Label.Label(name, GetTooltip(name, permissionsData)));

        var stateEnum = new EnumDropdown(state);
        stateEnum.OnChangedSelection += () => { OnStateChanged.InvokeSafe((PermissionState)stateEnum.GetCurrentValue()); };
        
        AddDrawer(stateEnum);
    }

    // @LATER - consider calculating the tooltip only if it is being used
    private string GetTooltip(string name, DataHolder.PermissionsData data)
    {
        var permissionInfo = data.FindPermissionByFullName(name);
        if (permissionInfo == null)
        {
            var categoryPermissions = data.FindPermissionsByCategory(name);

            if (!categoryPermissions.IsNullOrEmpty())
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Permission Group: " + name);
                foreach (DataHolder.Permission permission in data.FindPermissionsByCategory(name))
                {
                    stringBuilder.AppendLine("    " + permission.FullName);
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1); // removes last \n

                return stringBuilder.ToString();
            }
        }

        // the name was a permission, not a category 
        return "This permission is not in a Permission Group";

    }
}

// @LATER make it IDisposable to unsubscribe from SettingsHolder
public class PermissionsListDrawer : AlteratingListDrawer, IDisposable
{
    private readonly DataHolder.PermissionsData _permissionsData;
    private readonly PermissionsState _permissionsState;

    public PermissionsListDrawer(DataHolder.PermissionsData permissionsData, PermissionsState permissionsState): base(ListOrientation.Vertical)
    {
        _permissionsData = permissionsData;
        _permissionsState = permissionsState;
        _permissionsState.OnDictionaryChanged += OnStatesValueChanged;
        Refresh();
    }

    private void OnStatesValueChanged()
    {
        Refresh();
    }

    public void Refresh()
    {
        RemoveAllDrawers();

        foreach (var key in _permissionsState.Keys)
        {
            var permissionName = key; // copy to use in lambda
            var state = _permissionsState.Get(permissionName);
            
            AddDrawer(new PermissionStateLineDrawer(permissionName, state, (newState) =>
                {
                    ChangeState(permissionName, newState);
                }, _permissionsData ));
        }
    }

    private void ChangeState(string name, PermissionState newState)
    {
        _permissionsState.Set(name, newState);   
    }

    public void Dispose()
    {
        _permissionsState.OnDictionaryChanged -= OnStatesValueChanged;

    }
}


[CustomEditor(typeof(PermissionsStateScriptable))]
public class LevelScriptEditor : CustomEditorDrawer
{   
    private PermissionsListDrawer _permissionsListDrawer;
    
    private void OnEnable()
    {      
        _permissionsListDrawer = new PermissionsListDrawer(SettingsHolder.Instance.GetDataHolder().Permissions, SettingsHolder.Instance.PermissionsState);
        
        _drawer.RemoveAllDrawers();

        _drawer.AddDrawer(new HelpBox.HelpBox("Permission States will be used only while testing Android 6 or higher (api level 23+)", MessageType.Info, 10));
        _drawer.AddDrawer(new HG.Space(10));
        _drawer.AddDrawer(new EmptySequenceDrawer( _permissionsListDrawer).SetEmptyDrawer(new Label.Label("No states added yet")));
        _drawer.AddDrawer(new HG.Space(15)); // @LATER have a constant for vertical spacing of one element. (and use it here)
        _drawer.AddDrawer(new Button.Button("Add Permission State", OnAddPermissionStatePressed));
        _drawer.AddDrawer(new Button.Button("Clear All", OnClearAllPressed));
    }

    private void OnDestroy()
    {
        _permissionsListDrawer.Dispose();
    }

    private void OnClearAllPressed()
    {
        DisplayDialog.Create("Clear All States", "Are you sure you want to delete all states?", "OK", () =>
        {
            SettingsHolder.Instance.PermissionsState.Clear();
            _permissionsListDrawer.Refresh(); // @LATER consider if ettingsHolder.PermissionsState.Clear(); should have fired an event to avoid this call
        }, "Cancel");    
    }

    private void OnAddPermissionStatePressed()
    {
        var permissionNameField = new TextField.TextField("Permission name");
        var permissionStateDropdown = new EnumDropdown(PermissionState.NotRequested);
                
        ModalDialog.CreateDialog("Add Permission State", new Vector2(260, 85),
            new VerticalSequenceDrawer( 
                new Focusable(permissionNameField),
                new HG.Space(4),
                permissionStateDropdown), () =>
            {
                OnAddPermissionState(permissionNameField, permissionStateDropdown);
            });    
    }
    
    private void OnAddPermissionState(TextField.TextField permissionNameField, EnumDropdown permissionStateDropdown)
    {
        SettingsHolder.Instance.PermissionsState.Set(permissionNameField.GetCurrentText(), 
            (PermissionState)permissionStateDropdown.GetCurrentValue());   

    }
}

}