using UnityEngine;
using System.Collections;

public class TargetSpawner_Test : MonoBehaviour
{

    public GameObject target;
    public float time;

    void Update()
    {
        if (time > 0) time -= Time.deltaTime;
        if (time < 0)
        {
            Instantiate(target, transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
