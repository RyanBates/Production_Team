using UnityEngine;
using System.Collections.Generic;
using UnityStandardAssets.Utility;

public class CheckPointHighlight : MonoBehaviour
{

    public Checkpoint unitAt;
    public GameObject particles;
    public List<GameObject> checkList;

    public GameObject circet;

    void Start()
    {
        checkList = new List<GameObject>();
        foreach (Transform t in circet.GetComponent<WaypointCircuit>().waypointList.items)
        {
            checkList.Add(t.gameObject);
        }
        unitAt = checkList[0].GetComponent<Checkpoint>();
        particles.transform.position = unitAt.transform.position;
    }

    void LateUpdate()
    {

        if (unitAt.CheckPosition(gameObject))
        {
            if (checkList.IndexOf(unitAt.gameObject) + 1 >= checkList.Count)
                unitAt = checkList[0].GetComponent<Checkpoint>();
            else
                unitAt = checkList[checkList.IndexOf(unitAt.gameObject) + 1].GetComponent<Checkpoint>();

            particles.transform.position = unitAt.transform.position;
        }
    }
}