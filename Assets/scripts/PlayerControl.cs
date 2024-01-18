using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform cannon;
    public float cannonMax;
    public float shootCost;
    private float cannonReady;
    public GameObject ammo;
    public Transform transform;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Control start");
        rb = GetComponent<Rigidbody2D>();
        cannonReady = cannonMax;
        transform = GetComponent<Transform>();

    }

 
    void Update()
    {
        // Notice trigger
        if (Input.GetButtonDown("Jump") && cannonReady >= shootCost)
        {
            cannonReady -= shootCost;
            shoot();
            Debug.Log(cannonReady);
        }

        if (cannonReady < cannonMax) {
            cannonReady += Time.deltaTime;
            if (cannonReady > cannonMax) {
                cannonReady = cannonMax;
            }
        }
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {


        // Tank movement
        Vector3 move = rb.velocity;
        float dirX = Input.GetAxis("Horizontal");     // Input manager
        move.x = dirX * 4;            
        rb.velocity = move;

        // Cannon up and down
        float dirY = Input.GetAxis("Vertical");
        
        if (dirY != 0)
        {
            AimCannon(dirY);
        }

        // Update cannonReady
        if (cannonReady < cannonMax){
            cannonReady = cannonReady + 0.1f; // TODO improve logic to increase
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
        // Debug.Log("shoot");
        //Debug.Log(cannon.position); // Sijainti
        // Debug.Log(cannon.rotation); // rotation
        //Debug.Log(cannon.rotation.eulerAngles); // rotation

        // Vector3 position = cannon.position + cannon.rotation.;




        // Vector3 position = new Vector3(cannon.position.x + cannon.position.y, cannon.position.z);
        // postions 


        //                              object   position      rotation
        GameObject bullet = Instantiate(ammo, cannon.position, cannon.rotation);




        // Miten lasketaan rotationin suuntaan sopiva aloituspaikka?

        // Miten laitetaan vauhti oikeaan suuntaan?
        // bullet.velocity = new Vector2d(5,5);



    }

}
