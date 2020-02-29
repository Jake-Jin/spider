using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScene : MonoBehaviour
{
	public GameObject LevelItem;
	public Transform ParentLayout;

	private int MAX_STAGE = 3;

	private void Awake()
	{
		for (int i = 0; i < MAX_STAGE; i++)
		{
			LevelItem item = Instantiate(LevelItem, ParentLayout, false).GetComponent<LevelItem>();
			if (i <= SettingHelper.Level) item.Unlock(i);
			else item.Lock();
		}
	}

	public void LoadMainScene() => SceneManager.LoadScene("MainScene");
}
