using UnityEngine;

public class PlayerEffectHandler : MonoBehaviour
{
     private PlayerEffectAsset _playerEffectAsset;

     private void Awake()
     {
          _playerEffectAsset = GetComponent<PlayerEffectLoader>().playerEffectAsset;
     }

     public void HandleEffect(Component sender, object data)
     {
          if (_playerEffectAsset == null)
          {
               _playerEffectAsset = GetComponent<PlayerEffectLoader>().playerEffectAsset;
          }
          foreach (var playerEffect in _playerEffectAsset.playerEffects)
          {
              playerEffect.Execute(sender, data);           
          }
     }
}
