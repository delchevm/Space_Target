using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls emeny behaviour
public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    private float enemySpeed;
    private float score;
    private float totalSpeed;
    private float speedRotation;
    private float SpeedLower = 1f;
    private float SpeedUpper = 1f;
    private float MaxSpeed = 1f;
    private float SpeedUP = 1f;

    SpriteRenderer spritecolour;
    
    // Sets up the speed and rotationa of the game object
    void Start()
    {
        spritecolour = GetComponent<SpriteRenderer>();
        spritecolour.color = Random.ColorHSV(0f, 0f, 0f, 0f, 0.72f, 1f);

        LevelManger enemyRigtht= GameObject.Find("Main Camera").GetComponent<LevelManger>();
        SpeedLower = enemyRigtht.SpeedLower;
        SpeedUpper = enemyRigtht.SpeedUpper;
        MaxSpeed = enemyRigtht.MaxSpeed;
        SpeedUP = enemyRigtht.SpeedUP;

        score = Score.EnemiesDestroyed;
        enemySpeed = Random.Range(SpeedLower, SpeedUpper);
        speedRotation = Random.Range(0f, 360f);
        if (enemySpeed + score / SpeedUP > MaxSpeed)
        {
            totalSpeed = MaxSpeed;
        }
        else
        {
            totalSpeed = enemySpeed + score / SpeedUP;
        }
        transform.Rotate(0f, 0f, speedRotation);
    }

    // Handles interactions with other objects
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            Destroy(gameObject);
        }

    }
    
    // Movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * totalSpeed * Time.deltaTime);
        
    }
}
