using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool canFall; //if the platform can fall down
    public float timedLife; //the time it takes for the platform to fall
    bool isFalling;
    float timer;

    public bool canRespawn; //if it respawns once it touches a FallBox script
    Vector3 startingPos; //position to respawn to

    Animator animator;

    private void Start()
    {
        if (GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }

        startingPos = transform.position;

        Spawn();
    }

    public void Spawn()
    {
        //set to default settings once (re)spawned
        isFalling = false;

        if (GetComponent<Rigidbody>())
        {
            Destroy(GetComponent<Rigidbody>());
        }
        
        transform.position = startingPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (GetComponent<Animator>())
            {
                animator.SetFloat("speed", 1);
            }
            
            //if the platform can fall, start a timer
            if (canFall)
            {
                timer = timedLife;
                isFalling = true;
                //start shaking
                Camera.main.GetComponent<Animator>().SetBool("IsShaking", true);
            }
            //else attaches the player to the platform so the player will move with the platform
            else
            {
                other.transform.parent = transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.transform.parent = null;
        }
        //end shaking
        Camera.main.GetComponent<Animator>().SetBool("IsShaking", false);
    }

    private void Update()
    {
        //adds a rigidbody to platform so that it will fall
        if (isFalling)
        {
            timer -= Time.deltaTime;

            if (timer <= 0 && gameObject.GetComponent<Rigidbody>() == null)
            {
                gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
