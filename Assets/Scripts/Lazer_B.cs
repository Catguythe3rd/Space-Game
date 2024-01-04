using UnityEngine;

public class Lazer_B : MonoBehaviour
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
        GetComponent<Rigidbody2D>().AddForce(transform.up * lazerspeed);
        Destroy(gameObject, destroyRate);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid_A" || other.tag == "Asteroid_B")
        {
            FindObjectOfType<AudioManager>().Play("ExplosionSound");
            Destroy(other.gameObject);
            Instantiate(Ast_Explosion_A, ParticleSpawn.position, ParticleSpawn.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Asteroid_C" || other.tag == "Asteroid_D" || other.tag == "Asteroid_E")
        {
            GetHitAsteroid();
        }

        if (other.tag == "Player")
        {
            SaveManager.Energy -= 100;
            FindObjectOfType<AudioManager>().Play("PlayerDamage");
            Destroy(gameObject);
        }

        if (other.tag == "Enemy_A_prime")
        {
            Destroy(gameObject);
        }
    }

    void GetHitAsteroid()
    {
        FindObjectOfType<AudioManager>().Play("");
        Instantiate(Ast_Damage, ParticleSpawn.position, ParticleSpawn.rotation);
        Destroy(gameObject);
    }
}
