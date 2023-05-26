using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Effects/Additional Power for unique card type played Effect")]
public class AdditionalPowerForUniqueCardTypePlayedEffect : PlayerEffect
{
    public int powerGainedAmount;
    public int requiredCardCount;
    public GameEvent onPlayerEffectExecuted;
    public GameEvent onPowerChanged;
    
    public CardType trackedType;
    public HashSet<CardAsset> playedCards = new HashSet<CardAsset>();
    
    public override void Execute(Component sender, object data)
    {
        CardAsset playedCard = data as CardAsset;
    
        if (playedCard != null && playedCard.cardType != trackedType)
        {
            return;
        }

        if (!playedCards.Contains(playedCard))
        {
            if (playedCards.Count + 1 < requiredCardCount)
            {
                playedCards.Add(playedCard);
                return;
            }

            onPlayerEffectExecuted.Raise(sender, powerGainedAmount);
            onPowerChanged.Raise(sender, powerGainedAmount);
            playedCards.Clear();
            return;
        }
        
        playedCards.Add(playedCard);
    }
}
