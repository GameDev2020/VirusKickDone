using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMask : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    GameObject[] MaskArray = GameObject.FindGameObjectsWithTag("AlienMask");
        if (MaskArray.Length > 0 && !gm.disabledOnce)
        {
            for (int j = 0; j < MaskArray.Length; j++)
            {                
                GameObject go = MaskArray[j];
                go.SetActive(false);
                gm.disabledOnce = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
