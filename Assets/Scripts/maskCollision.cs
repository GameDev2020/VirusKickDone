using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskCollision : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("The Mask hitted: "+other.name);
        if (other.transform.tag == "Virus")
            {
                Destroy(this);
        }
        
        if (other.transform.tag == "Alien")
        {
            int childCount=other.transform.parent.parent.childCount;
            Debug.Log(other.transform.parent.name);
            GameObject mask=other.transform.parent.parent.Find("mask 1").gameObject;
            Debug.Log(mask.name);
            mask.SetActive(true);
            Destroy(this);
        }

    }
}

