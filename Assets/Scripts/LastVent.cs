using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastVent : MonoBehaviour
{
    [SerializeField] GameObject closedLastVent;
    [SerializeField] GameObject openLastVent;
    [SerializeField] SpriteRenderer cootsSpriteRenderer;


    private void Start()
    {
        closedLastVent.SetActive(true); 
        openLastVent.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Coots>() != null)
        {
            closedLastVent.SetActive(false);
            openLastVent.SetActive(true);
            cootsSpriteRenderer.enabled = true;
        }
    }
}
