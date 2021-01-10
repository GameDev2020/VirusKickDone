using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskCollision : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    { 
        if (other.transform.tag == "Virus")
            {
                Destroy(this);
        }
        
        if (other.transform.tag == "Alien")
        {
            Debug.Log("Collision With Enemy Detected! " + other.transform.name);
            GameObject mask=other.transform.parent.parent.GetChild(0).gameObject;
            mask.SetActive(true);
            Destroy(this);
        }

    }
}

