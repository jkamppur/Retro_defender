using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform cannon;
    // public float cannonMax;
    // public float shootCost;
    public float shootRate;
    private bool cannonReady;
    public GameObject ammo;
    public GameObject bomb;
    // public Transform transform;
    public GameControllerUfo gc;

    private AudioSource audioSource;
    private float playerNotMoved = 0.0f;
    private float cannonCoolDown = 0.0f;
    private int x_pos;
    private int old_x_pos;
    private bool warningActive = false;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Control start");
        rb = GetComponent<Rigidbody2D>();
        cannonReady = true;
        audioSource = GetComponent<AudioSource>();
        old_x_pos = (int) rb.position.x;
        GameControllerUfo.instance.ClearWarning();

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // Shooting
        if (Input.GetButton("Jump") && cannonReady)
        {
            cannonReady = false;
            audioSource.Play();
            shoot();
            Debug.Log(cannonReady);
            cannonCoolDown = 0.0f;
        }

        if (cannonReady == false) {
            cannonCoolDown += Time.deltaTime;

            if (cannonCoolDown >= shootRate)
                cannonReady = true;
        }






        // Notice if player not moving
        x_pos = (int) rb.position.x;
        

        if (Mathf.Abs(x_pos - old_x_pos) <= 2)
            playerNotMoved += Time.deltaTime;
        else {
            playerNotMoved = 0.0f;
            old_x_pos = x_pos;
            if (warningActive) {
                GameControllerUfo.instance.ClearWarning();
                warningActive = false;
            }
        }

        if (playerNotMoved > 5.0f && warningActive == false) {
            GameControllerUfo.instance.SetWarning("Move !");
            warningActive = true;
        }
        if (playerNotMoved > 7.0f) {
            GameControllerUfo.instance.ClearWarning();
            warningActive = false;
            playerNotMoved = 4.0f;
            old_x_pos = x_pos;

            for (int i=-7; i<=7; i=i+2)
            {
                Vector3 position = new Vector3(x_pos + i, 18, 0);
                Instantiate(bomb, position, new Quaternion());
            }


        }



        // if(Mathf.Abs(rb.velocity.x) == 0)
        // {
        //     timePassed += Time.deltaTime;
        // }
        // else
        //     timePassed = 0.0f;




        // Tank movement
        Vector3 move = rb.velocity;
        float dirX = Input.GetAxis("Horizontal");     // Input manager
        move.x = dirX * 5;            
        rb.velocity = move;

        // Over rotation blocking
        if (rb.rotation > 45)
            rb.rotation = 44;

        if (rb.rotation < -45)
            rb.rotation = -44;

        // Cannon up and down
        float dirY = Input.GetAxis("Vertical");
        
        if (dirY != 0)
        {
            AimCannon(dirY);
        }

    }


   private void AimCannon(float dirY)
    {

        // Allow rotate up
        if (-5f <= cannon.localEulerAngles.z && cannon.localEulerAngles.z < 180f && dirY > 0)
        {
            cannon.Rotate(0,0,dirY);
        } else if (0f < cannon.localEulerAngles.z && cannon.localEulerAngles.z < 270f && dirY < 0)
        // Allow rotate down
        {
            cannon.Rotate(0,0,dirY);
        }else if (270f < cannon.localEulerAngles.z && cannon.localEulerAngles.z <= 360f && dirY > 0)
        // Case where over rotated
        {
            cannon.Rotate(0,0,dirY);
        }
    }

    private void shoot() {
        GameObject bullet = Instantiate(ammo, cannon.position, cannon.rotation);
    }

}
