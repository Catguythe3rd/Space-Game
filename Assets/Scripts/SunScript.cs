using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy_A")
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            Destroy(other.gameObject);
        }

        if (other.tag == "Asteroid_A" || other.tag == "Asteroid_B")
        {
            Destroy(other.gameObject);
        }
    }
}
