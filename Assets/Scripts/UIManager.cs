using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameManager gm;

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.startGame)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        } 
    }
}
