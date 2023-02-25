using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ScrewDriver : MonoBehaviour
{
    [SerializeField] float delayCollisionTimer;

    private float timer;

    private void OnEnable()
    {
        timer = delayCollisionTimer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer > 0)
            return;

        if (collision.GetComponent<SlapCollider>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}
