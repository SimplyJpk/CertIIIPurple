using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private float mouseSensitivity = 1.4f;
	private Transform playerBase;
	private Transform camera;
	
	void Awake ()
	{
		playerBase = this.transform;
		camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		playerBase.rigidbody.freezeRotation = true;
		Screen.showCursor = false;
	}

	void Update ()
	{
		Vector3 cameraRot = camera.localEulerAngles;
		cameraRot.x += Input.GetAxis ("Mouse Y") * -mouseSensitivity;
		camera.localEulerAngles = cameraRot;
		Vector3 playerRot = playerBase.localEulerAngles;
		playerRot.y += Input.GetAxis ("Mouse X");
		playerBase.localEulerAngles = playerRot;

		Vector3 targetPos = playerBase.position;
		targetPos += playerBase.forward * Input.GetAxis ("Vertical") * 5;
		targetPos += playerBase.right * Input.GetAxis ("Horizontal") * 5;
		transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime);

	}
}
