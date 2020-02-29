using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static int stage = 0;

	public GameObject PauseWindow;
	public ClearWindow ClearWindow;
	public GameObject FailWindow;

	private void Awake()
	{
		var mapGO = Instantiate(Resources.Load<GameObject>($"Maps/Map{stage + 1}"));
		FindObjectOfType<CinemachineVirtualCamera>().Follow = mapGO.GetComponentInChildren<PlayerController>().transform;

		SuccessObserver.OnSuccess += OnSuccess;
		FailedObserver.OnFailed += OnFailed;
	}

	private void OnDestroy()
	{
		SuccessObserver.OnSuccess -= OnSuccess;
		FailedObserver.OnFailed -= OnFailed;
		Time.timeScale = 1f;
	}

	#region METHODS
	private void OnSuccess()
	{
		if (SettingHelper.Level <= stage) SettingHelper.Level += 1;
		ClearWindow.Show();
		Time.timeScale = 0f;
	}

	private void OnFailed()
	{
		FailWindow.SetActive(true);
		Time.timeScale = 0f;
	}

	public void ShowPauseWindow()
	{
		PauseWindow.SetActive(true);
		Time.timeScale = 0f;
	}

	public void ReloadScene() => SceneManager.LoadScene("GameScene");

	public void LoadLevelScene() => SceneManager.LoadScene("LevelScene");
	#endregion
}
