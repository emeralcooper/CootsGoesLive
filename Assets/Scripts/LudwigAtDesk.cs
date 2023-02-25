using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudwigAtDesk : MonoBehaviour
{
    [SerializeField] float delayToResetCoots;

    [SerializeField] Coots coots;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!coots.IsInBowl)
        {
            if(collision.GetComponent<Coots>() != null)
            {
                Debug.Log("trigger look behind animation");
                animator.SetBool("IsLookingBehind", true);
                coots.DisableInput();
                Debug.Log("Ludwig at desk disabled input!");
            }
        }        
    }


    //called from animation
    private void ResetCootsAndAnimationTriggerWithDelay()
    {
        Invoke("ResetCootsAndIsLookingBehind", delayToResetCoots);
    }

    private void ResetCootsAndIsLookingBehind()
    {
        coots.ResetCootsToTower();
        Invoke("ResetMyAnimation", 1f);
    }

    private void ResetMyAnimation()
    {
        animator.SetBool("IsLookingBehind", false);
    }

}
