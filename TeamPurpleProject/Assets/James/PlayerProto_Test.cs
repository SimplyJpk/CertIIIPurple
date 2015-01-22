using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProto_Test : MonoBehaviour
{
    // Update is called once per frame
    public float shootDelay = 0.4f;
    private float timer;
    private GameObject particles;
    private Transform camera;

    public GameObject Bullet;
    private List<GameObject> bulletHoles = new List<GameObject>();


    private int bulletHoleCount = 20;

    public Animator anim;

    public int score = 0;

    public bool _reloading = false;

    public int clip = 0;
    public int clipSize = 7;
    public int ammo = 17;

    public float spread = 0.06f;
    public float spreadMin = 0.06f;
    public float SpreadMax = 0.2f;

    public float _GameTimer = 60;
    public bool _GameOver = false;

    public int TargetCount;
    public List<GameObject> SpawnedTargets = new List<GameObject>();
    public int TargetsDespawned;

    void Start()
    {
        Screen.lockCursor = true;
        if (!particles)
            particles = Resources.LoadAssetAtPath("Assets/Lachlan/enemyParticles.prefab", typeof(GameObject)) as GameObject;
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        if (!Bullet)
            Bullet = Resources.LoadAssetAtPath("Assets/Lachlan/BulletHole.prefab", typeof(GameObject)) as GameObject;
    }

    void Awake()
    {
        timer = shootDelay;
    }
    void Update()
    {
        if (_GameOver == false)
        {
            if (TargetCount == 0)
            {
                _GameTimer -= Time.deltaTime;
                if (_GameTimer <= 0) _GameOver = true;
            }
            else
            {
                if (TargetsDespawned >= TargetCount) _GameOver = true;
                for (int i = SpawnedTargets.Count-1; i >= 0; i--)
                {
                    try
                    {
                        if (SpawnedTargets[i].tag != "Target")
                        { }
                    } 
                    catch
                    {
                        SpawnedTargets.RemoveAt(i);
                        TargetsDespawned++;
                        Debug.Log(TargetsDespawned);
                    }
                }
            }

            if (timer > 0) timer -= Time.deltaTime;
            if (spread > spreadMin) spread -= 0.5f * Time.deltaTime; // Spread Regen/Decay (the 0.5f) should probably be a variable, More so if using more than 1 gun. ~ Jpk
            else if (spread < spreadMin) spread = spreadMin;

            CheckInput();

            if (timer <= 0 && Input.GetMouseButtonDown(0) && _reloading == false)
            {
                timer = shootDelay;
                if (clip > 0)
                {
                    clip--;
                    anim.SetTrigger("Firing");

                    Vector3 _point = camera.forward; // Makes it so math is based on Point of aim not just of 'z' ~ Jpk
                    Vector3 _sphere = Random.insideUnitCircle * spread; // Makes a sphere point? Not sure. But it does what i want c: ~ Jpk
                    _point += _sphere.y * (Random.value - 0.5f) * camera.up; // Add's a random value in the Y axis of that Sphere Point ~ Jpk
                    _point += _sphere.x * (Random.value - 0.5f) * camera.right; // Same with the X ~ Jpk

                    spread = SpreadMax; // Make aiming a bit harder ~ Jpk

                    Ray ray = new Ray(camera.position, _point);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit) && !Input.GetKey(KeyCode.LeftShift))
                    {
                        //Debug.DrawLine(camera.position, hit.point, Color.red, 10f); // Debug ~ Jpk Draws lines (Bullet Path)

                        GameObject explosion = Instantiate(particles, hit.point, Quaternion.identity) as GameObject;
                        Destroy(explosion, 3);

                        if (hit.collider.gameObject.tag == "Target")
                        {
                            hit.collider.gameObject.rigidbody.AddForceAtPosition(Vector3.forward * 5, hit.point, ForceMode.Impulse);
                            if (hit.collider.transform.parent)
                                Destroy(hit.collider.transform.parent.gameObject, 1);
                            else
                                Destroy(hit.collider.gameObject);
                            score += CheckHit();
                            ammo++; // If they hit the Target, Reward with 1 Ammo ~ Jpk
                        }
                        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                        GameObject bulletHole = Instantiate(Bullet, hit.point, rotation) as GameObject;
                        bulletHoles.Add(bulletHole);
                        bulletHole.transform.parent = hit.collider.transform;
                        bulletHole.transform.position += (bulletHole.transform.up * 0.01f);
                    }
                    DestroyHoles();
                }
            }
            //Debug.Log(timer); // Debug
            Debug.Log("Spread: " + spread);
        }
        else
        {
            _GameTimer = 0;
            if (Input.GetMouseButtonDown(1))
            {
            //    Application.LoadLevel(0);
            }
        }
    }

    int CheckHit()
    {
        return 1;
    }

    private void DestroyHoles()
    {
        if (bulletHoles.Count > bulletHoleCount)
        {
            if (bulletHoles[0])
            {
                Destroy(bulletHoles[0]);
                bulletHoles.RemoveAt(0);
            }
        }
        else
            return;
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.R) && _reloading == false)
        {
            Debug.Log("Reloading Started"); // Debug
            timer = 2f;
            _reloading = true;
        }
        else if (_reloading == true && timer <= 0)
        {
            if (ammo + clip < 7)
            {
                clip += ammo;
                ammo = 0;
            }
            else
            {
                ammo -= clipSize - clip;
                clip = clipSize;
            }
            _reloading = false;
            spread = SpreadMax / 2; // Slight aim disadvantage, current vals would mean this lasts fractions of a second ~ Jpk (could always remove)
            Debug.Log("Reloading Finished"); // Debug
        }
    }
}
