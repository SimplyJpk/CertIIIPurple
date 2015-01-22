using UnityEngine;
using System.Collections;

public class TargetAdd : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Player").GetComponent<PlayerProto_Test>().SpawnedTargets.Add(gameObject); // Add NewTarget to Spawned Targets (FLAWED SYSTEM) ~ Jpk
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
