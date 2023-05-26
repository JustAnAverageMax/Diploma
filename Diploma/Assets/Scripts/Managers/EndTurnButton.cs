using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    public GameEvent onTurnEnded;

    public void EndTurn()
    {
        onTurnEnded.Raise(this, "ended");
    }
}
