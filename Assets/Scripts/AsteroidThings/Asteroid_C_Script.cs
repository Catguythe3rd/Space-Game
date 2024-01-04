using UnityEngine;

public class Asteroid_C_Script : MonoBehaviour
{
    public int StartingHealth = 5;
    public int CurrentHealth;
    public GameObject ExplosionEffect;
    public SpriteRenderer TheSprite;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;

    public void Awake()
    {
        CurrentHealth = StartingHealth;
        TheSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (CurrentHealth == 4)
        {
            TheSprite.sprite = Sprite1;
        }
        if (CurrentHealth == 2)
        {
            TheSprite.sprite = Sprite2;
        }
        if (CurrentHealth == 1)
        {
            TheSprite.sprite = Sprite3;
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
                Destroy(gameObject);
            }
        }

        if (other.tag == "Lazer_B")
        {
            CurrentHealth -= 1;
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.tag == "Lazer_C")
        {
            CurrentHealth -= 3;
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.tag == "Sun")
        {
            CurrentHealth -= 1;
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
