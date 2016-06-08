using UnityEngine;
using Assets.Scripts;
using UnityEngine.Events;
using System.Collections;

public class Projectial : MonoBehaviour, Weapons
{
    public class CannonEvent : UnityEvent
    {

    }
    public static CannonEvent CannonFireEvent;
  
    void Awake()
    {
        if (CannonFireEvent == null)
            CannonFireEvent = new CannonEvent();
    }

    public int m_damage;
    public GameObject bullet;
    public Transform bulletspawn;

    float nextfire;
    public float firerate;

    void Start()
    {
        nextfire = 0;
    }

    int Weapons.damage
    {
        get { return m_damage; }
    }
    
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextfire)
        {
            GameObject temp;
            Player_Move playerMove = gameObject.transform.GetComponentInParent<Player_Move>();
            temp = Instantiate(bullet, bulletspawn.transform.position, new Quaternion()) as GameObject;
            CannonFireEvent.Invoke();
            temp.GetComponent<Bullet_Control>().unitFired = gameObject.transform.parent.gameObject;
            temp.GetComponent<Rigidbody>().velocity = playerMove.maxSpeed * 1.5f * transform.forward;
            temp.GetComponent<Bullet_Control>().SetForce(transform.forward * playerMove.speed);

            nextfire = Time.time + firerate;
        }    
	}
}