using System;
using UnityEngine;

/// <summary>
/// A simple dialog class that invokes a callback when closed
/// </summary>
public class ExampleRationaleDialog : MonoBehaviour
{
    private Action onOkPressed;
    
    /// <summary>
    /// Register the callback to be invoked when OK is pressed
    /// </summary>
    public void SetOkCallback(Action OnOkPressed)
    {
        this.onOkPressed = OnOkPressed;
    }

    /// <summary>
    /// Called by pressing OK on the popup dialog
    /// </summary>
    public void OnButtonPressed()
    {
        if (onOkPressed != null)
        {
            onOkPressed();
        }

        Destroy(gameObject);
    }
}
