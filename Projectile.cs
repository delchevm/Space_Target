using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls movements and interactions
public class Projectile : MonoBehaviour
{

    public static int TotalEverDestroyed;
    private float speed = 20f;
    public Rigidbody2D rb;

    public GameObject exposion;

    private void Start()
    {
        TotalEverDestroyed = PlayerPrefs.GetInt("TotalDestroyed");
    }
    
    // Movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
    }
    
    // Interactions on collision - reduces or increases score
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Score.EnemiesDestroyed++;
            TotalEverDestroyed++;
            PlayerPrefs.SetInt("TotalDestroyed", TotalEverDestroyed);

            Instantiate(exposion, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else if (collision.tag == "Earth")
        {

            FindObjectOfType<GameManager>().EndGame();

            Destroy(gameObject);

        }
        else if (collision.tag == "UFO")
        {
            Score.EnemiesDestroyed += 2;
            TotalEverDestroyed++;
            PlayerPrefs.SetInt("TotalDestroyed", TotalEverDestroyed);

            Instantiate(exposion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.tag == "Rocket")
        {
            if(Score.EnemiesDestroyed <= 2 && Score.EnemiesDestroyed >= 0)
            {
                Score.EnemiesDestroyed = 0;
            }
            else
            {
                Score.EnemiesDestroyed -= 2;
            }

            TotalEverDestroyed++;
            PlayerPrefs.SetInt("TotalDestroyed", TotalEverDestroyed);

            Instantiate(exposion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
