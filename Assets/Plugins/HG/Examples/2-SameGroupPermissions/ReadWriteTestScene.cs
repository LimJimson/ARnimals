using System.Collections;
using System.Collections.Generic;
using HG;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This example shows the behaviour when requesting multiple permissions from the same Permission Group.
/// </summary>
public class ReadWriteTestScene : MonoBehaviour
{	
	[SerializeField] private Text output = null;

	/// <summary>
	/// Called by the "Request Read Permission" button
	/// </summary>
	public void RequestReadPermission()
	{
		PermissionManager.RequestPermission(Permission.READ_EXTERNAL_STORAGE,
			OnPermissionGranted,
			OnPermissionDenied);
	}
	
	/// <summary>
	/// Called by the "Request Write Permission" button
	/// </summary>
	public void RequestWritePermission()
	{
		PermissionManager.RequestPermission(Permission.WRITE_EXTERNAL_STORAGE,
			OnPermissionGranted,
			OnPermissionDenied);
	}
	
	/// <summary>
	/// Called if permission was granted after the request from "RequestReadPermission" or "RequestWritePermission"
	/// </summary>
	/// <param name="grantedPermission">name of the granted permission</param>
	private void OnPermissionGranted(string grantedPermission)
	{
		ShowMessage(grantedPermission + " permission was granted after request");
	}

	/// <summary>
	/// Called if permission was denied after the request from "RequestReadPermission" or "RequestWritePermission"
	/// </summary>
	/// <param name="deniedPermission">name of the denied permission</param>
	private void OnPermissionDenied(string deniedPermission)
	{
		ShowMessage(deniedPermission + " permission was denied.");
	}

	/// <summary>
	/// Outputs the message to the screen
	/// </summary>
	void ShowMessage(string message)
	{
		output.text = message;		
	}
}
