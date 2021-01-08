using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; set; } //access to gameManager in another scripts.

    [SerializeField]  // game speed start to end
    public float SpeedMin = 1;  
    [SerializeField]
    public float SpeedMax = 1.5f;
    [SerializeField]
    public float nextLeveltime;
    public float RotateSkybox=1.2f;

    private float time = 0;
    public string scene;
    private GameObject Player;

    public float CurrentGameSpeed { get; set; }
   

    public bool startGame { get; set; }

    public delegate void OnGameStart(); // events help to know if the game is running. (helpful in another scripts)
    public static event OnGameStart onGameStart;
    public static event OnGameStart onGameEnd;

    public int Score { get; set; }
    public int HighScore{ get; set; }

    float timer = 0.0f;
    private Vector3 initPlayer;


    private void Awake()
    {
        Instance = this;
        CurrentGameSpeed = 0;        
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //define player object.
        initPlayer = transform.position;
        Player.transform.GetChild(3).gameObject.SetActive(false);
        startGame = false; // the game has not started yet
        PlayerChildColl.onCollision += ResetLevel; // initialize the game
        StartCoroutine(WaitForSpace()); //waiting for press space key to start
    }


    IEnumerator WaitForSpace()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); //waiting for press space
        GameStart(); //start game 
    }

    private void GameStart()
    {
        Player.SetActive(true);
        //disables the masks on alien faces
        GameObject[] MaskArray = GameObject.FindGameObjectsWithTag("Mask");
        if (MaskArray.Length > 0)
        {            
            for (int i = 0; i < MaskArray.Length; i++)
            {
                GameObject go = MaskArray[i];
                go.SetActive(false);
            }
        }
        onGameStart(); // update the event as active game.
        CurrentGameSpeed = SpeedMin; // initalize the first speed.
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSkybox);
        if (startGame)
        {
            timer += Time.deltaTime * CurrentGameSpeed;
            Score = Convert.ToInt32(timer);

            if(CurrentGameSpeed< SpeedMax)  // define game acceleration
                CurrentGameSpeed += Time.deltaTime / 500;

            
            time += Time.deltaTime;
            if (GameManager.Instance.CurrentGameSpeed != 0)
            {
                if (time > nextLeveltime / GameManager.Instance.CurrentGameSpeed) //the level is ended , loading next level after x seconds.
                {
                    ResetLevel();     
                    SceneManager.LoadScene(scene);

                }
            }
        }

        if (Player.transform.position.y < -5)
        {
            if (Player.transform.GetChild(3).gameObject.activeSelf)
            {
                Player.transform.position = initPlayer + Vector3.one;
                Player.transform.GetChild(3).gameObject.SetActive(false);

            }
            else
            {
                Player.SetActive(false);
                ResetLevel();
            }
        }

    }
    

    public void ResetLevel()
    {
        //onGameEnd();
        //data reset
        time = 0;
        CurrentGameSpeed = 0;
        startGame = false;
        timer = 0;
        StartCoroutine(WaitForSpace());
        Player.transform.GetChild(3).gameObject.SetActive(false);

    }
}
