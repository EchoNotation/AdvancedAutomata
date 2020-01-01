using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScrolling : MonoBehaviour
{
	private Plane groundPlane;
	private Vector3 clickPos;
	private Camera mainCamera;
	public float xHigh, xLow, yHigh, yLow;

	void Start()
	{
		groundPlane = new Plane(new Vector3(0, 0, 1), 0);
		mainCamera = Camera.main;
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0)) {
			clickPos = getMousePointOnGround();
		}
		else if(Input.GetMouseButton(0)) {
			Vector3 delta = getMousePointOnGround() - clickPos;

			float tempX, tempY;
			tempX = delta.x;
			tempY = delta.y;
	
			transform.position -= new Vector3(tempX, tempY, 0);			
		}
	}

	private Vector3 getMousePointOnGround() {
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

		if(groundPlane.Raycast(ray, out float distToGround)) {
			return ray.GetPoint(distToGround);
		}

		return clickPos;
	}
}
