using System;
using DG.Tweening;
using UnityEngine;

public class DemoMovement : MonoBehaviour
{
    [SerializeField] private RectTransform indicator;
    [SerializeField] private RectTransform startRectTransform;
    [SerializeField] private RectTransform endRectTransform;
    [SerializeField] private RectTransform targetTransform;
    [SerializeField] private float movementTime;

    private Sequence moveSequence;

    private void Start()
    {
        OnStart();
    }

    public void OnStart()
    {
        if (moveSequence != null)
        {
            moveSequence.Kill();
            moveSequence = null;
        }
        
        indicator.position = startRectTransform.position;
        
        moveSequence = DOTween.Sequence();
        
        moveSequence.Append(indicator.DOMove(endRectTransform.position, movementTime));
        moveSequence.Append(indicator.DOMove(startRectTransform.position, movementTime));
        moveSequence.SetLoops(100000, LoopType.Restart);
    }

    public void OnEnd()
    {
        moveSequence.Kill();
        Debug.Log(GetPercentage());
    }

    private float GetPercentage()
    {
        var startPoint = startRectTransform.anchoredPosition;
        var endPoint = endRectTransform.anchoredPosition;
        var targetPoint = targetTransform.anchoredPosition;
        var indicatorPoint = indicator.anchoredPosition;

        var targetToStartDistance = (targetPoint - startPoint).magnitude;
        var targetToEndDistance = (targetPoint - endPoint).magnitude;
        var completeDistance = targetToStartDistance + targetToEndDistance;
        var targetToIndicatorDistance = (targetPoint - indicatorPoint).magnitude;

        return 1.0f - Mathf.InverseLerp(0.0f, completeDistance, targetToIndicatorDistance);
    }
}
