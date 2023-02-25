using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] GameObject cactusWhole;
    [SerializeField] GameObject cactusCut;
    [SerializeField] Coots coots;
    [SerializeField] GameObject cactusBlockingCollider;

    private bool isCut;

    private void Start()
    {
        cactusWhole.SetActive(true);
        cactusCut.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("cactus trigger entered");

        if ( coots.HasScissors && !isCut && collision.GetComponent<SlapCollider>() != null)
        {
            isCut = true;
            Debug.Log("slapped cactus");
            CutCactus();
            Destroy(cactusBlockingCollider);
        }
    }

    public void CutCactus()
    {
        cactusWhole.SetActive(false);
        cactusCut.SetActive(true);
    }

}
