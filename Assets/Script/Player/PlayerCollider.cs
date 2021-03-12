﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject player;
    public GameObject canvasPlayerJoystick;
    public GameObject canvasProgressBar;
    public GameObject canvasPaintRoller;

    public GameObject paintWallMenu;
    public Collider groundCollider;
    public Collider triggerCollider;

    void Start()
    {

        FindObjectOfType<PaintWall>().enabled = false;
    }


    void Update()
    {

    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Obstacle")
        {
            FindObjectOfType<GameController>().EndGame();

        }
        if (other.tag == "FinishLine")
        {
            FindObjectOfType<CamController>().switchPriority();

            Invoke("DisableCanvas", 1);
            
            FindObjectOfType<PaintWall>().PaintingActive();

        }
     
    }

    public void ActivePaintingButton()
    {
        canvasPaintRoller.SetActive(true);
        canvasProgressBar.SetActive(true);
        triggerCollider.enabled = false;
        groundCollider.enabled = false;
        FindObjectOfType<PaintWall>().enabled = true;
        paintWallMenu.SetActive(false);
        
    }
  
    void DisableCanvas()
    {

        paintWallMenu.SetActive(true);
        player.SetActive(false);
        canvasPlayerJoystick.SetActive(false);
       
    }
}
