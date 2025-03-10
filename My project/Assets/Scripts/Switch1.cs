using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Switch1 : MonoBehaviour
{
    public Sprite button_standard;
    public Sprite button_pressed;
    private SpriteRenderer switchRenderer;
    public GameObject trap;
    
    // Counts the number of activations, max is the number of players
    private int switchCounter = 0;
    public void Start()
    {
        switchRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchCounter++;
            switchRenderer.sprite = button_pressed;

            trap.gameObject.SetActive(false);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchCounter--;
            if (switchCounter < 1)
            {
                switchRenderer.sprite = button_standard;
                trap.gameObject.SetActive(true);
            }

            
        }
    }
}
