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
    private SpriteRenderer switchRenderer;
    public Trap trap;
    public SwitchCounter switchCounter;

    // Counts the number of players currently on the switch
    private int localCounter = 0;

    public void Start()
    {
        switchRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchCounter.IncSwitchCounter(); //Increment the traps count on how many switches are activated
            localCounter++;

            // if the switch isn't already pressed by another player
            if (localCounter < 2)
            {
                switchRenderer.sprite = button_pressed;
            }

            // if no other active switches, deactivate the trap
            if (switchCounter.GetSwitchCounter() < 2)
            {
                trap.DeactivateTrap();
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchCounter.DecSwitchCounter(); //Decrement the traps count on how many switches are activated
            localCounter--;

            // if the switch isn't pressed by another player
            if (localCounter < 1)
            {
                switchRenderer.sprite = button_standard;
            }

            // activate trap if no switches are active
            if (switchCounter.GetSwitchCounter() < 1)
            {
                trap.ActivateTrap();
            }

        }
    }
}
