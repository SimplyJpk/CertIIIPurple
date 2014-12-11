using UnityEngine;
using System.Collections;

public class Target_Animate : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetTrigger ("Target_Animate");
	}
}
