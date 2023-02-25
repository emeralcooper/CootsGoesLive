using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomHook : MonoBehaviour
{
    public int broomHits;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // this is called from an event inside the swing animation
    private void OpenDoor()
    {
        Door.isDoorOpen = true; 
    }

    public void StartSwingAnimation()
    {
        animator.SetTrigger("TriggerSwing");
    }
}
