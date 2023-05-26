using UnityEngine;
using DG.Tweening;

public class HoverPreview: MonoBehaviour
{
    public GameObject TurnThisOffWhenPreviewing;  
    public Vector3 TargetPosition;
    public float TargetScale;
    public GameObject previewGameObject;
    public bool ActivateInAwake = false;
    
    private static HoverPreview _currentlyViewing = null;
    private bool _rotationRequired = false;
    
    private static bool _previewsAllowed = true;
    public static bool PreviewsAllowed
    {
        get => _previewsAllowed;

        set 
        {
            _previewsAllowed = value;
            if (!_previewsAllowed)
                StopAllPreviews();
        }
    }

    private bool _thisPreviewEnabled = false;
    public bool ThisPreviewEnabled
    {
        get { return _thisPreviewEnabled;}

        set 
        { 
            _thisPreviewEnabled = value;
            if (!_thisPreviewEnabled)
                StopThisPreview();
        }
    }

    public bool OverCollider { get; set;}
    
    void Awake()
    {
        if (transform.rotation.z != 0)
        {
            _rotationRequired = true;
        }
        TargetPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 
            Mathf.Abs(Camera.main.transform.position.z)));
        ThisPreviewEnabled = ActivateInAwake;
    }
            
    void OnMouseEnter()
    {
        
        OverCollider = true;
        if ((PreviewsAllowed && ThisPreviewEnabled) || (CompareTag("MessageElement") || CompareTag("WizardCardElement")))
            PreviewThisObject();
    }
        
    void OnMouseExit()
    {
        previewGameObject.transform.DOKill();
        OverCollider = false;
        previewGameObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        

        if (!PreviewingSomeCard())
            StopAllPreviews();
    }
    
    void PreviewThisObject()
    {
        StopAllPreviews();
        _currentlyViewing = this;
        previewGameObject.SetActive(true);
        if (TurnThisOffWhenPreviewing!=null)
            TurnThisOffWhenPreviewing.SetActive(false);
        previewGameObject.transform.localPosition = Vector3.zero;
        previewGameObject.transform.localScale = Vector3.one;


        if (_rotationRequired)
        {
            previewGameObject.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 90.0f), 0.25f);
        }
        
        previewGameObject.transform.DOMove(TargetPosition, 0.5f).SetEase(Ease.OutQuint);
        previewGameObject.transform.DOScale(TargetScale, 0.5f).SetEase(Ease.OutQuint);
    }

    public void StopThisPreview()
    {
        previewGameObject.transform.DOKill();
        previewGameObject.SetActive(false);
        previewGameObject.transform.localScale = Vector3.one;
        previewGameObject.transform.localPosition = Vector3.zero;
        
        if (TurnThisOffWhenPreviewing!=null)
            TurnThisOffWhenPreviewing.SetActive(true); 
    }
    
    public static void StopAllPreviews()
    {
        if (_currentlyViewing != null)
        {
            _currentlyViewing.previewGameObject.SetActive(false);
            _currentlyViewing.previewGameObject.transform.localScale = Vector3.one;
            _currentlyViewing.previewGameObject.transform.localPosition = Vector3.zero;
            if (_currentlyViewing.TurnThisOffWhenPreviewing!=null)
                _currentlyViewing.TurnThisOffWhenPreviewing.SetActive(true); 
        }
         
    }

    private static bool PreviewingSomeCard()
    {
        if (!PreviewsAllowed)
            return false;

        HoverPreview[] allHoverBlowups = GameObject.FindObjectsOfType<HoverPreview>();

        foreach (HoverPreview hb in allHoverBlowups)
        {
            if (hb.OverCollider && hb.ThisPreviewEnabled)
                return true;
        }

        return false;
    }
}
