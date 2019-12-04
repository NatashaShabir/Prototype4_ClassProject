using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        TestDavid.Shrink += Shrink;
        TestDavid.Grow += Grow;
        TestDavid.Pause += Pause;
        
    }

    private void OnDisable()
    {
        TestDavid.Shrink -= Shrink;
        TestDavid.Grow -= Grow;
        TestDavid.Pause -= Pause;
    }

    void Shrink()
    {
        animator.SetFloat("speed", 1);
    }

    void Grow()
    {
        animator.SetFloat("speed", -1);
    }

    void Pause()
    {
        animator.SetFloat("speed", 0);
    }
}
