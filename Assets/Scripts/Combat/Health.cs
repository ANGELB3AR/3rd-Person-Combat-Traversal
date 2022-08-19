using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;

    public event Action OnTakeDamage;
    public event Action OnDie;

    int health;
    bool isInvulnerable;

    public bool isDead => health == 0;

    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(int damage)
    {
        if (health == 0) { return; }

        if (isInvulnerable) { return; }

        health = Mathf.Max(health - damage, 0);

        OnTakeDamage?.Invoke();

        Debug.Log(health);

        if (health == 0)
        {
            OnDie?.Invoke();
        }
    }

    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;
    }
}
