using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    [SerializeField] float runTime;

    [SerializeField] GameObject water;

    public bool IsSinkOn { get; private set; }

    private void Start()
    {
        water.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SlapCollider>() != null)
        {
            Debug.Log("slapped sink");
            TurnOnSink();
        }
    }

    public void TurnOnSink()
    {
        IsSinkOn = true;
        water.SetActive(true);
        Invoke("TurnOffSink", runTime);
    }

    private void TurnOffSink()
    {
        IsSinkOn = false;
        water.SetActive(false);
    }
}
