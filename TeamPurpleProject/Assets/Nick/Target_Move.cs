using UnityEngine;
using System.Collections;

public class Target_Move : MonoBehaviour {

	public float speed;
	bool moveRight = false;
	
	float timer = 1f;
	float delay = 2.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
				
		if (timer <= 0) {
			timer = delay;
			moveRight = !moveRight;
		}
		if (moveRight == false)
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		else
			transform.Translate (speed * Time.deltaTime, 0, 0 );
	}
}
