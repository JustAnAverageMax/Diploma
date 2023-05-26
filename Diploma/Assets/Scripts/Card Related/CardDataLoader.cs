using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDataLoader : MonoBehaviour
{
    public CardDataLoader previewData;

    public CardAsset cardAsset;

    public TMP_Text cardName;
    public TMP_Text cardType;
    public TMP_Text cardDescription;
    public TMP_Text cardPrice;
    public TMP_Text cardScoreValue;

    public Image cardArt;
    public Image cardUpperPanel;
    public Image cardBottomPanel;
    
    
    public void LoadCardData()
    {
        cardName.text = cardAsset.cardName.ToUpper();
        cardType.text = cardAsset.cardType.ToString();
        
        cardDescription.text = cardAsset.cardDescription;
        cardPrice.text = cardAsset.cardPrice.ToString();
        cardScoreValue.text = cardAsset.cardScoreValue.ToString();
        cardArt.sprite = cardAsset.cardArt;

        Color typeColor = ColorSetter.GetColorBasedOnCardType(cardAsset.cardType);

        cardType.outlineColor = typeColor;
        cardType.color = typeColor;

        cardName.outlineColor = typeColor;
        
        
        cardBottomPanel.color = typeColor;
        cardUpperPanel.color = typeColor;
        
        
        if (previewData != null)
        {
            previewData.cardAsset = cardAsset;
            previewData.LoadCardData();
        }
    }
    
    
    private void Awake()
    {
        if (cardAsset != null)
        { 
            LoadCardData();
        }
    }
}
