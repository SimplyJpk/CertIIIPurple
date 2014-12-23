using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootProto : MonoBehaviour {


	// Update is called once per frame
	public float shootDelay = 0.4f;
	private float timer;
	private GameObject particles;
	private Transform Camera;
	GameObject _obj;
	private GameObject Bullet;
	private List<GameObject> bulletHoles = new List<GameObject> ();

	private int bulletHoleCount = 20;

	void Start ()
	{
		Screen.lockCursor = true;
		particles = Resources.LoadAssetAtPath ("Assets/Lachlan/enemyParticles.prefab", typeof (GameObject)) as GameObject;
		Camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		Bullet = Resources.LoadAssetAtPath ("Assets/Lachlan/BulletHole.prefab", typeof(GameObject)) as GameObject;
	}

	void Awake ()
	{
		timer = shootDelay;
	}
	void Update () 
	{
		timer -= Time.deltaTime;
		if (timer < 0 && Input.GetMouseButtonDown (0))
		{
			timer = shootDelay;
			Ray ray = new Ray (Camera.position, Camera.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
			{
				GameObject explosion = Instantiate (particles, hit.point, Quaternion.identity) as GameObject;
				Destroy (explosion, 3);

				if (hit.collider.gameObject.tag == "Target")
				{
					hit.collider.gameObject.rigidbody.AddForceAtPosition(Vector3.forward * 5, hit.point, ForceMode.Impulse);
					if (hit.collider.transform.parent)
						Destroy(hit.collider.transform.parent.gameObject,1);
					else 
						Destroy (hit.collider.gameObject);
				}
				Quaternion rotation = Quaternion.FromToRotation (Vector3.up, hit.normal);
				GameObject bulletHole = Instantiate (Bullet, hit.point, rotation) as GameObject;
				bulletHoles.Add (bulletHole);
				bulletHole.transform.parent = hit.collider.transform;
				bulletHole.transform.position += (bulletHole.transform.up * 0.01f);
			}
			DestroyHoles ();

		}


	}

	private void DestroyHoles ()
	{
		if (bulletHoles.Count > bulletHoleCount)
		{
			if (bulletHoles[0])
			{
				Destroy (bulletHoles[0]);
				bulletHoles.RemoveAt (0);
			}
		}
		else
			return;

	}



}
