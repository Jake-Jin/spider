using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float WebShrinkSpeed = 0.1f;
	public float RotationSpeed = 5f;
	public GameObject WebEndPoint;

	private Rigidbody2D body;
	private Transform shotPoint;
	private LineRenderer lineRenderer;
	private GameObject currentWeb;
	private Vector2 direction;
	private FixedJoystick joystick;

	private void Awake()
	{
		body = GetComponent<Rigidbody2D>();
		shotPoint = transform.Find("ShotPoint");
		lineRenderer = GetComponent<LineRenderer>();
		joystick = FindObjectOfType<FixedJoystick>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow) || joystick.Horizontal < 0f) body.SetRotation(body.rotation += RotationSpeed);

		if (Input.GetKey(KeyCode.RightArrow) || joystick.Horizontal > 0f) body.SetRotation(body.rotation -= RotationSpeed);

		if (Input.GetKeyDown(KeyCode.A) || Input.touchCount > 0)
		{
			if (currentWeb == null)
			{
				direction = (Vector2)shotPoint.position - body.position;
				var hit = Physics2D.Raycast(shotPoint.position, direction, float.MaxValue, 1 << LayerMask.NameToLayer("Default"));

				if (hit.collider != null)
				{
					currentWeb = Instantiate(WebEndPoint, hit.point, Quaternion.identity);
					currentWeb.GetComponent<DistanceJoint2D>().connectedBody = body;

					lineRenderer.SetPosition(0, shotPoint.position);
					lineRenderer.SetPosition(1, hit.point);
					lineRenderer.enabled = true;
				}
			}
			else
			{
				lineRenderer.enabled = false;
				Destroy(currentWeb);
			}
		}
	}

	private void FixedUpdate()
	{
		if (currentWeb != null)
		{
			if (currentWeb.GetComponent<DistanceJoint2D>().distance >= 0.5f) currentWeb.GetComponent<DistanceJoint2D>().distance -= WebShrinkSpeed;
			lineRenderer.SetPosition(0, shotPoint.position);
		}
	}
}
