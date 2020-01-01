using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScrolling : MonoBehaviour
{
	public float panSpeed = 1f;
	private Vector3 mouseOrigin, prevPos;

	// Update is called once per frame
    void LateUpdate()
    {
		Vector3 pos = transform.position;

		if(Input.GetMouseButtonDown(0))
		{
			//Left click pressed
			mouseOrigin = Input.mousePosition;
		}

		if(Input.GetMouseButton(0))
		{
			//Left click held
			Vector3 mousePos = Input.mousePosition;
			Vector3 temp = Camera.main.ScreenToViewportPoint(new Vector3(mousePos.x - mouseOrigin.x, mousePos.y - mouseOrigin.y, pos.z));
			Vector3 move = new Vector3(-temp.x * panSpeed, -temp.y * panSpeed, 0);
			Camera.main.transform.Translate(move, Space.Self);

			if(mousePos == prevPos)
			{
				mouseOrigin = mousePos;
			}
			prevPos = mousePos;
		}
    }
}
