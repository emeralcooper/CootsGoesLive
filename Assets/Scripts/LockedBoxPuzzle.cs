using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedBoxPuzzle : MonoBehaviour
{
    [SerializeField] GameObject lockedBox;
    [SerializeField] GameObject unlockedBox;
    [SerializeField] GameObject screwDriver;
    [SerializeField] Coots coots;

    BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        lockedBox.SetActive(true);
        unlockedBox.SetActive(false); 
        screwDriver.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (coots.HasKey && collision.GetComponent<SlapCollider>()!= null)
        {
            OpenBox();
        }
    }

    private void OpenBox()
    {
        lockedBox.SetActive(false);
        unlockedBox.SetActive(true);
        screwDriver.SetActive(true);
        boxCollider2D.enabled = false;
    }
}
