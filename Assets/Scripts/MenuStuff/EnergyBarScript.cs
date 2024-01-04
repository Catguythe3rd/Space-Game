using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarScript : MonoBehaviour
{
    public float EnergyPercent;
    public SpriteRenderer Sprite;

    // Update is called once per frame
    void Update()
    {
        EnergyPercent = SaveManager.Energy / SaveManager.EnergyLimit;
        transform.localScale = new Vector2(2 - (2 * EnergyPercent), transform.localScale.y);

        if (EnergyPercent > 0.5)
        {
            Sprite.color = Color.Lerp(Color.green, Color.yellow, 2 - (EnergyPercent * 2));
        }
        else
        {
            Sprite.color = Color.Lerp(Color.yellow, Color.red, 1 - (EnergyPercent * 2));
        }
    }
}
