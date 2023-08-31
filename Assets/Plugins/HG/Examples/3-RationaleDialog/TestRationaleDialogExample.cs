using System;
using System.Collections;
using System.Collections.Generic;
using HG;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// An example for the ShouldShowRequestPermissionRationale method
/// </summary>
public class TestRationaleDialogExample : MonoBehaviour 
{
	// Dangerous permission to be requested
	private const string STORAGE_PERMISSION = Permission.WRITE_EXTERNAL_STORAGE;
	
	[SerializeField] private Text output = null;
	// Canvas where rationale dialog will be added to
	[SerializeField] private Canvas mainCanvas = null;
	// Rationale dialog prefab
	[SerializeField] private GameObject rationaleDialogPrefab = null;
	
	/// <summary>
	/// Called by the "Request Permission" button.
	/// Checks if rationale should be shown & Requests a permission right after it
	/// Note: ShouldShowRequestPermissionRationale always returns false for api level 22 or lower
	/// </summary>
	public void TestRequestPermission()
	{
		if (PermissionManager.ShouldShowRequestPermissionRationale(STORAGE_PERMISSION))
		{
			ShowRationaleDialog(RequestPermission);
		}
		else
		{
			RequestPermission();
		}
	}

	/// <summary>
	/// Create a simple rationale dialog
	/// </summary>
	/// <param name="onOkPressed">What should be called when OK is pressed</param>
	private void ShowRationaleDialog(Action onOkPressed)
	{
		GameObject dialogGameObject = Instantiate(rationaleDialogPrefab, mainCanvas.transform) as GameObject;
		ExampleRationaleDialog dialog = dialogGameObject.GetComponent<ExampleRationaleDialog>();
		dialog.SetOkCallback(onOkPressed);
	}

	/// <summary>
	/// Request the permission
	/// For api level 23+ this may show the request dialog (This depends on the current permission state)
	/// </summary>
	private void RequestPermission()
	{
		PermissionManager.RequestPermission(STORAGE_PERMISSION,
			OnPermissionGranted,
			OnPermissionDenied);
	}
	
	/// <summary>
	/// Called if permission was granted after the request from "RequestPermission"
	/// </summary>
	/// <param name="grantedPermission">name of the granted permission</param>
	private void OnPermissionGranted(string grantedPermission)
	{
		ShowMessage("Permission was granted after request");
	}
	
	/// <summary>
	/// Called if permission was denied after the request from "RequestPermission"
	/// </summary>
	/// <param name="deniedPermission">name of the denied permission</param>
	private void OnPermissionDenied(string deniedPermission)
	{
		ShowMessage("Permission was denied");
	}

	/// <summary>
	/// Outputs the message to the screen
	/// </summary>
	private void ShowMessage(string message)
	{
		output.text = message;
	}
}
