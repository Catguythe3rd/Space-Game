using UnityEngine;
using System.Collections;

public class Enemy_A_Script : MonoBehaviour
{
    public float lookRadius;
    public float SetSpeed;
    private float UsedSpeed;
    public float TurnSpeed;
    public float StoppingDistance;
    public int ShootTimer;
    public int ShootTimerLength;
    public int ShotIntervalStart;
    public int ShotIntervalEnd;
    private GameObject player;
    public GameObject Lazer;
    public Transform ShotSpawn;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (Menus.PlayerIsDead || Menus.GameIsPaused == false)
        {
            //determines if player is in range
            float distance = Vector2.Distance(player.transform.position, transform.position);

            if (distance <= StoppingDistance)
            {
                UsedSpeed = 0;
            }
            else
            {
                UsedSpeed = SetSpeed;
            }

            if (distance <= lookRadius)
            {   
                //determines length between shots
                ShootTimerLength = Random.Range(ShotIntervalStart, ShotIntervalEnd);
                
                //rotates the enemy over time then moves forward.
                Vector3 DistanceBetween = player.transform.position - transform.position;
                float angle = (Mathf.Atan2(DistanceBetween.y, DistanceBetween.x) * Mathf.Rad2Deg) - 90f;
                Quaternion RotatonToLookAtPLayer = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, RotatonToLookAtPLayer, Time.deltaTime * TurnSpeed);
                transform.position += transform.up * UsedSpeed;

                //shoot timer
                ShootTimer += 1;

                if (ShootTimer >= ShootTimerLength)
                {
                    FindObjectOfType<AudioManager>().Play("LazerNoise2");
                    Instantiate(Lazer, ShotSpawn.position, ShotSpawn.rotation);
                    ShootTimer = 0;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}