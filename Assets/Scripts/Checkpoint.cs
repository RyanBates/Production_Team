using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour
{
    public float AreaHit;       //How close the Unit must hit
    public List<GameObject> Racers; //list that will not be edited in this script but in the RaceManager

    public bool CheckPosition(GameObject CurrentPoint)
    {
        if ((gameObject.transform.position.x - AreaHit) <= CurrentPoint.transform.position.x && CurrentPoint.transform.position.x <= (gameObject.transform.position.x + AreaHit))
        {
            if ((gameObject.transform.position.z - AreaHit) <= CurrentPoint.transform.position.z && CurrentPoint.transform.position.z <= (gameObject.transform.position.z + AreaHit))
            {
                return true;
            }
        }
        return false;
    }

    void Start()
    {
        Racers = new List<GameObject>();
    }
}
