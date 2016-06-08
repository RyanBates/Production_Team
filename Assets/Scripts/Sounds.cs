using UnityEngine;

using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{
    
    [SerializeField]
    private List<AudioClip> _clips;
    public static Sounds singleton;

    void Start()
    {
        Projectial.CannonFireEvent.AddListener(PlayCannonFire);
    }

    public void PlayCannonFire()
    {
        GetComponent<AudioSource>().clip = _clips[0];
        GetComponent<AudioSource>().Play();
    }
}
