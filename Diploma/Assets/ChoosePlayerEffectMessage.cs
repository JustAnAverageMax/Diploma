using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayerEffectMessage : MonoBehaviour
{
    public GameObject upperVariant;
    public GameObject bottomVariant;

    public GameEvent onPlayerEffectApplied;
    public GameEvent onScreenRemoved;
    
    private PlayerEffectAsset chosenVariant;
    

    private List<PlayerEffectAsset> _assets;

    public void LoadAssets(List<PlayerEffectAsset> variants)
    {
        _assets = variants;
        PlayerEffectLoader upperPlayerEffectLoader = upperVariant.GetComponent<PlayerEffectLoader>();
        upperPlayerEffectLoader.playerEffectAsset = _assets[0];
        upperPlayerEffectLoader.LoadEffect();
        
        PlayerEffectLoader bottomPlayerEffectLoader = bottomVariant.GetComponent<PlayerEffectLoader>();
        bottomPlayerEffectLoader.playerEffectAsset = _assets[1];
        bottomPlayerEffectLoader.LoadEffect();

    }

    public void ApplyEffectToPlayer(Component sender, object data)
    {
        PlayerEffectAsset playerEffectAsset = data as PlayerEffectAsset;
        if (playerEffectAsset != null)
        {
            chosenVariant = playerEffectAsset;
            onPlayerEffectApplied.Raise(this, chosenVariant);
            onScreenRemoved.Raise(this, chosenVariant);
        }
    }
}
