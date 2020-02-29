using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour
{
	public void Restart() => SceneManager.LoadScene("GameScene");
	
	public void Resume()
	{
		Time.timeScale = 1f;
		gameObject.SetActive(false);
	}

	public void LoadLevelScene() => SceneManager.LoadScene("LevelScene");
}
