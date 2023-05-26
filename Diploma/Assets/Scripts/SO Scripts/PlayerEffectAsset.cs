using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Effect")]
public class PlayerEffectAsset : ScriptableObject
{
    [TextArea]
    public string description;

    public List<PlayerEffect> playerEffects;
}
