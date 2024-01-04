using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public static Vector3 Mouse;

    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
        Mouse = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
    }
}
