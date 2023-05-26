using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public GameEvent onGameStarted;

    public static bool clickingOnCardsAllowed = false;

    public List<PlayerEffectAsset> playerEffectAssets;
    public void Start()
    {
        playerEffectAssets.Shuffle();
        List<PlayerEffectAsset> randomEffects = new List<PlayerEffectAsset>();
        Random rnd = new Random();
        do
        {
            int randomIndex = rnd.Next(playerEffectAssets.Count);
            PlayerEffectAsset randomEffect = playerEffectAssets[randomIndex];
            if(!randomEffects.Contains(randomEffect))
                randomEffects.Add(randomEffect);
        } while (randomEffects.Count < 2);

        AllowCardInteractions(false);
        onGameStarted.Raise(this, randomEffects);
    }

    public static void AllowCardInteractions(bool value)
    {
        clickingOnCardsAllowed = value;
        HoverPreview.PreviewsAllowed = value;
    }
}
