using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOnWall : MonoBehaviour
{
    [SerializeField] float delayOpeningDoor;
    [SerializeField] float doorOpenDuration;

    [SerializeField] GameObject openedDoor;
    [SerializeField] GameObject floorKey;
    [SerializeField] GameObject cinderella;

    Animator animator;

    bool hasPuzzleStarted;

    private void Start()
    {
        animator = GetComponent<Animator>();
        openedDoor.SetActive(false);
        cinderella.SetActive(false);
        floorKey.SetActive(false);
    }

    private void Update()
    {
        if(hasPuzzleStarted)
        return;

        if (Oven.IsRunning && Fan.IsRunning)
        {
            Debug.Log("inside oven is running");
            hasPuzzleStarted = true;
            Invoke("OpenDoor", delayOpeningDoor);
        }
    }

    private void OpenDoor()
    {
        openedDoor.SetActive(true);
        cinderella.SetActive(true);
        Invoke("CloseDoor", doorOpenDuration);
    }

    private void CloseDoor()
    {
        openedDoor.SetActive(false);
        cinderella.SetActive(false);
        animator.SetTrigger("KeyFall");
    }

    //called from Animation
    private void DisableMyselfEnableFloorKey()
    {
        floorKey.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
