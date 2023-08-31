using HG;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This example shows a way to request and to check of permission was already granted
/// </summary>
public class RequestPermissionExample : MonoBehaviour
{
	// Permission to be requested
	private const string STORAGE_PERMISSION = Permission.READ_EXTERNAL_STORAGE;
	
	[SerializeField] private Text output = null;
	
	/// <summary>
	/// Called by the "Request Permission" button.
	/// Requests the permission that may show the permission dialog if api level is 23 or higher
	/// The same method works for both requesting on a android device and to test in Editor
	/// </summary>
	public void TestRequestPermission()
	{
		ShowMessage("TestRequestPermission");
		
		PermissionManager.RequestPermission(STORAGE_PERMISSION,
			OnPermissionGranted,
			OnPermissionDenied);
	}
	
	/// <summary>
	/// Called if permission was granted after the request from "TestRequestPermission"
	/// </summary>
	/// <param name="grantedPermission">name of the granted permission</param>
	private void OnPermissionGranted(string grantedPermission)
	{
		ShowMessage("Permission was granted after request");
	}
	
	/// <summary>
	/// Called if permission was denied after the request from "TestRequestPermission"
	/// </summary>
	/// <param name="deniedPermission">name of the denied permission</param>
	private void OnPermissionDenied(string deniedPermission)
	{
		ShowMessage("Permission was denied");
	}

	/// <summary>
	/// Called by the "Check Permission" button.
	/// Outputs if permission was already granted or not
	/// </summary>
	public void CheckPermission()
	{
		if (PermissionManager.IsPermissionGranted(STORAGE_PERMISSION))
		{
			ShowMessage(STORAGE_PERMISSION + " was already granted");
		}
		else
		{
			ShowMessage(STORAGE_PERMISSION + " is not yet granted");
		}
	}

	/// <summary>
	/// Outputs the message to the screen
	/// </summary>
	private void ShowMessage(string message)
	{
		output.text = message;
	}
}
