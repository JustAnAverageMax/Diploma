using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ClickableCard : MonoBehaviour
{
    public GameEvent onCardClicked;

    public void OnMouseDown()
    {
        if (GameManager.clickingOnCardsAllowed)
        {
            transform.DOKill();
            onCardClicked.Raise(this, GetComponent<CardDataLoader>().cardAsset);
        }
    }
}
