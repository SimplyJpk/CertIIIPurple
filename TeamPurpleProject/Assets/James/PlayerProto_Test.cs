using UnityEngine;
using System.Collections;

public class PlayerProto_Test : MonoBehaviour
{
    // Update is called once per frame
    public float shootDelay = 0.4f;
    private float timer;
    private GameObject particles;
    private Transform camera;
    GameObject _obj;


    public bool _reloading = false;

    public int clip = 0;
    public int clipSize = 7;
    public int ammo = 17;

    void Start()
    {
        Screen.lockCursor = true;
        particles = Resources.LoadAssetAtPath("Assets/Lachlan/enemyParticles.prefab", typeof(GameObject)) as GameObject;
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Awake()
    {
        timer = shootDelay;
    }
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        
       CheckInput();

        if (timer < 0 && Input.GetMouseButtonDown(0) && _reloading == false)
        {
            timer = shootDelay;
            if (clip > 0)
            {
                clip--;
                Ray ray = new Ray(camera.position, camera.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject explosion = Instantiate(particles, hit.point, Quaternion.identity) as GameObject;
                    Destroy(explosion, 3);

                    if (hit.collider.gameObject.tag == "Target")
                    {

                        hit.collider.gameObject.rigidbody.AddForceAtPosition(camera.transform.forward * 5, hit.point, ForceMode.Impulse);
                        Destroy(hit.collider.transform.parent.gameObject, 1);

                    }



                }
            }

        }
        Debug.Log(timer);
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.R) && _reloading == false)
        {
            Debug.Log("Reloading Started");
            timer = 2f;
            _reloading = true;
        }
        else if (_reloading == true && timer <= 0)
        {
            if (ammo < 7)
            {
                clip = ammo;
                ammo = 0;
            }
            else
            {
                clip = clipSize;
                ammo -= clipSize;
            }
            _reloading = false;
            Debug.Log("Reloading Finished");
        }
    }
}
