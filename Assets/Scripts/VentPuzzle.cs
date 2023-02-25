using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentPuzzle : MonoBehaviour
{
    [SerializeField] GameObject ventClosed;
    [SerializeField] GameObject ventOpen;

    [SerializeField] Coots coots;

    BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        ventClosed.SetActive(true);
        ventOpen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (coots.HasScrewDriver && collision.GetComponent<SlapCollider>() != null)
        {
            OpenVent();
        }
    }

    private void OpenVent()
    {
        ventClosed.SetActive(false);
        ventOpen.SetActive(true);
        boxCollider2D.enabled = false;
    }
}
