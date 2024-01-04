using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_C : MonoBehaviour
{
    public float RotationSpeed;
    public float Speed;
    public float destroyRate;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyRate);
    }

    private void FixedUpdate()
    {
        transform.position += transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid_A" || other.tag == "Asteroid_B")
        {
            FindObjectOfType<AudioManager>().Play("ExplosionSound");
            Destroy(other.gameObject);
            //Instantiate(Ast_Explosion_A, ParticleSpawn.position, ParticleSpawn.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Asteroid_C" || other.tag == "Asteroid_D" || other.tag == "Asteroid_E")
        {
            FindObjectOfType<AudioManager>().Play("");
            //Instantiate(Ast_Damage, ParticleSpawn.position, ParticleSpawn.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            SaveManager.Energy -= 200;
            FindObjectOfType<AudioManager>().Play("PlayerDamage");
            Destroy(gameObject);
        }

        if (other.tag == "Enemy_A_prime")
        {
            Destroy(gameObject);
        }
    }
}
