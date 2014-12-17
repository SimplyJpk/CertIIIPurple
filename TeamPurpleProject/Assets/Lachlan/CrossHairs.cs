using UnityEngine;
using System.Collections;

public class CrossHairs : MonoBehaviour {
		
	public Texture2D crossHairs;

	void OnGUI ()
	{
			GUI.DrawTexture (new Rect (Screen.width / 2 - 25, Screen.height / 2 - 25, 50, 50), crossHairs);
	}
}
