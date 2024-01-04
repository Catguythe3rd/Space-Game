using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_A_Prime_Color : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public Enemy_A_prime_script Prime_Script;
    public Color StartingColor;

    private void Start()
    {
        Prime_Script = GetComponentInParent<Enemy_A_prime_script>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Prime_Script.CurrentHealth <= 100 && Prime_Script.CurrentHealth > 50)
        {
            Sprite.color = Color.Lerp(Color.yellow, StartingColor, (Prime_Script.CurrentHealth - 50) / 50);
        }
        if (Prime_Script.CurrentHealth <= 50 && Prime_Script.CurrentHealth >= 0)
        {
            Sprite.color = Color.Lerp(Color.red, Color.yellow, Prime_Script.CurrentHealth /50);
        }
    }
}
