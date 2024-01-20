using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_controller : MonoBehaviour
{

    public GameObject explosion;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        Debug.Log(other.name);


        if (other.name != "Ufo") {

            Debug.Log(other.name);

            if (other.CompareTag("Ammo")) {
                Debug.Log("=================AMMO===================");
                GameControllerUfo.instance.addScore(10);
            }                        

            Destroy(gameObject);
    
            Health health = other.GetComponent<Health>();
    
            if (health == null) {
                Debug.Log("No Health script");
            } else {
                health.reduceHealth(30);
            }
    
            Instantiate(explosion, transform.position, new Quaternion());

        }
    }

}
