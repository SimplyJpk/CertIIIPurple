using UnityEngine;
using System.Collections;

public class ShootProto : MonoBehaviour {
	
	// Update is called once per frame
	public float shootDelay = 0.4f;
	private float timer;
	private GameObject particles;

	void Start ()
	{
		Screen.showCursor = false;
		particles = Resources.LoadAssetAtPath ("Assets/Lachlan/enemyParticles.prefab", typeof (GameObject)) as GameObject;
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
			Ray ray = new Ray (this.transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
			{
				GameObject explosion = Instantiate (particles, hit.point, Quaternion.identity) as GameObject;
				Destroy (explosion, 3);
			}
		}
	}
}
