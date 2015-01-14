using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	public Texture2D scene1Tex;
	void OnGUI ()
	{
		GUI.Window (0, new Rect (0, 0, Screen.width, Screen.height), WindowLayout, "Menu");

	}

	void WindowLayout (int ID)
	{
		float XOffset = (Screen.width / 4);
		float YOffset = (Screen.height / 4);
		GUI.DrawTexture (new Rect (XOffset - 80, YOffset + 80, 160, 160), scene1Tex);
		GUI.DrawTexture (new Rect ((XOffset * 2) - 80, YOffset + 80, 160, 160), scene1Tex);
		GUI.DrawTexture (new Rect ((XOffset * 3) - 80, YOffset + 80, 160, 160), scene1Tex);

		if (GUI.Button (new Rect (XOffset- 32, YOffset + 250, 64, 48), "Level 1"))
			Application.LoadLevel (1);
		if (GUI.Button (new Rect ((XOffset * 2) - 32, YOffset + 250, 64, 48), "Level 2"))
			Application.LoadLevel (2);
		if (GUI.Button (new Rect ((XOffset  * 3) - 32, YOffset + 250, 64, 48), "Level 3"))
			Application.LoadLevel (3);
		
	}

}
