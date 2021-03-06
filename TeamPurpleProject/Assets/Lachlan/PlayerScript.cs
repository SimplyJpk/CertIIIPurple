﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private float mouseSensitivity = 1.4f;
	private Transform playerBase;
	private Transform Camera;

	public Animator anim;
	void Awake ()
	{		
		Screen.lockCursor = true;
		playerBase = this.transform;
		Camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		playerBase.rigidbody.freezeRotation = true;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Screen.lockCursor = false;
		Vector3 cameraRot = Camera.localEulerAngles;
		cameraRot.x += Input.GetAxis ("Mouse Y") * -mouseSensitivity;
		Camera.localEulerAngles = cameraRot;
		Vector3 playerRot = playerBase.localEulerAngles;
		playerRot.y += Input.GetAxis ("Mouse X") * mouseSensitivity;
		playerBase.localEulerAngles = playerRot;

		Vector3 targetPos = playerBase.position;
		targetPos += playerBase.forward * Input.GetAxis ("Vertical") * 5;
		targetPos += playerBase.right * Input.GetAxis ("Horizontal") * 5;
		transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime);

		if (Input.GetAxis ("Vertical") > 0 && Input.GetKey (KeyCode.LeftShift))
			anim.SetBool ("Sprinting", true);
		else
			anim.SetBool ("Sprinting", false);

	}
}
