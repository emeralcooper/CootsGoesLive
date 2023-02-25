using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coots : MonoBehaviour
{
    [SerializeField] float toasterScaredTime;
    [SerializeField] float freezeDuringLastPuzzleTime;
    [SerializeField] float timeTillLoadWinScene;

    [SerializeField] Transform resetPos;
    [SerializeField] Transform invisiblePathStartPos;
    [SerializeField] GameObject ludwigChastising;
    [SerializeField] GameObject ludwigAtDesk;
    [SerializeField] GameObject ludwigWalkToVent;
    [SerializeField] GameObject lastSectionReseter;
    [SerializeField] Goal goal;
    [SerializeField] GameObject amongUsWall;

    CharacterController2D characterController;
    SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        FallingObject.OnFallingObjectBroke += ResetCootsToTower; 
    }

    private void OnDisable()
    {
        FallingObject.OnFallingObjectBroke -= ResetCootsToTower;
    }

    public bool IsInBowl { get; set; } = false;
    public bool HasScissors { get; set; }
    public bool HasKey { get; set; }
    public bool HasScrewDriver { get; set; }

    private void Start()
    {
        characterController = GetComponent<CharacterController2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ludwigAtDesk.SetActive(true);
        ludwigWalkToVent.SetActive(false);
        goal.gameObject.SetActive(false);
        lastSectionReseter.SetActive(true);
        amongUsWall.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Scissors>()!= null)
        {
            HasScissors = true;
            Debug.Log("Coots has scissors!");
        }

        if (collision.GetComponent<KeyOnFloor>() != null)
        {
            HasKey = true;
            Debug.Log("Coots has Key!");
        }

        if (collision.GetComponent<ScrewDriver>() != null)
        {
            HasScrewDriver = true;
            Debug.Log("Coots has screwdriver!");
        }

        if(collision.GetComponent<VentOpen>()!=null)
        {
            Debug.Log("coots hit open vent teleporter");
            HandleVentToVentTransition();
        }

        if (collision.GetComponent<AmongUsPuzzle>() != null)
        {
            Debug.Log("Cutes Hit Among Us Figure");
            HandleCootsAfterAmongUsCollision();
        }

        if(collision.GetComponent<LastSectionReseter>() != null)
        {
            ResetCootsToTower();
        }

        if(collision.GetComponent<Goal>() != null)
        {
            Debug.Log("collided with goal");
            Invoke("HandleGoalReached",1f);
        }
    }

    private void HandleGoalReached()
    {
        DisableInput();
        Invoke("LoadWinScene", timeTillLoadWinScene);
    }

    private void LoadWinScene()
    {
        SceneManager.LoadScene(2);
    }


    public void ResetCootsToTower()
    {          
        TeleportCootsToTower();
        DisableInputAndMovementForTime(5f);
        lastSectionReseter.SetActive(true);
        amongUsWall.SetActive(true);        
        ludwigWalkToVent.SetActive(false);
        ludwigChastising.SetActive(true);
    }

    private void TeleportCootsToTower()
    {
        GameObjectTeleporter.Teleport(this.gameObject, resetPos);
    }

    private void HandleVentToVentTransition()
    {
        spriteRenderer.enabled = false;
        ludwigAtDesk.SetActive(false);
        ludwigWalkToVent.SetActive(true);
    }

    public void HandleCootsAfterAmongUsCollision()
    {
        DisableInputAndMovementForTime(freezeDuringLastPuzzleTime);
        lastSectionReseter.SetActive(false);
        amongUsWall.SetActive(false);
        goal.gameObject.SetActive(true);
    }


    public void DisableInput()
    {
        PlayerInput.Instance.ReleaseControl();
        characterController.enabled = false;
    }

    public void EnableInput()
    {
        PlayerInput.Instance.GainControl();
        characterController.enabled = true;
    }

    public void GetScaredByToaster()
    {
        DisableInputAndMovementForTime(toasterScaredTime);
    } 

    public void DisableInputAndMovementForTime(float time)
    {
        PlayerInput.Instance.ReleaseControl();
        characterController.enabled = false;
        Invoke("EnableInputAndMovement", time);
    }

    private void EnableInputAndMovement()
    {
        PlayerInput.Instance.GainControl();
        characterController.enabled = true;
    }
}
