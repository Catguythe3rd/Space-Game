using UnityEngine;

public class Asteroid_D_Script : MonoBehaviour
{
    public float StartingHealth = 20;
    public float CurrentHealth;
    public GameObject ExplosionEffect;
    public SpriteRenderer TheSprite;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public Sprite Sprite6;

    public void Awake()
    {
        CurrentHealth = StartingHealth;
        TheSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (CurrentHealth == 17)
        {
            TheSprite.sprite = Sprite1;
        }
        if (CurrentHealth == 14)
        {
            TheSprite.sprite = Sprite2;
        }
        if (CurrentHealth == 11)
        {
            TheSprite.sprite = Sprite3;
        }
        if (CurrentHealth == 8)
        {
            TheSprite.sprite = Sprite4;
        }
        if (CurrentHealth == 5)
        {
            TheSprite.sprite = Sprite5;
        }
        if (CurrentHealth == 2)
        {
            TheSprite.sprite = Sprite6;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lazer_A")
        {
            CurrentHealth -= 1;
            if (CurrentHealth <= 0)
            {
                SaveManager.Score += 1000;
                FindObjectOfType<AudioManager>().Play("");
                Destroy(gameObject);
            }
        }

        if (other.tag == "Lazer_B")
        {
            CurrentHealth -= 1;
            if (CurrentHealth <= 0)
            {
                FindObjectOfType<AudioManager>().Play(""); ;
                Destroy(gameObject);
            }
        }

        if (other.tag == "Lazer_C")
        {
            CurrentHealth -= 3;
            if (CurrentHealth <= 0)
            {
                FindObjectOfType<AudioManager>().Play(""); ;
                Destroy(gameObject);
            }
        }

        if (other.tag == "Sun")
        {
            CurrentHealth -= 0.1f;
            if (CurrentHealth <= 0)
            {
                FindObjectOfType<AudioManager>().Play(""); ;
                Destroy(gameObject);
            }
        }
    }
}
