using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Effects/Additional resource for unique card types played")]
public class AdditionalResourcesGainedBasedOnUniqueCardTypesPlayed : PlayerEffect
{
    public int resourcesGainedAmount;
    public int requiredPlayedCardAmount;

    public GameEvent onResourсesRecieved;
    

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
            for (int i = 0; i < resourcesGainedAmount; i++)
            {
                onResourсesRecieved.Raise(sender, resourcesGainedAmount);
            }
            
            playedCards.Clear();
        }
    }
}
