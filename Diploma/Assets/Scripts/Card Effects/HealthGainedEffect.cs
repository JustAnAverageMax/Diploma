using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Effects/Health Gain Effect")]
public class HealthGainedEffect : CardEffect
{
    [SerializeField] public int healthToGain;
    public GameEvent onHealthGained;
    public override void Execute(Component sender, object data)
    {
        onHealthGained.Raise(sender, healthToGain);
    }
}
