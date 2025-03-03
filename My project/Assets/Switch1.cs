using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject trap;
    
    // Counts the number of activations, max is the number of players
    private int switchCounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchCounter++;
            trap.gameObject.SetActive(false);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && switchCounter < 2)
        {
            switchCounter--;
            trap.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            switchCounter--;
        }
    }
}
