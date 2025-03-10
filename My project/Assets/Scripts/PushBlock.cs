using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{
    public Rigidbody2D rb;
    public float x;
    
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 force = collision.gameObject.GetComponent<Rigidbody2D>().velocity * new Vector2(x, 0);
           
            if (force.x > 6f)
            {
                rb.velocity = new Vector2(6f, 0);
            }
            else if (force.x < -6f)
            {
                rb.velocity = new Vector2(-6f, 0);
            } 
            else
            {
                rb.velocity = force;    
            }
            
        }
    }
}
