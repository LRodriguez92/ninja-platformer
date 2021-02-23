using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public int damage = 1;

    public bool destroyOnCollision = false;

    public int faction = 0;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();

        if (destructible != null && faction != destructible.faction)
        {
            // Do damnage
            destructible.TakeDamage(damage);

            if (destroyOnCollision)
            {
                Destroy(gameObject, 0.1f);
            }
        }

    }
}
