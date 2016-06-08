using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public float currentHP;
    public Slider healthbar;

    public UnitAttributes Unit;
    UnitAttributes AI;

    public void takedamage(float amount)
    {
        currentHP -= amount;
        currentHP = Unit.health;
        healthbar.value = currentHP;
    }

    void Update()
    {
        healthbar.value = Unit.health;
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.up);
    }
}