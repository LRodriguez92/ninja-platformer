using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileController : MonoBehaviour
{

    public float projectileForce = 10f;

    [Tooltip("If true, the projectile will move only once. If false, the projectile will move continuously")]
    public bool oneTimeForce = true;

    public float timeUntilDestroy = 1f;

    private Rigidbody2D myRigidbody2D;
    private Vector3 direction;
    private bool doneSetup = false;

    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        Destroy(gameObject, timeUntilDestroy);
    }


    public void Setup(Vector3 newDirection)
    {
        direction = newDirection;

        if (oneTimeForce)
        {
            myRigidbody2D.AddForce(direction * projectileForce);
        }

        doneSetup = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (doneSetup && oneTimeForce == false)
        {
            myRigidbody2D.AddForce(direction * projectileForce);
        }
    }
}
