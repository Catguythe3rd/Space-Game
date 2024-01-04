using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TorusZoneScript : MonoBehaviour
{
    private float TorusOffsetDistanceX;
    private float TorusOffsetDistanceY;
    public List<GameObject> ThingsInZone;

    private void FixedUpdate()
    {   //remove all objects in the list that have been deleted. 
        //To use this line of code you need "using System.Linq;" at the top.
        ThingsInZone.RemoveAll(GameObject => GameObject == null);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Sun" || other.tag != "Player" || other.tag != "Untagged")
        {
            ThingsInZone.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ThingsInZone.Remove(other.gameObject);
    }

    //It takes objects in the list and makes its x coordinate into -x and its y coordinate into -y, and vice versa. 
    //It also adds the distance between the player durring translation. 
    public void FlipX()
    {
        foreach (GameObject ObjectInList in ThingsInZone)
        {   
            TorusOffsetDistanceX = ObjectInList.transform.position.x - transform.position.x;
            ObjectInList.transform.position = new Vector2((-ObjectInList.transform.position.x) + (2 * TorusOffsetDistanceX), ObjectInList.transform.position.y);
        }
    }

    public void FlipY()
    {
        foreach (GameObject ObjectInList in ThingsInZone)
        {
            TorusOffsetDistanceY = ObjectInList.transform.position.y - transform.position.y;
            ObjectInList.transform.position = new Vector2(ObjectInList.transform.position.x, (-ObjectInList.transform.position.y) + (2 * TorusOffsetDistanceY));
        }
    }
}
