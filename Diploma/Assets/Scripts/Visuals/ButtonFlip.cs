using DG.Tweening;
using UnityEngine;

public class ButtonFlip : MonoBehaviour
{
    private bool isFlipped = false;
    
    public void Flip()
    {
        transform.DOKill();
        float zRot = isFlipped ? 0.0f : 180.0f;

        transform.DORotate(new Vector3(0.0f, 0.0f, zRot), 0.5f);
        isFlipped = !isFlipped;

    }
}
