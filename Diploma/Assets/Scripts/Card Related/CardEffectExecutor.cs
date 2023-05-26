using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectExecutor : MonoBehaviour
{
    public GameEvent onCardEffectExecuted;
    public void Execute(Component sender, object data)
    {
        CardAsset cardAsset = (CardAsset) data;
        foreach (var cardEffect in cardAsset.cardEffects)
        {
            cardEffect.Execute(sender, data);
        }

        onCardEffectExecuted.Raise(sender, data);
    }
}
