using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apron : MonoBehaviour
{
    [SerializeField] GameObject apronHungSprite;
    [SerializeField] GameObject apronCrumpledSprite;

    Animator animator;

    private bool hasFallen;

    private void Start()
    {
        animator = GetComponent<Animator>();
        apronCrumpledSprite.SetActive(false);
    }

    private void Update()
    {
        if(Fan.IsRunning && !hasFallen)
        {
            StartSwingAndFallAnimation();
            hasFallen = true;
        }
    }

    private void StartSwingAndFallAnimation()
    {
        animator.SetTrigger("TriggerSwingAndFall");
    }

    // called from animator
    private void HandleHittingGround()
    {
        apronHungSprite.SetActive(false);
        apronCrumpledSprite.SetActive(true); 
    }
}
