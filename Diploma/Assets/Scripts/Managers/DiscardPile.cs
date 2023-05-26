using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = System.Random;

public class DiscardPile : MonoBehaviour
{
    public List<CardAsset> contents = new List<CardAsset>();
    public List<GameObject> cardObjects = new List<GameObject>();

    public GameEvent onDiscardPileShuffleWithDeck;
    
    private bool nextCardGoesToDiscardPile = true;
    private void Awake()
    {
        contents.Clear();
        cardObjects.Clear();
    }

    public void RebuildDeck(Component sender, object data)
    {
        if (sender is PlayerDeck)
        {
            var sequence = DOTween.Sequence();
            foreach (var cardObject in cardObjects)
            {
                sequence.Append(cardObject.transform.DOMove(sender.transform.position, 0.1f))
                        .Join(cardObject.transform.DORotate(sender.transform.rotation.eulerAngles, 0.1f))
                        .AppendCallback(()=> Destroy(cardObject));
            }

            sequence.Play();
            onDiscardPileShuffleWithDeck.Raise(this, contents);
        }
    }
    
    public void AddCardToDiscardPile(Component sender, object data)
    {
        Debug.Log(sender);
        switch (sender)
        {
            case LookAtTopCardScreen:
                GameObject card = data as GameObject;
                cardObjects.Add(card);
                AddCardToDiscardPile(card.GetComponent<CardDataLoader>());
                //nextCardGoesToDiscardPile = true;
                break;
            case ClickableCard cardObject:
                cardObjects.Add(cardObject.gameObject);
                AddCardToDiscardPile(cardObject.GetComponent<CardDataLoader>());
                break;
            case TurnManager:
                if (nextCardGoesToDiscardPile)
                {
                    ClickableCard cardToAdd = data as ClickableCard;
                    cardObjects.Add(cardToAdd.gameObject);
                    AddCardToDiscardPile(cardToAdd.GetComponent<CardDataLoader>());
                    nextCardGoesToDiscardPile = true;
                }
                break;
            case Hand:
                GameObject playedCard = data as GameObject;
                cardObjects.Add(playedCard);
                AddCardToDiscardPile(playedCard.GetComponent<CardDataLoader>());
                //nextCardGoesToDiscardPile = true;
                break;
        }
    }
    
    public void ChangeCardEndPointStrategy(Component sender, object data)
    {
        nextCardGoesToDiscardPile = sender is LookAtTopCardScreen;
        Debug.Log($"Next card from shop wont go to discard pile because {sender} is sender {nextCardGoesToDiscardPile}");
    }
    
    private void AddCardToDiscardPile(CardDataLoader card)
    {
        CardAsset asset = card.cardAsset;
        contents.Add(asset);
        
        Random rnd = new Random();
        int offset = rnd.Next(-15, 15);
        
        Quaternion finalRot = Quaternion.Euler(0.0f, 0.0f, offset-90.0f);

        card.transform.DOKill();
        card.transform.DOMove(transform.position, 0.5f);
        card.transform.DORotate(finalRot.eulerAngles, 0.5f);
        
        
        card.transform.parent = transform;
        card.GetComponentInChildren<Canvas>().sortingOrder = contents.Count - 1;

        card.GetComponent<HoverPreview>().ThisPreviewEnabled = false;

    }

    public void RemoveCardFromDiscardPile(CardAsset card)
    {
        if (contents.Contains(card))
        {
            contents.Remove(card);
        }
    }
}
