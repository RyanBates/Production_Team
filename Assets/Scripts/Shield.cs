using UnityEngine;
using Assets.Scripts;
using System.Collections;
using System;

public class Shield : MonoBehaviour, Weapons
{
    private int m_damage = 0;

    public int health = 3;

    public int damage
    {
        get { return m_damage; }
    }
    
    
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.RotateAround(transform.parent.position, transform.up, 90);
        }
	}
}
