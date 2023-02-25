using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stool : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<StoolSlipTrigger>() != null)
        {
            myRigidbody.drag = 0;
        }

        if (collision.GetComponent<StoolStopperLeft>() != null)
        {
            Destroy(myRigidbody);
            Destroy(myBoxCollider);
        }
    }
}
