using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBowlFloor : MonoBehaviour
{
    [SerializeField] SpriteRenderer cootsRenderer;
    [SerializeField] Transform cootsBowlRoot;
    [SerializeField] Coots coots;

    private bool isCootsInBowl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Coots>() != null)
        {
            cootsRenderer.enabled = false;
            isCootsInBowl = true;
            coots.IsInBowl = true;
        }
    }

    private void Update()
    {
        if (isCootsInBowl)
        {
            transform.position = cootsBowlRoot.position;
        }
    }
}
