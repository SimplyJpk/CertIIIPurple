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

    public float spread = 0.06f;
    public float spreadMin = 0.06f;
    public float SpreadMax = 0.2f;


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

        timer -= Time.deltaTime;
        if (timer < 0 && Input.GetMouseButtonDown(0))
        if (timer > 0) timer -= Time.deltaTime;
        if (spread > spreadMin) spread -= 0.5f * Time.deltaTime; // Spread Regen/Decay (the 0.5f) should probably be a variable, More so if using more than 1 gun. ~ Jpk
        else if (spread < spreadMin) spread = spreadMin;

        CheckInput();

        if (timer < 0 && Input.GetMouseButtonDown(0) && _reloading == false)
        {
            timer = shootDelay;
            if (clip > 0)
            {
                clip--;
                Vector3 _point = camera.forward; // Makes it so math is based on Point of aim not just of 'z' ~ Jpk
                Vector3 _sphere = Random.insideUnitCircle * spread; // Makes a sphere point? Not sure. But it does what i want c: ~ Jpk
                _point += _sphere.y * (Random.value - 0.5f) * camera.up; // Add's a random value in the Y axis of that Sphere Point ~ Jpk
                _point += _sphere.x * (Random.value - 0.5f) * camera.right; // Same with the X ~ Jpk

                spread = SpreadMax; // Make aiming a bit harder ~ Jpk
                Ray ray = new Ray(camera.position, _point);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.DrawLine(camera.position, hit.point, Color.red, 10f); // Debug ~ Jpk Draws lines (Bullet Path)

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
        //Debug.Log(timer); // Debug
        Debug.Log("Spread: " + spread);
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
            spread = SpreadMax / 2; // Slight aim disadvantage, current vals would mean this lasts fractions of a second ~ Jpk (could always remove)
            Debug.Log("Reloading Finished"); // Debug
        }
    }
}
