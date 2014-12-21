using UnityEngine;
using System.Collections;

public class PlayerVariables : MonoBehaviour {

    static public PlayerVariables GlobalPlayer = null;

    public Random random = new Random();


    // Accuracy, Min, Max, Decay
    public float[] _Accuracy = { 1f, 0.6f, 1f, 0.04f };
    // ^ How would we go about percents of Angles? ~ James

	void Start () {
	    if (GlobalPlayer == null)
            GlobalPlayer = this;
	}

}
