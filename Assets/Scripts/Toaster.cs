using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    [SerializeField] float minRunTime;
    [SerializeField] float maxRunTime;

    [SerializeField] GameObject toasterOff;
    [SerializeField] GameObject toasterOn;
    [SerializeField] GameObject toasterScareArea;

    private void Start()
    {
        toasterOn.SetActive(false);
        toasterOff.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SlapCollider>() != null)
        {
            Debug.Log("slapped toaster");
            StartToaster();
        }
    }

    public void StartToaster()
    {
        toasterOff.SetActive(false);
        toasterOn.SetActive(true);
        Invoke("StopToaster", Random.Range(minRunTime,maxRunTime));
    }

    private void StopToaster()
    {
        toasterOff.SetActive(true);
        toasterOn.SetActive(false);
        toasterScareArea.SetActive(true);
    }
}
