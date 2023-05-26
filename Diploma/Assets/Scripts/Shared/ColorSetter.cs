using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetter
{
    public static Color HexToColor(string hex)
    {
        return ColorUtility.TryParseHtmlString(hex, out var result) ? result : Color.white;
    }
    private static Dictionary<CardType, Color> _colorCorrelations = new Dictionary<CardType, Color>()
    {

        {CardType.MAGICIAN, HexToColor("#00AEEF")},
        {CardType.CREATURE, HexToColor("#EC1D23")},
        {CardType.SPELL,    HexToColor("#F58F20")},
        {CardType.TREASURE, Color.white},
        {CardType.PLACE, HexToColor("#E9028B")},
        {CardType.UTILITY, Color.yellow},
        {CardType.FAMILIARE, Color.gray},
        {CardType.LEGEND, Color.red},
        {CardType.SPECIAL, Color.green}

        
    };

    public static Color GetColorBasedOnCardType(CardType cardType)
    {
        return _colorCorrelations[cardType];
    }
}
