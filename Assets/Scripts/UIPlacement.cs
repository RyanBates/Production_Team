using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPlacement : MonoBehaviour
{
    public Text pos;

    public RaceManager position;

    public GameObject player;
    
    void Update()
    {
        pos.text = position.UnitList.IndexOf(player).ToString();

    }
}
