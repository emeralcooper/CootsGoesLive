using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvas : MonoBehaviour
{
    [SerializeField] float lifeTime;

    float timer;
    void Start()
    {
        timer = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
