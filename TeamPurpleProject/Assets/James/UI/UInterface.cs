using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UInterface : MonoBehaviour {
    public Text txt_clip;
    public Text txt_ammo;

    public Image img_clip;
    public Image img_clipRed;
    public Image img_ammo;

    public GameObject player;


    void Update()
    {
        txt_clip.text = player.GetComponent<PlayerProto_Test>().clip.ToString() + "/" + player.GetComponent<PlayerProto_Test>().clipSize.ToString();
        txt_ammo.text = player.GetComponent<PlayerProto_Test>().ammo.ToString();
        if (GameObject.Find("Player").GetComponent<PlayerProto_Test>()._reloading)
        {
            img_clipRed.canvasRenderer.SetAlpha(255);
        }
        else
        {
            img_clipRed.canvasRenderer.SetAlpha(0);

        }
    }

    void OnGUI()
    {
    //  GUI.Label(new Rect(0, 0, 100, 30), "Ammo: " + GameObject.Find("Player").GetComponent<PlayerProto_Test>().ammo);
    //  GUI.Label(new Rect(0, 30, 100, 30), "Clip: " + GameObject.Find("Player").GetComponent<PlayerProto_Test>().clip);
    //    if (GameObject.Find("Player").GetComponent<PlayerProto_Test>()._reloading)
    //    {
    //        img_clip = Resources.LoadAssetAtPath("Assets/James/UI/Hud/ClipRed_tmp", typeof(Image)) as Image;
    //    }
    }
}
