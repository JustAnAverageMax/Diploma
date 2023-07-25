using System;
using DG.Tweening;
using UnityEngine;

public class ButtonFlip : MonoBehaviour
{
    private bool isFlipped = false;
    [SerializeField] private float initialZRot;

    public void Awake()
    {
        initialZRot = transform.rotation.eulerAngles.z;
    }

    public void Flip()
    {
        transform.DOKill();
        float zRot = isFlipped ? initialZRot : initialZRot - 180.0f;

        transform.DORotate(new Vector3(0.0f, 0.0f, zRot), 0.5f);
        isFlipped = !isFlipped;

    }
}
