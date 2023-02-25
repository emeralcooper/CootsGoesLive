using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] float runTime;

    public static bool IsRunning { get; private set; }

    [SerializeField] GameObject fanOff;
    [SerializeField] GameObject fanOn;

    private void Start()
    {
        fanOn.SetActive(false);
        fanOff.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SlapCollider>() != null)
        {
            Debug.Log("slapped fan");
            StartFan();
        }
    }

    public void StartFan()
    {
        fanOff.SetActive(false);
        fanOn.SetActive(true);
        Invoke("StopFan", runTime);
        IsRunning = true;
    }

    private void StopFan()
    {
        fanOff.SetActive(true);
        fanOn.SetActive(false);
        IsRunning = false;
    }
}
