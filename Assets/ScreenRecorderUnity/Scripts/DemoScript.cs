using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace BrainCheck {

	public enum ScreenRecordingOptions 
	{
	  checkRecordingPermission,
	  requestRecordingPermission,
	  setUpScreenRecorder,
	  startRecording,
	  stopRecording,
	  checkIfRecordingInProgress,
	  setDirectoryNameFileName,
	  pauseScreenRecording,
	  resumeScreenRecording
	}

	public class DemoScript : MonoBehaviour
	{
		public ScreenRecordingOptions myOption;
		string gameObjectName = "UnityReceiveMessage";
		string screenRecorderStatusMethodName = "CurrentStatus";
		string fileName = "ScreenRecording";
		string directoryName = "ScreenRecorder";

		void OnMouseUp() {
	    	StartCoroutine(BtnAnimation());
	 	}

	 	private IEnumerator BtnAnimation()
	    {
	    	Vector3 originalScale = gameObject.transform.localScale;
	        gameObject.transform.localScale = 0.9f * gameObject.transform.localScale;
	        yield return new WaitForSeconds(0.2f);
	        gameObject.transform.localScale = originalScale;
	        ButtonAction();
	    }

	    private void ButtonAction() {
	    	BrainCheck.ScreenRecorderBridge.SetUnityGameObjectNameAndMethodName(gameObjectName, screenRecorderStatusMethodName);
			switch(myOption) 
			{
				case ScreenRecordingOptions.checkRecordingPermission:
				  bool isPermissionGiven = BrainCheck.ScreenRecorderBridge.CheckRecordingPermission();
				  if (isPermissionGiven) {
				  	Debug.Log("== Required Permission Given");
				  }
			      break;
			    case ScreenRecordingOptions.requestRecordingPermission:
				  BrainCheck.ScreenRecorderBridge.RequestPermission();
			      break;
			    case ScreenRecordingOptions.setUpScreenRecorder:
				  BrainCheck.ScreenRecorderBridge.SetUpScreenRecorder();
			      break;
			    case ScreenRecordingOptions.startRecording:
			      BrainCheck.ScreenRecorderBridge.StartScreenRecording();
				  break;
			    case ScreenRecordingOptions.stopRecording:
			      BrainCheck.ScreenRecorderBridge.StopScreenRecording();
			      break;
			    case ScreenRecordingOptions.checkIfRecordingInProgress:
			      bool isRecordingInProgress = BrainCheck.ScreenRecorderBridge.CheckIfRecordingInProgress();
			      if (isRecordingInProgress) {
				  	Debug.Log("== Recording Is In Progress");
				  }
			      break;
			    case ScreenRecordingOptions.setDirectoryNameFileName:
			      BrainCheck.ScreenRecorderBridge.SetFileNameAndDirectoryName(directoryName, fileName);
			      break;
			    case ScreenRecordingOptions.pauseScreenRecording:
			      BrainCheck.ScreenRecorderBridge.PauseScreenRecording();
			      break;
			    case ScreenRecordingOptions.resumeScreenRecording:
			      BrainCheck.ScreenRecorderBridge.ResumeScreenRecording();
			      break;
			}
	    }
	}
}
