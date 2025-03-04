using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetLevel : MonoBehaviour
{
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
