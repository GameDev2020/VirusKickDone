using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCollScript : MonoBehaviour
{
    public GameManager gm;
    private Transform previousPlatform;
    public string tag;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //define player object.
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (!player.transform.GetChild(3).gameObject.activeInHierarchy)
            {
                if (other.transform.tag == tag)
                {
                    player.SetActive(false);
                    gm.ResetLevel();
                }
            }
    }


}
