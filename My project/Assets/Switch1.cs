using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite button_standard;
    public Sprite button_pressed;
    public SpriteRenderer switchRenderer;
    public GameObject trap;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameObject.SetActive();
            switchRenderer.sprite = button_pressed;

            trap.gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameObject.SetActive(true);
            switchRenderer.sprite = button_standard;

            trap.gameObject.SetActive(true);
        }
    }
}
