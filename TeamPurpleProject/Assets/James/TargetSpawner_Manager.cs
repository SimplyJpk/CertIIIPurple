using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetSpawner_Manager : MonoBehaviour {

    float time = 2f;

    int targetcounter;

    List<GameObject> _spawners = new List<GameObject>();

    void Start()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("TargetSpawner"))
        {
            _spawners.Add(gameObj);
        }
    }

	void Update () {
        if (time > 0)
        {
            time -= Time.deltaTime;
            targetcounter = 0;
            for (int i = 0; i < _spawners.Count; i++)
            {
                if (_spawners[i].transform.childCount != 0)
                {
                    targetcounter++;
                }
            }
        }
        else
        {
            time = 0.5f;
            if (targetcounter <= 2)
            {
                for (int i = 0; i < _spawners.Count; i++)
                {
                    if (_spawners[i].transform.childCount == 0)
                    {
                        if (Random.Range(0, 10) <= 0)
                        {
                            _spawners[i].GetComponent<TargetSpawner_Test>().time = 0.45f;
                        }
                    }
                }
            }
        }


        Debug.Log("Target Count: " + targetcounter);
	}
}
