using UnityEngine;
using Assets.Scripts;
using System.Collections;
using System;

public class Spear : MonoBehaviour, Weapons
{
    public int m_damage;
    
    int Weapons.damage
    {
        get { return m_damage; }
    }
}
