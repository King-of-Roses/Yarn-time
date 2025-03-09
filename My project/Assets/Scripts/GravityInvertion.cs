using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GravityInvertion : MonoBehaviour
{
    public Sprite button_standard;
    public Sprite button_pressed;
    private SpriteRenderer switchRenderer;
    public Rigidbody2D targetRigidBody;

    // shared count if multiple switches
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
            switchCounter.IncSwitchCounter(); 
            localCounter++;

            // if the switch isn't already pressed by another player
            if (localCounter < 2)
            {
                switchRenderer.sprite = button_pressed;
            }

            // if the gravity isn't already inverted by another switch
            if (switchCounter.GetSwitchCounter() < 2)
            {
                InvertGravity();
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchCounter.DecSwitchCounter();
            localCounter--;

            // if the switch isn't pressed by another player
            if (localCounter < 1)
            {
                switchRenderer.sprite = button_standard;
            }

            // if the gravity isn't inverted by another switch
            if (switchCounter.GetSwitchCounter() < 1)
            {
                InvertGravity();
            }
        }
    }

    private void InvertGravity()
    {
        targetRigidBody.gravityScale *= -1;
    }
}
