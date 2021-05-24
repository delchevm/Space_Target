using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Amends score if a player fails to hit a target based on target type and destroys the game object
public class CollisionDetection : MonoBehaviour
{

    private int score;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "UFO")
        {
            score = Score.EnemiesDestroyed;
            if (score > 0)
            {
                Score.EnemiesDestroyed--;
            }
            Destroy(collision.gameObject);

        }
        else if (collision.tag == "Rocket")
        {
            Destroy(collision.gameObject);

        }

    }
}
