using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
public class Share {
	
	[DllImport("__Internal")]
	private static extern void ShareImageToFacebook_iOS (string path, string message, string link);


	public static void ShareMessage(string subject, string title, string message, string imagePath, string link) {
		if (Application.platform == RuntimePlatform.Android) {
			ShareImageAndroid (imagePath, subject, title,message);
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			ShareMessageIOS (imagePath, message, link);	
		}

	}


	static void ShareMessageIOS(string path, string message, string link) {
		
		ShareImageToFacebook_iOS (path, message, link);
	}

	public static void ShareImageAndroid(string imageFileName, string subject, string title, string message)
	{

		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		intentObject.Call<AndroidJavaObject>("setType", "image/*");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), title);
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), message);

		AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
		AndroidJavaObject fileObject = new AndroidJavaObject("java.io.File", imageFileName);
		AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("fromFile", fileObject);

		bool fileExist = fileObject.Call<bool>("exists");
		Debug.Log("File exist : " + fileExist);
		// Attach image to intent
		if (fileExist)
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		currentActivity.Call ("startActivity", intentObject);

	}
}
