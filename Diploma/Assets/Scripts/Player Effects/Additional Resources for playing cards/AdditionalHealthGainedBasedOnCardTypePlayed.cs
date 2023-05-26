using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Effects/Additional Health Gained Based On Card Type Played Effect")]
public class AdditionalHealthGainedBasedOnCardTypePlayed : PlayerEffect
{
    private int amountRecovered;
    public CardType trackedType;

    public GameEvent onHealthGained;
    
    public override void Execute(Component sender, object data)
    {
        CardAsset cardAsset = data as CardAsset;

        if (sender is not ClickableCard)
        {
            return;
        }
        
        if (cardAsset != null && cardAsset.cardType == trackedType)
        {
            amountRecovered = cardAsset.cardScoreValue;
            onHealthGained.Raise(sender, amountRecovered);
        }
    }
}
