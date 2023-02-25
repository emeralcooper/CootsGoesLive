using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieShelved : MonoBehaviour
{
    [SerializeField] float minSoftLandingXPos = -3.19f;
    [SerializeField] float maxSoftLandingXPos = -1.89f;

    [SerializeField] GameObject apronCrumpled;
    [SerializeField] GameObject apronPuzzle;
    [SerializeField] GameObject pieOnFloor;
    [SerializeField] Coots coots;

    Animator animator;

    private bool isSafeOnFloor;

    private void Start()
    {
        animator = GetComponent<Animator>();
        pieOnFloor.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSafeOnFloor)
            return;

        if (collision.GetComponent<SlapCollider>() != null)            
        {
            if (apronCrumpled.transform.position.x > minSoftLandingXPos && apronCrumpled.transform.position.x < maxSoftLandingXPos)
            {
                Debug.Log("pie will land softly");
                animator.SetTrigger("PieFallSoft");
                isSafeOnFloor = true;
            }

            else
            {
                animator.SetBool("IsPieBreaking", true);
                Debug.Log("pie will break");                
            }
        }

    }

    //called from animation
    private void ResetCootsToTower()
    {
        coots.ResetCootsToTower();
    }

    //called from piebreaking animation
    private void ResetPieBreakAnimation()
    {
        animator.SetBool("IsPieBreaking", false);
    }

    //called from pie soft landing animation
    private void DisableMyselfEnablePieOnFloorDestroyApronPuzzle()
    {
        pieOnFloor.SetActive(true);
        Destroy(apronPuzzle);
        this.gameObject.SetActive(false);
    }
}