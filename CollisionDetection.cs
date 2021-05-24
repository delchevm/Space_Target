using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    private int score;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            score = Score.EnemiesDestroyed;
            if (score > 0)
            {
                Score.EnemiesDestroyed--;
            }
            Destroy(collision.gameObject);

        }
        else if (collision.tag == "UFO")
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
