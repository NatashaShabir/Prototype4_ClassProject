using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool canFall;
    public float timedLife;
    public bool canRespawn;

    Vector3 startingPos;
    bool isFalling;
    
    float timer;

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
        isFalling = false;
        Destroy(GetComponent<Rigidbody>());
        transform.position = startingPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        //turn on gravity for platform if the platform can fall;
        if (other.GetComponent<Player>())
        {
            if (GetComponent<Animator>())
            {
                animator.SetFloat("speed", 1);
            }
            
            if (canFall)
            {
                timer = timedLife;
                isFalling = true;
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
    }

    private void Update()
    {
        if (isFalling)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
