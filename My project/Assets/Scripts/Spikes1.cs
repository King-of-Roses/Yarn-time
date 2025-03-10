using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out PlayerController player1))
        {
            if (transform.position.y + 1 < collision.transform.position.y)
            {
                if (!player1.IsDead)
                {
                    player1.Die();
                }
            }
            
        }

        // ¼ì²é Player2
        if (collision.collider.TryGetComponent<PlayerController2>(out PlayerController2 player2))
        {
            if (transform.position.y + 1 < collision.transform.position.y)
            {
                if (!player2.IsDead)
                {
                    player2.Die();
                }
            }
        }
    }
}
