﻿using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine.Events;
using UnityStandardAssets.Utility;

public class UnitAttributes : MonoBehaviour {

    public class PlayerEvent : UnityEvent
    {

    }

    public static PlayerEvent playerDeath;

    public float health;                    //How far away is the Unit from being Destroyed
    public List<GameObject> weaponsList;    //List of all the Wepaons
    public GameObject currentWeapon;        //Weapon Currently Using

    //To caculate speed
    float preTime;      //Previous time
    Vector3 preVector;  //previous Vector
    float force;        //How much force is that object carring

    //Race Manager Variables
    public int lap;
    public int checkPoints;
    public Checkpoint nextPoint;
    public WayPointCircuit.WaypointList checkPointsList;
    public int placeValue;

	// Use this for initialization
	void Start () {
        checkPointsList = GameObject.Find("CheckPoints").GetComponent<WayPointCircuit>().waypointList;
        placeValue = 0;
        //nextPoint = checkPointsList.items[0];
        preTime = 0;     //Set Pretime   
        preVector = gameObject.transform.position;  //Set Prevector

        int childCount = gameObject.transform.childCount;   //Get Number of children
        for(int i = 0; i < childCount; i++)
        {
            if(transform.GetChild(i).gameObject.tag == "Weapon")    //If a weapon
            {
                transform.GetChild(i).gameObject.SetActive(false);  //Set acticve to false
                weaponsList.Add(transform.GetChild(i).gameObject);  //Add weapon
            }
        }

        if (childCount > 0) //if we have Weapons
        {
            currentWeapon = weaponsList[0]; //Current weapon is the first one
            currentWeapon.SetActive(true);  //Turn on that object
        }
        
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gameObject.CompareTag("Player")) //If the Player
        {
            currentWeapon.SetActive(false);     //Set Current to false
            if(weaponsList.IndexOf(currentWeapon) + 1 >= weaponsList.Count) //if last weapon
            {
                currentWeapon = weaponsList[0]; //Change to first
            }

            else
            {
                currentWeapon = weaponsList[weaponsList.IndexOf(currentWeapon) + 1];    //Change to next
            }
            currentWeapon.SetActive(true);  //Set new current weapon's active to true
        }

        //if (nextPoint.CheckPosition(gameObject))
        //{
            //if(System.Array.IndexOf(checkPointsList.items, nextPoint) + 1 >= checkPointsList.items.Length)
            //{
            //    nextPoint = checkPointsList.items[0];
            //}

            //else
            //{
            //    nextPoint = checkPointsList.items[System.Array.IndexOf(checkPointsList.items, nextPoint) + 1];
            //}
        //}
    }

    void FixedUpdate () {
        if(health <= 0f)    //if has no health
        {
            gameObject.SetActive(false);    //Destroy Game Object
        }

        float timeInt = Time.time - preTime;                        //Interval of Time
        Vector3 dist = gameObject.transform.position - preVector;   //Change in position

        force = dist.sqrMagnitude / timeInt;    //How hard the Unit will hit
        preTime = Time.time;                    //set pretime to current time
        preVector = gameObject.transform.position;  //Set preVector to current Vector
	}

    void OnCollisionEnter(Collision other)
    {   //Do i collide with a weapon
        if(other.gameObject.tag == "Weapon")
        {
            if (other.gameObject.transform.parent != null) {
                float dam = other.gameObject.GetComponent<Weapons>().damage;                        //Get Damage of Weapon
                float otherForce = other.gameObject.GetComponentInParent<UnitAttributes>().force;   //Get force it is moving at

                if (Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward) <= .25f && Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward) >= -.25f)     //if other is facing the side of the Unit
                    health -= dam * otherForce;     //Apply normal dammage

                else if (Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward) > .25f)
                    health -= (dam * otherForce) - (force / Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward)); //Number will be positive, so take a little force off.

                else if(Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward) < -.25f)
                    health -= (dam * otherForce) - (force / Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward)); //Minus because of the negative dot product, minus a negative to add
            }
        }
        //Is the object a bullet and is it not my bullet
        else if (other.gameObject.CompareTag("Bullet") && other.gameObject.GetComponent<Bullet_Control>().unitFired != gameObject)
        {
            Bullet_Control otherScript = other.gameObject.GetComponent<Bullet_Control>();

            if (Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward) <= .25f && Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward) >= -.25f)    //if other is facing the side of the Unit
                health -= otherScript.damage * otherScript.force;   //Apply normal dammage

            else if (Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward) > .25f)
                health -= (otherScript.damage * otherScript.force) - (force / Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward)); //Number will be positive, so take a little force off.

            else if (Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward) < -.25f)
                health -= (otherScript.damage * otherScript.force) - (force / Vector3.Dot(other.gameObject.transform.forward, gameObject.transform.forward)); //Minus because of the negative dot product, minus a negative to add

            Destroy(other.gameObject);  //Destroy the bullet
        }
    }
}
