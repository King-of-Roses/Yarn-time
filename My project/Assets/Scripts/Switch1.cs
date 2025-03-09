using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite button_standard;
    public Sprite button_pressed;
    public SpriteRenderer switchRenderer;
    public GameObject trap;
    
    // Counts the number of activations, max is the number of players
    private int switchCounter = 0;

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
