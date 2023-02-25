using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudwigWalkToVent : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //called from a function in the among us animation event
    public void TriggerWalkToDoorAnimation()
    {
        animator.SetTrigger("TriggerWalkToDoor");
    }
}
