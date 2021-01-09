using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCollScript : MonoBehaviour
{
    public GameManager gm;
    private Transform previousPlatform;
    public string tag;
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] GameObject[] livesObj;
    [SerializeField] int life;
    bool Flife = true;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
      //  if (other.transform.tag == tag && Flife)
      //  {
       //     takeDamage();
      //  }
      // else
        if (other.transform.tag == tag)
        {
            gm.ResetLevel();
        }
    }

    public void takeDamage()
    {
        this.life = this.life - 1;
        //livesObj[life].gameObject.SetActive(false);
        if (life < 1)
            Flife = false;
    }


}
