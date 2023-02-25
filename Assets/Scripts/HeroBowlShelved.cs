using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBowlShelved : MonoBehaviour
{
    [SerializeField] float minSoftLandingXPos = -13.13f;
    [SerializeField] float maxSoftLandingXPos = -11.78f;

    [SerializeField] GameObject heroBowlFloor;
    [SerializeField] Sink sink;
    [SerializeField] GameObject apronCrumpled;
    [SerializeField] GameObject apronPuzzle;
    [SerializeField] Coots coots;

    Animator animator;
    SpriteRenderer spriteRenderer;
    private int cachedSortOrder;

    private bool isOnCounter;
    private bool isOnFloor;

    private void Start()
    {
        animator = GetComponent<Animator>();
        heroBowlFloor.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        cachedSortOrder = spriteRenderer.sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOnFloor)
            return;

        if (!isOnCounter)
        {
            if (collision.GetComponent<SlapCollider>() != null)
            {

                if (sink.IsSinkOn)
                {
                    Debug.Log("trigger float animation");
                    animator.SetTrigger("TriggerFloat");
                }

                else if (!sink.IsSinkOn)
                {
                    Debug.Log("trigger break animation");
                    animator.SetBool("IsBreaking", true);
                }
            }
        }

        else if (isOnCounter)
        {
            if(apronCrumpled.transform.position.x > minSoftLandingXPos && apronCrumpled.transform.position.x < maxSoftLandingXPos)
            {
                if (collision.GetComponent<SlapCollider>() != null || collision.GetComponent<Coots>() != null)
                {
                    Debug.Log("bowl will land softly");
                    animator.SetTrigger("TriggerSoftOnFloor");
                    isOnFloor = true;
                }                    
            }

            else if (collision.GetComponent<SlapCollider>() != null || collision.GetComponent<Coots>() != null)
            {
                Debug.Log("bowl will break and reset");
                animator.SetBool("IsBreakOnFloor", true);
            }
        }
       
    }

    //called from animation
    private void ResetCootsToTower()
    {
        coots.ResetCootsToTower();
    }

    //Called from Animation
    private void DestroyApronPuzzle()
    {
        Destroy(apronPuzzle, 2f);
    }


    //called from animation
    private void ResetBowlBreak()
    {
        animator.SetBool("IsBreaking", false);
        spriteRenderer.sortingOrder = cachedSortOrder;
    }

    //called from animation
    private void SetIsOnCounterToTrue()
    {
        isOnCounter = true;
    }

    //called from animation
    private void ResetBowlBreakOnFloor()
    {
        animator.SetBool("IsBreakOnFloor", false);
        isOnCounter = false;
        spriteRenderer.sortingOrder = cachedSortOrder;
    }

    //called from animation
    private void ActivateFloorBowlDestroyShelfBowl()
    {
        heroBowlFloor.SetActive(true);
        Destroy(this.gameObject, .1f); 
    }

    //called from animation
    private void SetSortOrderToTen()
    {
        spriteRenderer.sortingOrder = 10;
    }
}
