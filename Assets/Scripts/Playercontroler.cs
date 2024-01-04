using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroler : MonoBehaviour
{
    //Player Componets
    private Rigidbody2D rb2d;
    public Behaviour Collider;
    public Renderer SpriteRenderer;
    public Transform ShotSpawn;

    //GameObjects
    public GameObject Lazer;
    private GameObject Sun;
    public PlayerCamera PLayerCamera;

    //inputs
    private float moveHorizontal;
    private float moveVertical;
    private float Aim;
    private float shoot;
    private bool AimMouse;
    private bool ShootMouse;

    //input extra peices
    private Vector2 movement;
    public float PlayerRotation;
    public float movespeed;
    private float movespeed2;
    private bool AxisInUse;
    public static bool Aiminuse;

    //menus and torus stuff
    public float ActivaeTorusX;
    public float ActivaeTorusy;
    public float ActivatePreTorusX;
    public float ActivatePreTorusY;
    public TorusZoneScript TorusZoneMiddle;
    public Menus Menus;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        TorusZoneMiddle = GetComponentInChildren<TorusZoneScript>();
        Sun = GameObject.FindGameObjectWithTag("Sun");
    }

    void FixedUpdate()
    {
        //This area gives the player controlls, given he isn't in a dead state.
        //These include:
        //-Move /Rotate (both are in 360 degree rotation, flat against the z plane),
        //  Move/Rotate are separated by Mouse and Controller below so they can be togged on and off.
        //-Shoot lazers (spawn lazer prefab)
        //-Aim (stopping movement). 
        //The defalt for these controlls was controller input, but keyboard and mouse have been added. The controll variables for 
        // mouse and keyboard were added second and are labeled with Mouse. 

        
        ///Checks if player is dead so it can stop all non-menu controlles.
        if (Menus.PlayerIsDead == false)
        {
            ////This allows the player to Move.

            //keyboard
            if (Menus.ControllesInUse == 1)
            {
                Vector3 PlayerMouseDifference = PlayerCamera.Mouse - transform.position;
                PlayerRotation = Mathf.Atan2(PlayerMouseDifference.y, PlayerMouseDifference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, PlayerRotation - 90);
                rb2d.AddRelativeForce(new Vector2(0, 1) * movespeed2);
            }

            //controller
            if (Menus.ControllesInUse == -1)
            {
                moveHorizontal = Input.GetAxis("Horizontal");
                moveVertical = Input.GetAxis("Vertical");
                movement = new Vector2(moveHorizontal, moveVertical);
                rb2d.AddForce(movement * movespeed2);

                PlayerRotation = (Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg) * -1;
                rb2d.rotation = PlayerRotation;

                //For Controller, keeps the current rotation if there is no movement.
                if (moveHorizontal != 0f && moveVertical != 0f)
                {
                    PlayerPrefs.SetFloat("LastRotation", PlayerRotation);
                }
                if (moveHorizontal == 0f && moveVertical == 0f)
                {
                    rb2d.rotation = PlayerPrefs.GetFloat("LastRotation");
                }
            }

            ////This allows the player to shoot lazers.
            shoot = Input.GetAxis("ShootLazer");
            ShootMouse = Input.GetButton("ShootMouse");

            if (shoot != 0 || ShootMouse == true)
            {
                if (AxisInUse == false)
                {
                    FindObjectOfType<AudioManager>().Play("LazerNoise");
                    Instantiate(Lazer, ShotSpawn.position, ShotSpawn.rotation);
                    SaveManager.Energy -= 1;
                    AxisInUse = true;
                }
            }
            else if (shoot == 0 || ShootMouse == false)
            {
                AxisInUse = false;
            }

            ////This the button to aim.
            Aim = Input.GetAxis("Aim");
            AimMouse = Input.GetButton("AimMouse");

            if (Aim != 0 || AimMouse == true)
            {
                if (Aiminuse == false)
                {
                    movespeed2 = 0;
                    Aiminuse = true;
                }
            }
            else if (Aim == 0 || AimMouse == false)
            {
                Aiminuse = false;
                movespeed2 = movespeed;
            }
        }

        ///Torus effect and Cordinate tracking.
        if (transform.position.x > ActivaeTorusX)
        {
            TorusZoneMiddle.FlipX();
            SaveManager.CoordinateX += 1;
            transform.position = new Vector2(-ActivaeTorusX, transform.position.y);
        }
        if (transform.position.x < -ActivaeTorusX)
        {
            TorusZoneMiddle.FlipX();
            SaveManager.CoordinateX -= 1;
            transform.position = new Vector2(ActivaeTorusX, transform.position.y);
        }
        if (transform.position.y > ActivaeTorusy)
        {
            TorusZoneMiddle.FlipY();
            SaveManager.CoordinateY += 1;
            transform.position = new Vector2(transform.position.x, -ActivaeTorusy);
        }
        if (transform.position.y < -ActivaeTorusy)
        {
            TorusZoneMiddle.FlipY();
            SaveManager.CoordinateY -= 1;
            transform.position = new Vector2(transform.position.x, ActivaeTorusy);
        }

        ///When the player is dead, this makes them disappear.
        if (Menus.PlayerIsDead == true)
        {
            Collider.enabled = false;
            SpriteRenderer.enabled = false;
        }

        if (Menus.PlayerIsDead == false)
        {
            Collider.enabled = true;
            SpriteRenderer.enabled = true;
        }

        ///This determines if the player is in range of the sun, and manages sun damage.
        if (Sun.activeInHierarchy == true)
        {
            float distance = Vector2.Distance(Sun.transform.position, gameObject.transform.position);

            if (distance <= 43.5f && distance > 38)
            {
                SaveManager.Energy -= 1;
            }
            else if (distance <= 38)
            {
                SaveManager.Energy -= 5;
            }

            if (Aiminuse == true && distance <= 55 && distance >= 43.5 && SaveManager.Energy < SaveManager.EnergyLimit)
            {
                SaveManager.Energy += 1;
            }
        }
    }
}
