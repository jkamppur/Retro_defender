using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerUfo : MonoBehaviour
{

    public static int scores;

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
    private int wave;
    private int ufos_per_wave;
    private int active_ufos;
    private bool PlayerUnderInstantiate;
    // private int scores;
    //  private boolean player_alive;


    private void Awake() {
        instance = this;
        wave = 1;
        ufos_per_wave = no_on_ufos;
        active_ufos = 0;
        no_of_houses = 5;
    }

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("GameController start");
        Time.timeScale = 1f;
        PlayerUnderInstantiate = true;


        // Player
        spawnPlayer(false);
        ui.SetLives(no_of_players);


        // Score
        scores = 0;
        ui.SetScores(scores);

        ui.InfoWave(wave);


        // Ufo
        spawnUfo();

    }

    // Update is called once per frame
    void Update()
    {

        if (player == null && !PlayerUnderInstantiate) {
            no_of_players = no_of_players - 1;
            if (no_of_players < 0){
                Debug.Log("Game Over");
                // ui.ShowGameOverScreen("All tanks destroyed", scores);
                GotoEndScreen();
            } else {
                spawnPlayer(true);
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
        active_ufos++;


    }

    private void alertUfo(float playerX, float ufoX) {
        Debug.Log("alertUfo");
        Debug.Log(playerX);
        Debug.Log(ufoX);

        float dist = ufoX - playerX;

        int level = (int) dist/10;

        ui.AlertUfo(level);
    }

    public async Task GotoEndScreen() {
        await Task.Delay(2000);
        ui.ShowGameOverScreen("All tanks destroyed", scores);
    }



    public async Task spawnPlayer(bool delay) {
        // float x_pos = 28.5f;
        // float y_pos = 1.5f;
        PlayerUnderInstantiate = true;

        if (delay) {
            await Task.Delay(2000);
        }

        Debug.Log("Spawnplayer");


        // Spawn player
        float x_pos = 4f;
        float y_pos = 0f;

        Vector3 position = new Vector3(x_pos, y_pos, -0.5f);
        player = Instantiate(player_prefab, position, new Quaternion());

        PlayerUnderInstantiate = false;


        // Set camera target to spawned player
        Transform transform = player.GetComponent<Transform>();

        GameObject cam = GameObject.Find("Main Camera");
        cs = cam.GetComponent<SmoothCameraFollow>();
        cs.setTarget(transform);

    }

    public async Task houseDown(){
        no_of_houses--;
        if (no_of_houses == 0){
            await Task.Delay(2000);
            ui.ShowGameOverScreen("All Buildings were destroyed", scores);
        }
    }

    public async Task ufoDown(){

        active_ufos--;
        if (no_on_ufos > 0) {
            no_on_ufos--;
            spawnUfo();
        }

        else {

            if(active_ufos == 0){
                switch(wave){

                    case 1:
                        Debug.Log("wave 1 win");
                        wave++;
                        ui.InfoWave(wave);
                        addScore(1000 * no_of_houses);
                        no_on_ufos = ufos_per_wave  + 1;
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        break;

                    case 2:
                        Debug.Log("wave 2 win");
                        wave++;
                        ui.InfoWave(wave);
                        addScore(2000 * no_of_houses);
                        no_on_ufos = ufos_per_wave + 2;
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        break;

                    case 3:
                        Debug.Log("wave 3 win");
                        wave++;
                        ui.InfoWave(wave);
                        addScore(3000 * no_of_houses);
                        no_on_ufos = ufos_per_wave + 3;
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        break;

                    case 4:
                        Debug.Log("wave 4 win");
                        ui.InfoWave(wave);
                        addScore(4000 * no_of_houses);
                        wave++;
                        no_on_ufos = ufos_per_wave + 4;
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        await Task.Delay(3000);
                        spawnUfo();
                        break;


                    case 5:
                        Debug.Log("wave 5 win");
                        addScore(5000 * no_of_houses);
                        SceneManager.LoadScene("end_screen");
                        Debug.Log("Level win Scene load done");
                        break;
                }
            }
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
