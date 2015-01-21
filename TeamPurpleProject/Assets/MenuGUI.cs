using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	public Texture2D scene1Tex;
	public Texture2D scene2Tex;
	public Texture2D scene3Tex;
	public Texture2D titleTex;
	public Texture2D infoTex;

	void OnGUI ()
	{
		GUI.backgroundColor = Color.black;
		GUI.Window (0, new Rect (0, 0, Screen.width, Screen.height), WindowLayout, "Menu");
	}

	void WindowLayout (int ID)
	{
		float XOffset = (Screen.width / 4);
		float YOffset = (Screen.height / 2);
		GUI.DrawTexture (new Rect ((XOffset * 2) - (infoTex.width / 2), Screen.height - infoTex.height, infoTex.width, infoTex.height), infoTex);
		GUI.DrawTexture (new Rect (XOffset * 2 - (titleTex.width / 2), 20, titleTex.width, titleTex.height), titleTex);

		GUI.DrawTexture (new Rect (XOffset - 130, YOffset - 180, 260, 260), scene1Tex);
		GUI.DrawTexture (new Rect ((XOffset * 2) - 130, YOffset - 180, 260, 260), scene2Tex);
		GUI.DrawTexture (new Rect ((XOffset * 3) - 130, YOffset - 180, 260, 260), scene3Tex);

		if (GUI.Button (new Rect (XOffset- 32, YOffset + 110, 64, 48), "Level 1"))
			Application.LoadLevel (1);
		if (GUI.Button (new Rect ((XOffset * 2) - 32, YOffset + 110, 64, 48), "Level 2"))
			Application.LoadLevel (2);
		if (GUI.Button (new Rect ((XOffset  * 3) - 32, YOffset + 110, 64, 48), "Level 3"))
			Application.LoadLevel (3);
		
	}

}
