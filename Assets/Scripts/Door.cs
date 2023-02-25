using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool isDoorOpen;

    [SerializeField] GameObject openedDoor;
    [SerializeField] GameObject closedDoor;

    private bool hasDoorOpenBeenChecked;
    private bool hasDoorClosedBeenChecked;

    private void Start()
    {

    }

    void Update()
    {
        if (isDoorOpen && !hasDoorOpenBeenChecked)
        {
            OpenDoor();
            hasDoorOpenBeenChecked = true;
            hasDoorClosedBeenChecked = false;
        }

        if (!isDoorOpen && !hasDoorClosedBeenChecked)
        {
            CloseDoor();
            hasDoorClosedBeenChecked = true;
            hasDoorOpenBeenChecked=false;
        }
    }

    public void OpenDoor()
    {
        isDoorOpen = true;
        openedDoor.SetActive(true);
        closedDoor.SetActive(false);
    }

    public void CloseDoor()
    {
        isDoorOpen = false;
        openedDoor.SetActive(false);
        closedDoor.SetActive(true);
    }
}
