using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Effects/Look at top deck card based on card played effect")]
public class LookAtTopDeckCardBasedOnCardPlayedEffect : PlayerEffect
{
    public GameEvent onTopDeckCardLooked;
    public CardType trackedType;

    public override void Execute(Component sender, object data)
    {
        if (sender is not ClickableCard)
        {
            return;
        }
        CardAsset cardAsset = data as CardAsset;
        if (cardAsset != null && cardAsset.cardType == trackedType)
        {
            onTopDeckCardLooked.Raise(sender, cardAsset);
        }
    }
}
