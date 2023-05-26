using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth = 25;
    private int defaultHealth = 20;
    [SerializeField] private Transform[] hpSlots;

    [Header("Events")]
    public GameEvent onPlayerDied;
    public GameEvent onHealthModified;
    
    void Start()
    {
        hpSlots = GetComponentsInChildren<Transform>();
        hpSlots = hpSlots.Skip(1).ToArray();
        currentHealth = defaultHealth;
    }

    public void GainHP(Component sender, object data)
    {
        int amount = (int)data;
        ModifyHealth(sender, amount);
    }

    public void LoseHP(Component sender, object data)
    {
        int amount = (int)data;
        ModifyHealth(sender, -amount);
    }

    private void ModifyHealth(Component sender, int amount)
    {
        int newHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
    
        if (currentHealth <= 0)
        {
            currentHealth = defaultHealth;
            onPlayerDied.Raise(this, sender);
        }
        onHealthModified.Raise(this, hpSlots[currentHealth - 1].localPosition);
    }
}
