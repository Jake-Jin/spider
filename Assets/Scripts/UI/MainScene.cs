using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
	public GameObject SettingWindow;

	private void Awake()
	{
#if UNITY_STANDALONE
		Screen.SetResolution(1024, 768, false);
		Screen.fullScreen = false;
#endif
	}

	public void LoadLevelScene()
	{
		SceneManager.LoadScene("LevelScene");
	}

	public void ShowSettingWindow() => SettingWindow.SetActive(true);

	public void ShareGame()
	{
		const string subject = "극한 난이도 게임";
		const string body = "https://play.google.com/store/apps/details?id=com.beside.trianglespider&showAllReviews=true";

		switch (Application.platform)
		{
			case RuntimePlatform.Android:
				using (AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent"))
				using (AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent"))
				{
					intentObject.Call<AndroidJavaObject>("setAction", intentObject.GetStatic<string>("ACTION_SEND"));
					intentObject.Call<AndroidJavaObject>("setType", "text/plain");
					intentObject.Call<AndroidJavaObject>("putExtra", intentObject.GetStatic<string>("EXTRA_SUBJECT"), subject);
					intentObject.Call<AndroidJavaObject>("putExtra", intentObject.GetStatic<string>("EXTRA_TEXT"), body);
					using (AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
					using (AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
					using (AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via"))
						currentActivity.Call("startActivity", jChooser);
				}
				break;
		}
	}
}
