using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variant : MonoBehaviour
{
    public GameEvent onPlayerEffectChosen;
    public void OnMouseDown()
    {

        onPlayerEffectChosen.Raise(this, GetComponent<PlayerEffectLoader>().playerEffectAsset);
    }
}
