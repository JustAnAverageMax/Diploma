using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardAsset> contents = new List<CardAsset>();

    private void Awake()
    {
        contents.Shuffle();
    }

    public CardAsset GetTopCard()
    {
        CardAsset cardToDraw = contents[0];
        contents.RemoveAt(0);
        return cardToDraw;
    }
}
