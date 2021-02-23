using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int maximumHitPoints = 3;
    public GameController gameController;

    public int faction = 0;

    private int currentHitPoints;
    private Animator animator;

    public int GetCurrentHitPoints()
    {
        return currentHitPoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maximumHitPoints;
        animator = GetComponent<Animator>();
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
        if (animator != null)
        {
            animator.SetTrigger("dead");
        }

        if(gameObject.tag == "Player")
        {
            gameController.GameOver();
        }

        Destroy(gameObject, 0.1f);
    }

}
