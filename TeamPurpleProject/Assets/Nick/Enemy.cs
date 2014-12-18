using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	/*bool moveRight = false;

	float timer = 0.5f;
	float delay = 2.0f;*/

	void Update()
	{
		transform.Translate(Vector3.right);
		/*timer -= Time.deltaTime;

		if (timer <= 0) {
			timer = delay;
			moveRight = !moveRight;
		}
		if (moveRight == false)
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		else
			transform.Translate (speed * Time.deltaTime, 0, 0 );
			*/
	}




}
