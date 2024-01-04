using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A_prime_script : MonoBehaviour
{
    private GameObject player;
    public float lookRadius;
    public float speed;
    public float StartingHealth;
    public float CurrentHealth;
    public int ShootTimer;
    public int ShootTimerLength;
    public GameObject Enemy_Particle;
    public GameObject SpawnSpot_N;
    public GameObject SpawnSpot_NE;
    public GameObject SpawnSpot_NW;
    public GameObject SpawnSpot_S;
    public GameObject SpawnSpot_SE;
    public GameObject SpawnSpot_SW;
    private int SpawnSpot_Number;
    private GameObject Chosen_SpawnShot;

    public void Awake()
    {
        CurrentHealth = StartingHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Menus.PlayerIsDead || Menus.GameIsPaused == false)
        {
            //determines if player is in range
            float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);

            if (CurrentHealth == StartingHealth/4)
            {
                ShootTimerLength = 125;
            }

            if (distance <= lookRadius)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
                
                //shoot timer
                ShootTimer += 1;

                if (ShootTimer >= ShootTimerLength)
                {
                    SpawnSpot_Number = Random.Range(1,7);
                    if (SpawnSpot_Number == 1)
                    {
                        Chosen_SpawnShot = SpawnSpot_N;
                    }
                    else if (SpawnSpot_Number == 2)
                    {
                        Chosen_SpawnShot = SpawnSpot_NE;
                    }
                    else if (SpawnSpot_Number == 3)
                    {
                        Chosen_SpawnShot = SpawnSpot_NW;
                    }
                    else if (SpawnSpot_Number == 4)
                    {
                        Chosen_SpawnShot = SpawnSpot_S;
                    }
                    else if (SpawnSpot_Number == 5)
                    {
                        Chosen_SpawnShot = SpawnSpot_SE;
                    }
                    else
                    {
                        Chosen_SpawnShot = SpawnSpot_SW;
                    }
                    Instantiate(Enemy_Particle, Chosen_SpawnShot.transform.position, Chosen_SpawnShot.transform.rotation);
                    FindObjectOfType<AudioManager>().Play("");
                    ShootTimer = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lazer_A")
        {
            CurrentHealth -= 1;
            if (CurrentHealth <= 0)
            {
                SaveManager.Score += 10000;
                FindObjectOfType<AudioManager>().Play("EnemyDeath");
                Destroy(gameObject);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
