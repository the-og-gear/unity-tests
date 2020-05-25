using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public CharController charController;

    private float cycleSpeed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!charController.isPaused)
        {
            transform.Rotate(new Vector3(0, cycleSpeed * Time.deltaTime, 0));
        }
    }
}
