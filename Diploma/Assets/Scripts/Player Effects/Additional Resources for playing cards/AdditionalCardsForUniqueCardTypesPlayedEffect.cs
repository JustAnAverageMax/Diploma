using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Effects/Additional Cards for unique card types played")]
public class AdditionalCardsForUniqueCardTypesPlayedEffect : PlayerEffect
{
    public int cardsGainedAmount;
    public int requiredPlayedCardAmount;

    public GameEvent onCardDrawn;

    public HashSet<CardType> playedCards = new HashSet<CardType>();

    public override void Execute(Component sender, object data)
    {
        CardAsset playedCard = data as CardAsset;

        if (playedCard != null)
        {
            playedCards.Add(playedCard.cardType);
        }

        if (playedCards.Count == requiredPlayedCardAmount)
        {
            Debug.Log(data);
            for (int i = 0; i < cardsGainedAmount; i++)
            {
                onCardDrawn.Raise(sender, data);
            }

            playedCards.Clear();
        }
    }
}