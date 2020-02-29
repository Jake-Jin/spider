using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessWhenQuestCompleted : MonoBehaviour
{
	public byte QuestId;
	public byte Requirement = 1;
	private byte Current;

	private void Awake()
	{
		QuestObserver.OnQuest += OnQuest;
	}

	public void OnQuest(byte id)
	{
		if (QuestId != id) return;

		if (++Current >= Requirement) SuccessObserver.GameClear();
	}

	private void OnDestroy()
	{
		QuestObserver.OnQuest -= OnQuest;
	}
}
