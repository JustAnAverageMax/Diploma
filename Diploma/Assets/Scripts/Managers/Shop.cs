using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<GameObject> cards;
    public void HideCard(Component sender, object data)
    {
        if (sender is TurnManager && data != null)
        {
            cards.Remove(cards.Find(card => card.GetComponent<ClickableCard>().Equals(data)));
        }
    }
}
