using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInvertion : MonoBehaviour
{
    public Rigidbody2D yarnPlayer;
    private bool isGravityInverted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvertGravity();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvertGravity();
        }
    }

    private void InvertGravity()
    {
        yarnPlayer.gravityScale *= -1;
    }
}
