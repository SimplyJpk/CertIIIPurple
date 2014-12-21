using UnityEngine;
using System.Collections;

public class PlayerScript_Test : MonoBehaviour
{

	private float mouseSensitivity = 1.4f;
	private Transform playerBase;
	private Transform Camera;

    // Speed, NormSpeed, MaxSpeed, Decay
    private float[] playerSpeed = { 5f, 5f, 8f, 2f };
	
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
        CheckRun();

		Vector3 cameraRot = Camera.localEulerAngles;
		cameraRot.x += Input.GetAxis ("Mouse Y") * -mouseSensitivity;
		Camera.localEulerAngles = cameraRot;
		Vector3 playerRot = playerBase.localEulerAngles;
		playerRot.y += Input.GetAxis ("Mouse X") * mouseSensitivity;
		playerBase.localEulerAngles = playerRot;

		Vector3 targetPos = playerBase.position;
        targetPos += playerBase.forward * Input.GetAxis("Vertical") * playerSpeed[0];
        targetPos += playerBase.right * Input.GetAxis("Horizontal") * playerSpeed[0];
		transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime);

	}

    void CheckRun()
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerSpeed[0] < playerSpeed[2])
            playerSpeed[0] += playerSpeed[3] * Time.deltaTime * 2;
        else if (playerSpeed[0] > playerSpeed[1] && !Input.GetKey(KeyCode.LeftShift))
            playerSpeed[0] -= playerSpeed[3] * Time.deltaTime;
        else if (playerSpeed[0] < playerSpeed[1] && !Input.GetKey(KeyCode.LeftShift))
            playerSpeed[0] = playerSpeed[1];
        Debug.Log(playerSpeed[0]);
    }
}
