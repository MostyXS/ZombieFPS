using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;
    public bool GetDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("Death");
        isDead = true;
        
    }
}
