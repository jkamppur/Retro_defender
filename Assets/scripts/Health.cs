using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
 
    public float health;
    public Sprite[] spriteArray;
    private int spriteCount;
    private int activeSprite;
    private float maxHealth;
    public SpriteRenderer spriteRenderer;
    public GameControllerUfo gameController;


    // Start is called before the first frame update
    void Start()
    {
        activeSprite = -1;
        spriteCount = spriteArray.Length;
        maxHealth = health;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // GameController = gameObject.GetComponent<GameController>();
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

        if (health <= 0) {


            if(gameObject.CompareTag("Ufo")){
                GameControllerUfo.instance.ufoDown();
            }
            Destroy(gameObject);

            // Report to Game Controller about destroyed object


        }


    }

}
