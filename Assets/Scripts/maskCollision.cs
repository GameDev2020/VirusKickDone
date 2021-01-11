using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskCollision : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("We hit: " + other.name);
        if (other.transform.tag == "Virus")
            {
                Destroy(this);
        }
        
        if (other.transform.tag == "Alien")
        {            
            GameObject mask=other.transform.parent.parent.Find("mask 1").gameObject;
            mask.SetActive(true);
            Destroy(this);
        }

    }
}

