using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOnFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coots>() != null || collision.GetComponent<SlapCollider>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}
