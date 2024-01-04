using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_A : MonoBehaviour
{
    public float lazerspeed;
    public float destroyRate;
    public int DamagePerShot = 1;
    public GameObject Ast_Damage;
    public GameObject Ast_Explosion_A;
    public Transform ParticleSpawn;
    private Asteroid_C_Script C_Health;
    private Asteroid_D_Script D_Health;

    void Start()
    {
        GetComponent<Rigidbody2D>()
            .AddForce(transform.up * lazerspeed);
        Destroy(gameObject, destroyRate);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        //Asteroids
        if (other.tag == "Asteroid_A")
        {
            FindObjectOfType<AudioManager>().Play("ExplosionSound");
            Destroy(other.gameObject);
            Instantiate(Ast_Explosion_A, ParticleSpawn.position, ParticleSpawn.rotation);
            SaveManager.Score += 50;
            Destroy(gameObject);
        }

        if (other.tag == "Asteroid_B")
        {
            FindObjectOfType<AudioManager>().Play("ExplosionSound");
            Destroy(other.gameObject);
            Instantiate(Ast_Explosion_A, ParticleSpawn.position, ParticleSpawn.rotation);
            SaveManager.Score += 100;
            Destroy(gameObject);
        }

        if (other.tag == "Asteroid_C" || other.tag == "Asteroid_D" || other.tag == "Asteroid_E")
        {
            FindObjectOfType<AudioManager>().Play("");
            Instantiate(Ast_Damage, ParticleSpawn.position, ParticleSpawn.rotation);
            Destroy(gameObject);
        }

        //enemys
        if (other.tag == "Enemy_A")
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            Destroy(other.gameObject);
            SaveManager.Score += 500;
            Destroy(gameObject);
        }

        if(other.tag == "Enemy_A_prime")
        {
            FindObjectOfType<AudioManager>().Play("");
            //Instantiate(, ParticleSpawn.position, ParticleSpawn.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Enemy_B")
        {
            FindObjectOfType<AudioManager>().Play("");
            //Instantiate(, ParticleSpawn.position, ParticleSpawn.rotation);
            Destroy(gameObject);
        }
    }
}