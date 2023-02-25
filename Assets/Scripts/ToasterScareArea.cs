using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterScareArea : MonoBehaviour
{
    [SerializeField] float thrust;
    [SerializeField] float scareWindow;

    [SerializeField] Rigidbody2D cootsRigidBody;
    [SerializeField] Coots coots;

    private bool hasBeenThrusted;

    private void OnEnable()
    {
        Invoke("DisableMyself", scareWindow);
    }

    private void OnDisable()
    {
        hasBeenThrusted = false;
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding with coots");
        if (!hasBeenThrusted)
        {
            if(collision.GetComponent<Coots>()!= null)
            {  
                hasBeenThrusted = true;
                coots.GetScaredByToaster();
                cootsRigidBody.AddForce(new Vector2(0, thrust), ForceMode2D.Impulse);
            }
        }
        
    }

    private void DisableMyself()
    {
        this.gameObject.SetActive(false);
    }
}
