using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public CharController charController;
    public Canvas pauseCanvas, gameCanvas;
    private bool isPaused;

    void Start()
    {
        
    }

    void Update()
    {
        isPaused = charController.isPaused;
        if (isPaused)
        {
            gameCanvas.enabled = false;
            pauseCanvas.enabled = true;
        } else
        {
            gameCanvas.enabled = true;
            pauseCanvas.enabled = false;
        }
    }
}
