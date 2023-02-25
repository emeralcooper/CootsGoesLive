using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBowlCollider : MonoBehaviour
{
    [SerializeField] GameObject bowlPuzzle;
    [SerializeField] SpriteRenderer cootsSpriteRenderer;
    [SerializeField] Coots coots;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.TryGetComponent<Coots>(out Coots coots))
        {
            if (coots.HasScissors)
            {
                coots.IsInBowl = false;
                cootsSpriteRenderer.enabled = true;
                Destroy(bowlPuzzle);
            }
        }
    }
}
