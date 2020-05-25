using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform rocketBarrel;
    public Text cooldownText;
    public float reloadTime = 0.5f;

    private float lastFireTime;
    private bool readyToFire;

    public CharController charController;

    void Start()
    {
        
    }

    void Update()
    {
        if (!charController.isPaused)
        {
            if (Input.GetButtonDown("Fire1") && readyToFire)
            {
                GameObject go = (GameObject)Instantiate(rocketPrefab, rocketBarrel.position, Quaternion.LookRotation(rocketBarrel.forward));
                Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
                lastFireTime = Time.time;
                readyToFire = false;
                cooldownText.text = "Rocket Launcher reloading...";
                cooldownText.color = Color.white;
            }

            if (!readyToFire)
            {
                if (Time.time > lastFireTime + reloadTime)
                {
                    readyToFire = true;
                    cooldownText.text = "Rocket Launcher ready to fire!";
                    cooldownText.color = Color.white;
                }
            }
        }
    }
}
