using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

    public GameObject projectilePrefab;

    [Tooltip("A child object placed where the projectile will spawn from")]
    public Transform spawnPoint;

    private Vector3 direction;

    public void SetDirection(Vector3 newDirection)
    {
        // Makes sure the range is between 0 - 1 and doesn't go passed 1
        newDirection = Vector3.Normalize(newDirection);


        direction = newDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        // Instantiate a copy of a projectile prefab
        GameObject newProjectile = Instantiate(projectilePrefab) as GameObject;

        // Set its position to the position of our spawn point
        newProjectile.transform.position = spawnPoint.position;

        // Check if this new spawned object has a ProjectileController
        ProjectileController projectileController = newProjectile.GetComponent<ProjectileController>();

        if(projectileController != null)
        {
            // If it does, set it up with our direction so it can start flying
            projectileController.Setup(direction);
        }
        else
        {
            Debug.LogWarning("Oh no! Projectile did not have a controller!");
        }
    }
}
