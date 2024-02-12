using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerUfo : MonoBehaviour
{

    public float min_x;
    public float max_x;
    public int no_on_ufos; 
    public int no_of_simultaneous_ufos;
    public int no_of_players; 
    public int no_of_houses;
    public float ufo_spawn_delay;
    
    
    public GameObject ufo;
    public GameObject player_prefab;
    public static GameControllerUfo instance;
    public UIController ui;
    
    
    private SmoothCameraFollow cs;
    private GameObject camera_target;
    private GameObject player;
    private int scores;
    //  private boolean player_alive;


    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("GameController start");
        Time.timeScale = 1f;

        // Player
        spawnPlayer();
        ui.SetLives(no_of_players);


        // Score
        scores = 0;
        ui.SetScores(scores);

        // Ufo
        no_on_ufos = no_on_ufos - 1;    
        spawnUfo();

    }

    // Update is called once per frame
    void Update()
    {

        if (player == null) {
            no_of_players = no_of_players - 1;
            if (no_of_players < 0){
                Debug.Log("Game Over");
                ui.ShowGameOverScreen("All tanks destroyed", scores);
            } else {
                spawnPlayer();
            }
            Debug.Log("GameController call SetLives");
            ui.SetLives(no_of_players);
        }

    }


    private void spawnUfo() {
        float y_pos = 18;
        float x_pos = min_x + ((max_x - min_x) * Random.value);
        // float x_pos = Mathf.NextDouble(min_x, max_x);

        Vector3 position = new Vector3(x_pos, y_pos, 0);

        Instantiate(ufo, position, new Quaternion());

        Transform transform = player.GetComponent<Transform>();        

        alertUfo(transform.position.x, x_pos);


    }

    private void alertUfo(float playerX, float ufoX) {
        Debug.Log("alertUfo");
        Debug.Log(playerX);
        Debug.Log(ufoX);

        float dist = ufoX - playerX;

        int level = (int) dist/10;

        ui.AlertUfo(level);
    }


    private void spawnPlayer() {
        // float x_pos = 28.5f;
        // float y_pos = 1.5f;

        Debug.Log("Spawnplayer");


        // Spawn player
        float x_pos = 4f;
        float y_pos = 0f;

        Vector3 position = new Vector3(x_pos, y_pos, -0.5f);
        player = Instantiate(player_prefab, position, new Quaternion());


        // Set camera target to spawned player
        Transform transform = player.GetComponent<Transform>();

        GameObject cam = GameObject.Find("Main Camera");
        cs = cam.GetComponent<SmoothCameraFollow>();
        cs.setTarget(transform);

    }

    public void ufoDown(){
        if (no_on_ufos > 0) {
            no_on_ufos--;
            spawnUfo();

        }

        else {
            Debug.Log("Level win");
        }
    }

    // Score     Hit Ammo        10
    //           Hit Ufo         50
    // Destroy   Ufo             500


    public void addScore(int score){
        scores += score;

        ui.SetScores(scores);

    }



}
