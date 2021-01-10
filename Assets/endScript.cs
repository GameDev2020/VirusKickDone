using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endScript : MonoBehaviour
{

    public string mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        // loads the menu scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);

    }
}
