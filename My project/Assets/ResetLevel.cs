using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Trap : MonoBehaviour
{
    public float bounceForce = 10f;
    public int damage = 1;
    public PlayerController playerController;
    public PlayerController2 playerController2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            playerController.Die();
            playerController2.Die();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }
    }
}
