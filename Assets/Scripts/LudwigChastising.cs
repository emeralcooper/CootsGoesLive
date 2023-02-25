using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudwigChastising : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);        
    }

    // called from animation
    private void SetMyselfToInactive()
    {
        this.gameObject.SetActive(false);
    }

}
