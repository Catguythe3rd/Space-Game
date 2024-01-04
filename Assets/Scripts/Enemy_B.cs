using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_B : MonoBehaviour
{
    private int StartingHealth = 50;
    public int CurrentHealth;
    private GameObject player;
    public GameObject LazerRight;
    public GameObject LazerLeft;
    public Transform ShotSpawn1;
    public Transform ShotSpawn2;
    public Transform ShotSpawn3;
    public Transform ShotSpawn4;
    public Transform ShotSpawn5;
    public Transform ShotSpawn6;
    public float MoveSpeed;

    public float TurnSpeed;
    public int TurnTimer;
    public int TurnTimerLength;
    public bool TurnTimerIsOn;

    public int ShootTimer;
    public int ShootTimerLength;
    public bool ShootTimerIsOn;

    private bool HasShot = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = StartingHealth;
        TurnTimerIsOn = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (TurnTimerIsOn == true)
        {
            TurnTimer += 1;
        }

        if (ShootTimerIsOn == true)
        {
            ShootTimer += 1;
        }

        if (TurnTimer <= TurnTimerLength && TurnTimerIsOn == true)
        {
            Vector3 DistanceBetween = player.transform.position - transform.position;
            float angle = (Mathf.Atan2(DistanceBetween.y, DistanceBetween.x) * Mathf.Rad2Deg) + 90f;
            Quaternion RotatonToLookAtPLayer = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, RotatonToLookAtPLayer, Time.deltaTime * TurnSpeed);
            transform.position -= transform.up * MoveSpeed;
        }
        else
        {
            TurnTimerIsOn = false;
            TurnTimer = 0;
            ShootTimerIsOn = true;
        }

        if (ShootTimer <= ShootTimerLength && ShootTimerIsOn == true)
        {
            if (HasShot == false)
            {
                Instantiate(LazerRight, ShotSpawn1.transform.position, ShotSpawn1.transform.rotation);
                Instantiate(LazerLeft, ShotSpawn2.transform.position, ShotSpawn2.transform.rotation);
                Instantiate(LazerRight, ShotSpawn3.transform.position, ShotSpawn3.transform.rotation);
                Instantiate(LazerLeft, ShotSpawn4.transform.position, ShotSpawn4.transform.rotation);
                Instantiate(LazerRight, ShotSpawn5.transform.position, ShotSpawn5.transform.rotation);
                Instantiate(LazerLeft, ShotSpawn6.transform.position, ShotSpawn6.transform.rotation);
                HasShot = true;
            }
        }
        else
        {
            ShootTimerIsOn = false;
            ShootTimer = 0;
            TurnTimerIsOn = true;
            HasShot = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lazer_A")
        {
            CurrentHealth -= 1;
            if (CurrentHealth <= 0)
            {
                SaveManager.Score += 2000;
                FindObjectOfType<AudioManager>().Play("EnemyDeath");
                Destroy(gameObject);
            }
        }
    }
}
