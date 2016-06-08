using UnityEngine;
using System.Collections;

public class Bullet_Control : MonoBehaviour
{
    public float damage;
    public GameObject unitFired;
    float pretime;
    public float force;
    public float timea; // when were alive.
    float timed; // when we die.
    Vector3 preVector;
    Rigidbody rb;

    Vector3 Force;

	void Start ()
    {
        pretime = 0;
        force = 0;
        preVector = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
        timed = Time.time;
        
    }
	
	void Update ()
    {
        float timeint = Time.time - pretime;
        Vector3 Dis = gameObject.transform.position - preVector;
        force = Dis.sqrMagnitude / timeint;
        if (Time.time >= timed + timea)
            Destroy(gameObject);

        rb.AddForce(Force * 25);
	}

    public void SetForce(Vector3 f)
    {
        Force = f;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject != unitFired)
            Destroy(gameObject);
    }
}