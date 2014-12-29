using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UInterface : MonoBehaviour {

   void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 30), "Ammo: " + GameObject.Find("Player").GetComponent<PlayerProto_Test>().ammo);
        GUI.Label(new Rect(0, 30, 100, 30), "Clip: " + GameObject.Find("Player").GetComponent<PlayerProto_Test>().clip);
      if (GameObject.Find("Player").GetComponent<PlayerProto_Test>()._reloading)
      {
          GUI.Label(new Rect(0, 50, 100, 30), "Reloading");
      }
    }
}
