using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
	[SerializeField] private Button Button;
	[SerializeField] private GameObject LockedPanel;
	[SerializeField] private GameObject UnlockedPanel;
	[SerializeField] private GameObject[] Stars;
	[SerializeField] private TextMeshProUGUI Text;

	public void Lock()
	{
		LockedPanel.SetActive(true);
		UnlockedPanel.SetActive(false);
	}

	internal void Unlock(int i)
	{
		Text.SetText("{0}", i + 1);
		Button.onClick.AddListener(() =>
		{
			GameManager.stage = i;
			SceneManager.LoadScene("GameScene");
		});
		
	}
}
