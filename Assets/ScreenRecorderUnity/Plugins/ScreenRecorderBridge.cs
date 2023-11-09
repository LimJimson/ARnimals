using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BrainCheck {

	public class ScreenRecorderBridge {
		static AndroidJavaClass _class;
		static AndroidJavaObject instance { get { return _class.GetStatic<AndroidJavaObject>("instance"); } }

		private static void SetupPlugin () {
			if (_class == null) {
				_class = new AndroidJavaClass ("mayankgupta.com.audioPlugin.ScreenRecorderPlugin");
				_class.CallStatic ("_initiateFragment");
			}
		}

		public static bool CheckRecordingPermission(){
			SetupPlugin ();
		   	return instance.Call<bool>("checkPermissions");
		}

		public static void RequestPermission(){
			SetupPlugin ();
		   	instance.Call("requestPermissions");
		}
		
		public static void SetUpScreenRecorder(){
			SetupPlugin ();
		   	instance.Call("setUpSreenRecorder");
		}

		public static void StopScreenRecording(){
			SetupPlugin ();
		   	instance.Call("stopRecording");
		}

		public static void PauseScreenRecording(){
			SetupPlugin ();
		   	instance.Call("pauseRecording");
		}

		public static void ResumeScreenRecording(){
			SetupPlugin ();
		   	instance.Call("resumeRecording");
		}

		public static void StartScreenRecording(){
			SetupPlugin ();
		   	instance.Call("startRecording");
		}

		public static bool CheckIfRecordingInProgress(){
			SetupPlugin ();
		   	return instance.Call<bool>("isScreenRecordingInProgress");
		}
		public static void SetFileNameAndDirectoryName(string directoryName, string fileName){
			SetupPlugin ();
		   	instance.Call("setOutputDirectoryNameAndFileName", directoryName, fileName);
		}
		public static void SetUnityGameObjectNameAndMethodName(string ganeObject, string methodName){
			SetupPlugin ();
		   	instance.Call("_setUnityGameObjectNameAndMethodName", ganeObject, methodName);
		}
	}

}