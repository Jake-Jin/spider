using System;
using UnityEngine;

public class SuccessContactObserver : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		var subject = collision.gameObject.GetComponent<SuccessContactSubject>();
		if (subject != null) SuccessObserver.GameClear();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var subject = collision.collider.gameObject.GetComponent<SuccessContactSubject>();
		if (subject != null) SuccessObserver.GameClear();
	}
}