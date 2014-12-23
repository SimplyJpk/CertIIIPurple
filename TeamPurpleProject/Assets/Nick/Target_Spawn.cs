using UnityEngine;
using System.Collections;

public class Target_Spawn : MonoBehaviour {

	public GameObject target;
	float time;
	public float spawn;
	public float spawnTime;

	// Use this for initialization
	void Start () {
		time = Random.Range(spawn, spawnTime);

	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if ( time < 0)
		{
			Instantiate (target, this.transform.position, Quaternion.identity);
			Destroy (this);
		}
	
	}
}
