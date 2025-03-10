using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Trap1 : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerController2 playerController2;
    private Renderer trapRenderer;
    private Collider2D trapCollider;

    private void Start()
    {
        trapRenderer = GetComponent<Renderer>();
        trapCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.y < collision.transform.position.y+2)
            {
                playerController.Die();
                playerController2.Die();
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        }
    }

    public void ActivateTrap () 
    {
        trapRenderer.enabled = true;
        trapCollider.enabled = true;
    }
    public void DeactivateTrap () 
    {
        trapRenderer.enabled = false;
        trapCollider.enabled = false;
    }
}
