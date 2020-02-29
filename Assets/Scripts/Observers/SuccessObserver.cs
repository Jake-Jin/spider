using System;

public class SuccessObserver
{
	public static event Action OnSuccess;

	public static void GameClear()
	{
		OnSuccess?.Invoke();
	}

	public static void Clear()
	{
		OnSuccess = null;
	}
}
