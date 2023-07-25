using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WizardCard : MonoBehaviour
{
    internal Vector3 initialPosition;
    private Vector3 centerPos;
    
    private bool cardActive = false;

    public Transform currentHealthMarker;
    
    public Image background;

    public void Awake()
    {
        initialPosition = transform.position;
        if (Camera.main != null)
            centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,
                Mathf.Abs(Camera.main.transform.position.z)));
    }
    
    public void ShowHealthChange(Component sender, object data)
    {
        Vector3 endPos = (Vector3) data;
        
        var sequence = DOTween.Sequence();
        sequence.AppendCallback(ToggleWizardCard)
            .AppendInterval(0.7f)
            .Append(currentHealthMarker.DOLocalMove(endPos, 0.5f))
            .AppendInterval(0.5f)
            .AppendCallback(ToggleWizardCard).Play();
    }
    
    
    public void ToggleWizardCard()
    {
        
        transform.DOMove(cardActive ? initialPosition : centerPos, 0.5f);
        cardActive = !cardActive;
    }
}
