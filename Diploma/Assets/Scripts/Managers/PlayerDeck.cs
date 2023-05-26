using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerDeck : Deck
{
    public TMP_Text amount;
    public GameEvent onHandCardReceived;
    public GameEvent onTopDeckShow;
    public GameEvent onDeckRebuilded;
    public GameEvent onDeckReady;
    public GameEvent onAmountChanged;
    public void FillHandWithCards(Component sender, object data)
    {
        if (sender is not Hand || data == null) return;
        int amountRequired = (int) data;

        if (amountRequired > contents.Count)
        {
            onDeckRebuilded.Raise(this, amountRequired);
            Debug.Log(contents.Count);
        }

        for (int i = 0; i < amountRequired; i++)
        {
            onHandCardReceived.Raise(this, GetTopCard());
            onAmountChanged.Raise(this, contents.Count);
        }
    }

    public void DrawCard(Component sender, object data)
    {
        if (contents.Count > 0)
        {
            onHandCardReceived.Raise(this, GetTopCard());
            onAmountChanged.Raise(this, contents.Count);
        }
    }

    public void ShuffleDeckWithDiscardPile(Component sender, object data)
    {
        
        if (data is List<CardAsset> discardPile)
        {
            contents.AddRange(discardPile);
            Debug.Log(contents.Count);
            onAmountChanged.Raise(this, contents.Count);
            contents.Shuffle();
            onDeckReady.Raise(this, contents.Count);
        }
    }
    
    public void HandleTopDeckLook(Component sender, object data)
    {
        if (contents.Count > 0)
        {
            onTopDeckShow.Raise(this, GetTopCard());
            onAmountChanged.Raise(this, contents.Count);
        }
    }

    public void AmountChanged(Component sender, object data)
    {
        amount.text = contents.Count.ToString();
    }
    public void PutCardOnTheTop(Component sender, object data)
    {
        CardAsset assetToAdd = ScriptableObject.CreateInstance<CardAsset>();
        switch (sender)
        {
            case TurnManager:
                ClickableCard clickableCard = data as ClickableCard;
                if (clickableCard != null)
                {
                    clickableCard.transform.DOMove(transform.position, 0.5f)
                        .OnComplete(() => Destroy(clickableCard.gameObject));
                    assetToAdd = clickableCard.GetComponent<CardDataLoader>().cardAsset;
                }

                contents.Insert(0, assetToAdd);
                break;
            case LookAtTopCardScreen:
                GameObject cardObject = data as GameObject;
                if (cardObject != null)
                {
                    cardObject.transform.DOMove(transform.position, 0.5f)
                        .OnComplete(() => Destroy(cardObject.gameObject));
                    assetToAdd = cardObject.GetComponent<CardDataLoader>().cardAsset;
                }
                contents.Insert(0, assetToAdd);
                
                break;
        }
        onAmountChanged.Raise(this, contents.Count);
    }
}
