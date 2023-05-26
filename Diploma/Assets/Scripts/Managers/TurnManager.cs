using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public GameEvent onCardPurchased;
    public GameEvent onPowerChanged;

    public TMP_Text indication;
    [SerializeField] private int power = 0;

    public int Power
    {
        get => power;
        set => power = value;
    }
    public void PurchaseCard(Component sender, object data)
    {
        if (sender is ClickableCard || data != null)
        {
            CardAsset cardAsset = (CardAsset) data;
            ClickableCard card = sender as ClickableCard;
            if (CanPurchaseCard(cardAsset))
            {
                //Debug.Log($"Here {card}");
                onCardPurchased.Raise(this, card);
                onPowerChanged.Raise(this, -cardAsset.cardPrice);
            }
            else
            {
                StartCoroutine(NotEnoughPowerSignal());
            }
        }
    }

    private IEnumerator NotEnoughPowerSignal()
    {
        for (int i = 0; i < 3; i++)
        {
            indication.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            indication.color = Color.white;
        }
        
    }
    
    public bool CanPurchaseCard(CardAsset cardAsset)
    {
        return cardAsset.cardPrice <= power;
    }

    public void HandlePowerChange(Component sender, object data)
    {
        if (sender is ClickableCard)
        {
            CardAsset asset = (CardAsset) data;
            onPowerChanged.Raise(this,  asset.basePower);
        }
    }
    
    public void ChangePower(Component sender, object data)
    {
        int amount = (int) data;
        power += amount;
        indication.text = $"Мощь: {power}";
    }
    
    
    public void EndTurn(Component sender, object data)
    {
        ChangePower(this, -power);
        GameManager.AllowCardInteractions(false);

    }
}
