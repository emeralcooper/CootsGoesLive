using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    [SerializeField] BroomHook broomHook;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<SlapCollider>() != null)
        {
            broomHook.StartSwingAnimation();
        }
    }


}
