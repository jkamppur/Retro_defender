using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{

    public float ammoSpeed;
    private Rigidbody2D rb;
    private float t;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = 10f; // time for ammo to be destroyed

        // Calculate velocity for ammo
        float compx = Mathf.Sin(rb.rotation * Mathf.PI / 180);
        float compy = Mathf.Cos(rb.rotation * Mathf.PI / 180);

        float speed = 30f;  // ammo speed
        rb.velocity = new Vector2(compy * speed, compx * speed);

        // float rotation = Mathf.Atan(rb.velocity[0]/rb.velocity[1]) * 180 / Mathf.PI;
        rb.rotation-=90;
        Debug.Log(rb.rotation);

        // rb.rotation=rotation + 180f ;




    }

    // Update is called once per frame
    void Update()
    {
        t -= Time.deltaTime;
        if (t<=0) {
            Destroy(gameObject);
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log(rb.velocity[0]);

        // rb.rotation=270;


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        Debug.Log(other.name);
        Destroy(gameObject);

        Health health = other.GetComponent<Health>();

        if (health == null) {
            Debug.Log("No Health script");
        } else {
            health.reduceHealth(10);
            Instantiate(explosion, transform.position, new Quaternion());

        }
    }







}
