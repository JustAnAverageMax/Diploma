using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public Transform showPos;

    public Transform initialScreenPosition;

    public GameObject lookAtTopCardScreenPrefab;
    public GameObject choosePlayerEffectScreenPrefab;
    

    public void ShowChoosePlayerEffectScreen(Component sender, object data)
    {
        List<PlayerEffectAsset> playerEffectAssets = data as List<PlayerEffectAsset>;
        GameObject message = Instantiate(choosePlayerEffectScreenPrefab, initialScreenPosition.position,
            Quaternion.identity);
        ChoosePlayerEffectMessage screen = message.GetComponent<ChoosePlayerEffectMessage>();
        screen.LoadAssets(playerEffectAssets);
        message.transform.DOMove(showPos.position, 0.5f);
    }
    
    public void ShowLookAtTopCardScreen(Component sender, object data)
    {
        CardAsset cardAsset = data as CardAsset;
        
        GameObject message = Instantiate(lookAtTopCardScreenPrefab, initialScreenPosition.position, Quaternion.identity);
       
        LookAtTopCardScreen screen = message.GetComponent<LookAtTopCardScreen>();
        screen.SetCardAsset(cardAsset);
        message.transform.DOMove(showPos.position, 0.5f);
    }

    public void RemoveMessage(Component sender, object data)
    {
        sender.transform.DOMove(initialScreenPosition.position, 0.5f).OnComplete(() => Destroy(sender.gameObject));
    }
}
