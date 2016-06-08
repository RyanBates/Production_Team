using UnityEngine;
using System.Collections.Generic;

public class Player_Move : MonoBehaviour
{
    public float speed;         //How fast is the Unit moving
    public float maxSpeed;      //What is the fastes possible speed for a Unit to move at
    public float acceleration;  //How much speed is added when able to accelerate.
    public float handling;      //How fast can the Unit turn?
    float rotate;               //Number telling which way to rotate
    Transform unitTransform;

    Vector3 forward;    //This Vector will referance the forward of an object.

    // Use this for initialization
    void Start()
    {
        unitTransform = gameObject.GetComponent<Transform>();
        speed = 0;                                              //Set speed
        forward = Vector3.forward / 100;                        //Scaling the forward. Vector3.forward was too much by itself     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed > 0)
            rotate = Input.GetAxis("Horizontal");             //Will get Unit's forward 

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))    //If player pushes down the "gas"
        {
            if (speed < maxSpeed)    //If the Unit Isn't going at max speed
            {
                speed += acceleration;  //add speed
            }
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (speed > -maxSpeed / 4)    //If the Unit Isn't going at max speed
            {
                speed -= acceleration;  //add speed
            }
        }

        else    //else if no gas
        {
            if(speed < 0)   //if going backwards
            {
                speed += .3f;
            }

            else if(speed > 0)  //if going forewards
            {
                speed -= .3f;
            }

            if(speed <= .15f && speed >= -.15f) //close to still
            {
                speed = 0f;
            }
        }

        if (rotate != 0 && (speed > 0 || speed < 0))      //if we have input and we are moving
        {
            if (speed / maxSpeed < .5f)  //Prevents player from spinning out at low speeds
                gameObject.transform.Rotate(new Vector3(0f, rotate * (handling + (handling * .5f)) / 50, 0f));    //Rotate
            else
                gameObject.transform.Rotate(new Vector3(0f, rotate * (handling / (speed / maxSpeed)) / 50, 0f));    //Rotate    
        }

        MoveUnit(); //Function that actually moves the Unit
        
    }

    void MoveUnit()
    {
        if (speed >= maxSpeed)  //If going faster than max speed
        {
            unitTransform.Translate(forward * maxSpeed, Space.Self);    //move at max speed
        }

        else       //else if not going at max speed
        {
            unitTransform.Translate(forward * speed, Space.Self);   //move at speed
        }
    }
}
