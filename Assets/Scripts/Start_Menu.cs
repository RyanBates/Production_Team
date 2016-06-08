using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Start_Menu: MonoBehaviour
{ 
    void Update()
    {
        if (Input.GetButton("Vehicles"))
         SceneManager.LoadScene("Vehicles");

        if (Input.GetButton("HowToPlay"))
            SceneManager.LoadScene("Controls");
    }
}