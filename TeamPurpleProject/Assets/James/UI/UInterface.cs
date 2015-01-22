using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UInterface : MonoBehaviour {
    // Player
    public GameObject player;
    public Image img_Crosshair;

    // Canvas
    public Text txt_Clip;
    public Text txt_Ammo;
    public Text txt_Score;

    public Image img_Time;
    public Image img2_Time;
    public Image img3_Time;
    public Text txt_Time;

    public Image img_Clip;
    public Image img_ClipRed;

    // Game Over UI
    public Text txt_GG;
    public Text txtReturn_GG;
    public Image panel_GG;
    public Image panel2_GG;

    void Update()
    {
        txt_Clip.text = player.GetComponent<PlayerProto_Test>().clip.ToString() + "/" + player.GetComponent<PlayerProto_Test>().clipSize.ToString();
        txt_Ammo.text = player.GetComponent<PlayerProto_Test>().ammo.ToString();
        txt_Score.text = ScoreReturn(player.GetComponent<PlayerProto_Test>().score.ToString());
        txt_Time.text = TimerReturn(player.GetComponent<PlayerProto_Test>()._GameTimer);
        
        if (GameObject.Find("Player").GetComponent<PlayerProto_Test>()._reloading)
        {
            img_ClipRed.canvasRenderer.SetAlpha(1f);
        }
        else
        {
            img_ClipRed.canvasRenderer.SetAlpha(0);
        }

        if (player.GetComponent<PlayerProto_Test>()._GameOver == true)
        {
            panel_GG.canvasRenderer.SetAlpha(1f);
            panel2_GG.canvasRenderer.SetAlpha(0.5f);
            txt_GG.canvasRenderer.SetAlpha(1f);
            txtReturn_GG.canvasRenderer.SetAlpha(1f);

            if (player.GetComponent<PlayerProto_Test>().TargetCount == 0)
            {
                txt_GG.text = "Congratulations You Killed " + player.GetComponent<PlayerProto_Test>().score + " Targets!";
            }
            else
            {
                txt_GG.text = "You Killed " + player.GetComponent<PlayerProto_Test>().score + " Out of " + player.GetComponent<PlayerProto_Test>().TargetCount;
            }
            // Remove Crosshair
            img_Crosshair.canvasRenderer.SetAlpha(0);
        }
        else
        {
            if (player.GetComponent<PlayerProto_Test>().TargetCount >= 1)
            {
                img_Time.canvasRenderer.SetAlpha(0);
                img2_Time.canvasRenderer.SetAlpha(0);
                img3_Time.canvasRenderer.SetAlpha(0);
                txt_Time.canvasRenderer.SetAlpha(0);
            }
            else
            {
                img_Time.canvasRenderer.SetAlpha(0.9f);
                img2_Time.canvasRenderer.SetAlpha(0.8f);
                img3_Time.canvasRenderer.SetAlpha(0.5f);
                txt_Time.canvasRenderer.SetAlpha(1f);
            }
            panel_GG.canvasRenderer.SetAlpha(0);
            panel2_GG.canvasRenderer.SetAlpha(0);
            txt_GG.canvasRenderer.SetAlpha(0);
            txtReturn_GG.canvasRenderer.SetAlpha(0);
            txt_GG.text = "";

            // Make Crosshair Visible
            img_Crosshair.canvasRenderer.SetAlpha(1f);
        }
    }

    string TimerReturn(float input)
    {
        string returnedString;
        float minutes = Mathf.Floor(input / 60);
        float seconds = Mathf.RoundToInt(input % 60);
        if (minutes.ToString().Length == 1)
        {
            returnedString = "0" + minutes + ":";
        }
        else { returnedString = minutes.ToString(); }
        if (seconds.ToString().Length == 1)
        {
            returnedString += "0" + seconds;
        }
        else { returnedString += seconds; }
        return returnedString;
    }

    string ScoreReturn(string score)
    {
        while (score.Length < 5)
        {
            score = 0 + score;
        }
        return score;
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
