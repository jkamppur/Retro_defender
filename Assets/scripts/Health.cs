using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
 
    public float health;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    public GameControllerUfo gameController;

    // Effects
    public GameObject explosion;
    private int spriteCount;
    private int activeSprite;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        activeSprite = -1;
        spriteCount = spriteArray.Length;
        maxHealth = health;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void reduceHealth(float damage)
    {
        health -= damage;

        Debug.Log("Health left " +  health);

        if (spriteArray.Length > 0) {
            float healthPerSprite = maxHealth / (spriteCount + 1);
            float spriteHealth = maxHealth - health;
            int spriteIndex = (int) (spriteHealth / healthPerSprite);
            if (spriteIndex > activeSprite && spriteIndex < spriteCount)
            {
                Debug.Log("TODO Change sprite");
                Debug.Log(spriteIndex);
                spriteRenderer.sprite = spriteArray[spriteIndex]; 
            }
        }


        // send ufo up
        if(gameObject.CompareTag("Ufo") &&  health <= 50 ){
            Debug.Log("Set UFO leaving state");
            ufo_controller uc = gameObject.GetComponent<ufo_controller>();
            uc.SetStateToLeave();

        }

        if (health <= 0) {


            if(gameObject.CompareTag("Ufo")){
                GameControllerUfo.instance.ufoDown();
                GameControllerUfo.instance.addScore(500);
            }

            if(gameObject.CompareTag("House")){
                Instantiate(explosion, transform.position, new Quaternion());
                GameControllerUfo.instance.houseDown();
            }

            Destroy(gameObject);




            // Report to Game Controller about destroyed object


        } else {
            if(gameObject.CompareTag("Ufo")){
                GameControllerUfo.instance.addScore(50);
            }

        }


    }

}
