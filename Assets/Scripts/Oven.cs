using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField] GameObject ovenDoor;
    [SerializeField] GameObject piePuzzle;

    public static bool IsRunning { get; private set; }

    void Start()
    {
        ovenDoor.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("oven door collider entered");
        if(collision.GetComponent<PieOnFloor>() != null)
        {
            Destroy(piePuzzle);
            IsRunning = true;
            ovenDoor.SetActive(true);
        }
    }
}
