using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject initPlatform;
    [SerializeField]
    private GameObject startPlatform;
    [SerializeField]
    private float space = 40;
    [SerializeField]
    private float spawnCountTimeMax = 1f;
    private GameObject ground;


    private Transform previousPlatform;
    private GameManager gm;

    private float spawnCountTime;



    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        GameManager.onGameStart += Reset;
        ground = GameObject.FindGameObjectWithTag("Ground"); 

    }

    private void Reset()
    {
        if (this != null)
        {
            startPlatform.SetActive(true);
            previousPlatform = initPlatform.transform;
        }
        PlatformPooler.Instance.DeactivateAllObject();
    }

    private void Update()
    {
        if (gm.startGame)
        {
            if (spawnCountTime > 0)
            {
                spawnCountTime -= Time.deltaTime;
            }
            else
            {
                spawnCountTime = spawnCountTimeMax / gm.CurrentGameSpeed;
                InstantiatePlatforms();
            }
        }
    }

    private void InstantiatePlatforms()
    {
        GameObject platform = PlatformPooler.Instance.GetPooledObject();
        if (platform != null)
        {
            platform.transform.position = new Vector3(0, 0, previousPlatform.position.z + space);
            previousPlatform = platform.transform;
            platform.SetActive(true);
            if (platform.transform.childCount != 0)
            {
               platform.transform.GetChild(0).gameObject.SetActive(true);                
            }
        }
    }
}


