using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Card Effects/Card Gain Effect")]
public class CardGainEffect : CardEffect
{
    [SerializeField] public int cardsToGain;
    public GameEvent onCardGained;
    public override void Execute(Component sender, object data)
    {
        for (int i = 0; i < cardsToGain; i++)
        {
            onCardGained.Raise(sender, data);
        }
    }
}
