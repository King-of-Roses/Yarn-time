using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float destroyDelay = 4f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (rb.bodyType== RigidbodyType2D.Kinematic)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                Destroy(gameObject, destroyDelay);
            }
        }
        
    }

    
}
