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
    public GameObject trap1;
    public GameObject trap2;
    public GameObject trap3;
    public GameObject trap4;
    public GameObject trap5;
    public GameObject trap6;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameObject.SetActive();
            switchRenderer.sprite = button_pressed;

            trap.gameObject.SetActive(false);
            trap1.gameObject.SetActive(false);
            trap2.gameObject.SetActive(false);
            trap3.gameObject.SetActive(false);
            trap4.gameObject.SetActive(false);
            trap5.gameObject.SetActive(false);
            trap6.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameObject.SetActive(true);
            switchRenderer.sprite = button_standard;

            trap.gameObject.SetActive(true);
            trap1.gameObject.SetActive(true);
            trap2.gameObject.SetActive(true);
            trap3.gameObject.SetActive(true);
            trap4.gameObject.SetActive(true);
            trap5.gameObject.SetActive(true);
            trap6.gameObject.SetActive(true);
        }
    }
}
