using UnityEngine;
using System.Collections;

public class TargetSpawner_Test : MonoBehaviour
{

    public GameObject target;

    public float time;
    public float counter = 0.5f;
    public int _despawn = 5;

    void Update()
    {
        if (time > 0) time -= Time.deltaTime;
        if (time < 0)
        {
            GameObject newTarget = Instantiate(target, transform.position, Quaternion.identity) as GameObject;
            newTarget.transform.SetParent(transform);
            Destroy(newTarget, _despawn);
            counter = _despawn;
            time = 0;
        }

        if (counter > 0.5f) counter -= Time.deltaTime;
        if (counter < 0.5f)
        {
            counter = 0.5f;
            if (transform.childCount > 0)
            {
                transform.FindChild("target_edit(Clone)").rigidbody.AddForce(-transform.forward * 10, ForceMode.Impulse);
            }
        }
    }
}
