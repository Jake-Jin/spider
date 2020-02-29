using System;
using UnityEngine;

public class QuestObserver
{
	public static event Action<byte> OnQuest;

	public static void QuestClear(byte id)
	{
		OnQuest?.Invoke(id);
	}
}