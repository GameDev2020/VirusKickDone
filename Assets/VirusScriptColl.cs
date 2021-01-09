using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScriptColl : MonoBehaviour
{
    public GameManager gm;
    private Transform previousPlatform;
    public string tag;
    private GameObject player;
    [SerializeField] 
    public GameObject[] hearts;
    [SerializeField] int life;
    private bool Flife=true;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //define player object.
        gm = GameManager.Instance;
    }

    private void Update()
    {
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
        if (!player.transform.GetChild(3).gameObject.activeSelf)
        {
            if (other.transform.tag==tag && Flife)
            {
                takeDamage();
            }
            else
            if (other.transform.tag == tag && !Flife)
            {
                player.SetActive(false);
                gm.ResetLevel();
            }
        }
    }

    public void takeDamage()
    {
        this.life = this.life - 1;
        hearts[life].gameObject.SetActive(false);
    }


}
