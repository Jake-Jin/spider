using UnityEngine;

public class FailedWhenContact : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		var player = collision.collider.GetComponent<PlayerController>();
		if (player != null) FailedObserver.GameFailed();
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		var player = collision.collider.GetComponent<PlayerController>();
		if (player != null) FailedObserver.GameFailed();
	}
}