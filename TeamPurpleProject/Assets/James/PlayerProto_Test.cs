using UnityEngine;
using System.Collections;

public class PlayerProto_Test : MonoBehaviour
{
    // Update is called once per frame
    public float shootDelay = 0.4f;
    private float timer;
    private GameObject particles;
    private Transform Camera;
    GameObject _obj;

    void Start()
    {
        Screen.lockCursor = true;
        particles = Resources.LoadAssetAtPath("Assets/Lachlan/enemyParticles.prefab", typeof(GameObject)) as GameObject;
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;



    }

    void Awake()
    {
        timer = shootDelay;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && Input.GetMouseButtonDown(0))
        {
            timer = shootDelay;
            Ray ray = new Ray(Camera.position, Camera.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject explosion = Instantiate(particles, hit.point, Quaternion.identity) as GameObject;
                Destroy(explosion, 3);

                if (hit.collider.gameObject.tag == "Target")
                {

                    hit.collider.gameObject.rigidbody.AddForceAtPosition(Vector3.forward * 5, hit.point, ForceMode.Impulse);
                    Destroy(hit.collider.transform.parent.gameObject, 1);

                }


            }

        }

    }
}
