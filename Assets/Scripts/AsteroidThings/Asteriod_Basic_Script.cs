using UnityEngine;

public class Asteriod_Basic_Script : MonoBehaviour
{
    private Rigidbody2D r2;
    private float numb1;
    private float numb2;
    private float numb3;
    private float speed;
    public float RotationEffect;

    private void Awake()
    {
        r2 = GetComponent<Rigidbody2D>();

        //random asteroid rotation.
        numb1 = Random.Range(-15, 15);
        if (numb1 == 0)
        {
            numb1 = 1;
        }

        r2.angularVelocity = numb1 * RotationEffect;

        //random direction the asteroid travels in.
        numb2 = Random.Range(-1, 1);
        if (numb2 == 0)
        {
            numb2 = 1;
        }

        numb3 = Random.Range(-1, 1);
        if (numb3 == 0)
        {
            numb3 = 1;
        }

        //random speed of asteroids.
        speed = Random.Range(1, 5);
    }

    private void Start()
    {
        r2.velocity = new Vector2(numb3 * speed / 5, numb2 * speed / 5);
    }

    void Update()
    {
        if (transform.position.x >= 150)
        {
            r2.velocity = r2.velocity * -1;
        }
        if (transform.position.x <= -150)
        {
            r2.velocity = r2.velocity * -1;
        }
        if (transform.position.y >= 150)
        {
            r2.velocity = r2.velocity * -1;
        }
        if (transform.position.y <= -150)
        {
            r2.velocity = r2.velocity * -1;
        }
    }

}
