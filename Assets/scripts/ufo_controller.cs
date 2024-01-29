using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ufo_controller : MonoBehaviour
{
    public float radius;
    public float maxX;
    public float minX;
    public GameObject bomb;
    public float bombTimer;
    public GameControllerUfo gameController;


    private Transform transform;
    private Rigidbody2D rb;
    private float speedX;
    private float speedY;
    private float timer;

    private enum State {landing, leaving, left, right};
    private State state;
    private bool bombing = false;




    // Start is called before the first frame update
    void Start()
    {
        transform  = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        speedX=0;
        speedY=-0.8f;
        state=State.landing;
        rb.velocity = new Vector2(speedX, speedY);
        bombing = false;
        timer = 5; // Time between
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.landing) {
            if (transform.position.y < 15) {
                speedY=0;
                timer = bombTimer;
                bombing = true;
                if (Random.Range(0, 2) == 0 )  {
                    state = State.left;
                    speedX = -2;
                } else {
                    state = State.right;
                    speedX = 2;
                }
                rb.velocity = new Vector2(speedX, speedY);
            }
        } else if (state == State.left) {
            if ( transform.position.x < minX ) {
                speedX = 2;
                state = State.right;
                rb.velocity = new Vector2(speedX, speedY);
            }
        } else if (state == State.right) {
            if (transform.position.x > maxX) {
                speedX = -2;
                rb.velocity = new Vector2(speedX, speedY);
                state = State.left;
            }
        } else if (state == State.leaving) {
                if (transform.position.y <= 15) {
                    speedY=1.5f;
                    speedX=0;
                    bombing = false;
                    rb.velocity = new Vector2(speedX, speedY);
                } else if (transform.position.y >= 20) {
                    Destroy(gameObject);
                    GameControllerUfo.instance.ufoDown();
                }

        }


        // rb.velocity = new Vector2(speedX, speedY);

        if (bombing) {
            timer -= Time.deltaTime;
            if (timer <= 0 ){
                // bomb
                Instantiate(bomb, transform.position, new Quaternion());
                timer = bombTimer;
        }
        }


        // Find Target
        // Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        // for(int i = 0; i < colliders.Length; i++)
        // {
        //     Tag = coll
        //     if(health != null)
        //     {
        //         health.reduceHealth(damage);
        //     }
        //     //Destroy(colliders[i].gameObject);
        // }

    }

    public void SetStateToLeave() {
        state = State.leaving;
    }

}
