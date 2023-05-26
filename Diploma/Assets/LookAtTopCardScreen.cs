using UnityEngine;

public class LookAtTopCardScreen : MonoBehaviour
{
    public GameObject card;
    public GameEvent onCardReturnedToDeck;
    public GameEvent onScreenRemoved;
    public GameEvent onCardMovedToDiscardPile;

    public void SetCardAsset(CardAsset cardAsset)
    {
        CardDataLoader cardDataLoader = card.GetComponent<CardDataLoader>();
        cardDataLoader.cardAsset = cardAsset;
        cardDataLoader.LoadCardData();

    }

    public void LeaveCard()
    {
        onCardReturnedToDeck.Raise(this, card);
        onScreenRemoved.Raise(this, card);
    }

    public void DiscardCard()
    {
        onCardMovedToDiscardPile.Raise(this, card);
        onScreenRemoved.Raise(this, card);
    }
}
