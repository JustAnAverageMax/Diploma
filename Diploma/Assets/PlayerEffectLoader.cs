using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEffectLoader : MonoBehaviour
{
    public PlayerEffectLoader preview;
    public PlayerEffectAsset playerEffectAsset;
    public TMP_Text description;

    public GameEvent onPlayerEffectInitiallyLoaded;

    private void Awake()
    {
        description.text = "Нет эффекта";
        if (playerEffectAsset != null)
        {
            LoadEffect();
        }
    }

    public void ApplyEffect(Component sender, object data)
    {
        PlayerEffectAsset asset = data as PlayerEffectAsset;
        if (asset != null)
        {
            playerEffectAsset = asset;
            LoadEffect();
            GameManager.AllowCardInteractions(true);
            onPlayerEffectInitiallyLoaded.Raise(this, asset);
        }
    }
    
    public void LoadEffect()
    {
        description.text = playerEffectAsset.description;

        if (preview != null)
        {
            preview.playerEffectAsset = playerEffectAsset;
            preview.LoadEffect();
            
        }
    }
}
