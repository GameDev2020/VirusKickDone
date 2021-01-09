using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyWithLife : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] GameObject[] hearts;
    [SerializeField] int life;
    bool Flife = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled && Flife == true)
        {
            Destroy(other.gameObject);
            takeDamage();
        }
        if (other.tag == triggeringTag && enabled && Flife == false)
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    public void takeDamage()
    {
        this.life = this.life - 1;
        Destroy(hearts[life].gameObject);
        if (life < 1)
            Flife = false;
    }
}