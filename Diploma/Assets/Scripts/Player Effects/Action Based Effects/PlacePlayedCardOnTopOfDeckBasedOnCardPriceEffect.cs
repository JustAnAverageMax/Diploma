using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Effects/Place Played Card On Top Of Deck Based On Card Price Effect")]
public class PlacePlayedCardOnTopOfDeckBasedOnCardPriceEffect : PlayerEffect
{
    public GameEvent onCardPlacedOnTopOfDeck;
    public int triggerPrice;

    internal int cardPrice;
    public override void Execute(Component sender, object data)
    {
        if (sender is not TurnManager)
        {
            return;
        }
        ClickableCard card = data as ClickableCard;
        if (card.GetComponent<CardDataLoader>().cardAsset.cardPrice <= triggerPrice)
        {
            
            onCardPlacedOnTopOfDeck.Raise(sender, card);
            
        }
    }
}
