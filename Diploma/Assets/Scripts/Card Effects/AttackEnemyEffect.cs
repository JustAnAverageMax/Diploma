using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Effects/Attack Enemy Effect")]
public class AttackEnemyEffect : CardEffect
{
    public int amount;
    public GameEvent onEnemyAttacked;
    public override void Execute(Component sender, object data)
    {
        onEnemyAttacked.Raise(sender, amount);
    }
}
