using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;

    int direction = 1;

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)transform.position).magnitude;

        if (distance <= 0.01F)
        {
            direction *= -1;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.y+1 < collision.transform.position.y)
            {
                collision.gameObject.transform.SetParent(transform);
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }



    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            //move to end
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    

    private void OnDrawGizmos()
    {
        if(transform != null && startPoint!=null && endPoint!=null)
        {
            Gizmos.DrawLine(transform.transform.position, startPoint.position);
            Gizmos.DrawLine(transform.transform.position, endPoint.position);
        }
    }
}
