using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int maximumHitPoints = 3;
    public GameController gameController;

    private int currentHitPoints;

    public int GetCurrentHitPoints()
    {
        return currentHitPoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maximumHitPoints;
    }

    public void TakeDamage(int damageAmount)
    {
        ModifyHitPoints(-damageAmount);
    }

    public void HealDamage(int healAmount)
    {
        ModifyHitPoints(healAmount);
    }

    private void ModifyHitPoints (int modAmount)
    {
        currentHitPoints += modAmount;

        if (currentHitPoints > maximumHitPoints)
        {
            currentHitPoints = maximumHitPoints;
        }

        if (currentHitPoints <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        gameController.GameOver();

    }

}
