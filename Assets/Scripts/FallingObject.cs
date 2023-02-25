using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] float timeToRetrigger = 5f;

    Animator animator;

    private float timer;

    public delegate void FallingObjectBroke();
    public static event FallingObjectBroke OnFallingObjectBroke;

    private void Start()
    {
        animator = GetComponent<Animator>();
        timer = 0;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coots>() != null && timer < 0)
        {
            Debug.Log("collided with " + this.gameObject.name);
            animator.SetTrigger("TriggerFall");
            timer = timeToRetrigger;
        }
        
    }

    //This is called from falling animation
    private void RaiseOnfallingObjectEvent()
    {
        if(OnFallingObjectBroke != null)
        {
            OnFallingObjectBroke();
        }
    }
}
