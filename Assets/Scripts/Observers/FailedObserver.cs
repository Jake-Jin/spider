using System;
using UnityEngine;

public class FailedObserver
{
	public static event Action OnFailed;

	public static void GameFailed()
	{
		OnFailed?.Invoke();
	}

	public static void Clear()
	{
		OnFailed = null;
	}
}