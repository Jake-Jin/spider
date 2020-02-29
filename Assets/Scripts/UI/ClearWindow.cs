using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearWindow : MonoBehaviour
{
	[SerializeField] private Transform Shine;
	[SerializeField] private TextMeshProUGUI Title;

	private Vector3 rotation = new Vector3(0, 0, 0.5f);
	private string message = "STAGE {0}\nCLEAR";

	void Update()
    {
		Shine.Rotate(rotation);
    }

	public void Show()
	{
		Title.SetText(message, GameManager.stage + 1);
		gameObject.SetActive(true);
	}

	public void Restart() => SceneManager.LoadScene("GameScene");

	public void LoadLevelScene() => SceneManager.LoadScene("LevelScene");
}
