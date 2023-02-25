using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmongUsPuzzle : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] LudwigWalkToVent ludwigWalkToVent;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Coots>() != null)
        {
            animator.SetTrigger("TriggerShelfFall");
        }
    }

    // called within shelf fall animation
    private void CloseDoor()
    {
        Door.isDoorOpen = false;
        ludwigWalkToVent.TriggerWalkToDoorAnimation();
    }

    

}
