using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScriptColl : MonoBehaviour
{
    public GameManager gm;
    private Transform previousPlatform;
    public string tag;
    private GameObject player;
    private GameObject Virus;
    [SerializeField] 
    public GameObject[] hearts;
    [SerializeField] int life;
    private bool Flife=true;
    private bool flag = true;



    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    private void Update()
    {        
        player = GameObject.FindGameObjectWithTag("Player"); //define player object.
        Virus = GameObject.FindGameObjectWithTag("VirusColl"); //define player object.

        if (life < 1)
            Flife = false;
          
            GameManager.onGameStart += init;


    }

  
    public void init()
    {
        Flife = true;
        life = 3;
    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (player.transform.GetChild(3).gameObject!=null&&!player.transform.GetChild(3).gameObject.activeSelf)
        {
            if ((other.transform.tag == "Virus") && Flife)
            {
                Virus.gameObject.SetActive(false);
                if (flag)
                {
                    takeDamage();
                    flag = false;
                    other.gameObject.SetActive(false);

                }
            }
            else
            if ((other.transform.tag == "Virus") && !Flife)
            {
                player.SetActive(false);
                gm.ResetLevel();
                Virus.gameObject.SetActive(false);
                other.gameObject.SetActive(false);
            }
        }
        flag = true;
    }

    public void takeDamage()
    {
        this.life = this.life - 1;
        if (life >= 0)
        {
            hearts[life].gameObject.SetActive(false);
        }
    }


}
