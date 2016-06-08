using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    private static Music _play;

    // Use this for initialization
    void Start () {
        _play = gameObject.GetComponentInChildren<Music>();
        DontDestroyOnLoad(this);
    }

    public void OnLevelWasLoaded(int level)
    {
        if (level >= 3)
        {
            GameObject.FindObjectOfType<Music>();
            _play.gameObject.SetActive(false);
        }

        else
        {
            _play.gameObject.SetActive(true);
        }
    }
}
