using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    CREATURE,
    SPELL,
    MAGICIAN,
    PLACE,
    TREASURE,
    LEGEND,
    FAMILIARE,
    LAWLESSNESS,
    UTILITY,
    SPECIAL
}

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardAsset : ScriptableObject
{
    public string cardName;
    [TextArea]
    public string cardDescription;

    public CardType cardType;

    public Sprite cardArt;

    public int cardPrice;
    public int cardScoreValue;
    public int basePower;
    
    public List<CardEffect> cardEffects;
}