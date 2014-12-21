using UnityEngine;
using System.Collections;

public class target : MonoBehaviour
{
    public float speed;
    public bool moveRight = false;
    public bool randRight = false;

    public float timerMax = 1f;
    private float timer = 1f;
    // Use this for initialization
    void Start()
    {
        timer = timerMax /2;
        if (randRight)
        {
            moveRight = Random.value > 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = timerMax;
            moveRight = !moveRight;
        }

        if (moveRight == false)
            transform.Translate(-transform.right * Time.deltaTime);
        else
            transform.Translate(transform.right * Time.deltaTime);
    }
}
