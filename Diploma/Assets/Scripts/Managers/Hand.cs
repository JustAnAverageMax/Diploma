using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public int maxCardAmount = 5;
    public GameObject cardPrefab;

    [Header("Events")] 
    public GameEvent onHandNotFull;
    public GameEvent onCardDeletedFromHand;
    public GameEvent onRequireSingleSlot;
    public GameEvent onRequireSlotDeletion;


    public List<CardAsset> cards = new List<CardAsset>();
    
    [SerializeField] private List<GameObject> cardObjects = new List<GameObject>();

    public HandCardSlotsManager slotsManager;

    public void InitializeHand(Component sender, object data)
    {
        onHandNotFull.Raise(this, MissingAmountOfCards);
    }
    public void ReArrangeCards()
    {
        HoverPreview.PreviewsAllowed = false;
        for (int i = 0; i < cardObjects.Count; i++)
        {
            cardObjects[i].transform.DOMove(slotsManager.Slots[i].transform.position, 0.5f);
        }
        HoverPreview.PreviewsAllowed = true;
    }

    public void RequestCards(Component sender, object data)
    {
        onHandNotFull.Raise(this, MissingAmountOfCards);
        ReArrangeCards();
    }
    public void DeleteCardFromHand(Component sender, object data)
    {
        GameObject cardToDelete = cardObjects.Find(card =>
            card.GetInstanceID() ==
            sender.gameObject.GetInstanceID());
        int cardObjectIndex = cardObjects.IndexOf(cardToDelete);
        
        cards.RemoveAt(cardObjectIndex);
        cardObjects.RemoveAt(cardObjectIndex);
        onCardDeletedFromHand.Raise(this, cardToDelete);
        onRequireSlotDeletion.Raise(this, cardObjectIndex);
        cardToDelete.GetComponent<HoverPreview>().StopThisPreview();
        
         ReArrangeCards();
        
    }
    public void CardReceived(Component sender, object data)
    {
        AddCardToHand((CardAsset)data);
        GameObject newCard = Instantiate(cardPrefab, sender.transform.position, Quaternion.identity);
        newCard.name = $"Card #{cardObjects.Count + 1}";
        newCard.GetComponent<CardDataLoader>().cardAsset = (CardAsset) data;
        newCard.GetComponent<CardDataLoader>().LoadCardData();
        cardObjects.Add(newCard);
        onRequireSingleSlot.Raise(this, null);
        ReArrangeCards();
    }
    
    
    public bool NotFullHand => cards.Count != maxCardAmount;

    public int MissingAmountOfCards => NotFullHand ? maxCardAmount - cards.Count : 0;

    public void AddCardToHand(CardAsset card)
    {
        cards.Add(card);
    }
}
