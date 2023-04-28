using System.Collections;
using BNG;
using UnityEngine;
using UnityEngine.Events;

public class SlapManager : MonoBehaviour
{
    [SerializeField] private SliderController sliderController;

    private bool _isItTriggered;
    private IEnumerator _triggerResetterCoroutine;

    public UnityEvent OnSlapEvent;
    public float SliderValue { get; private set; }
    public float RightHandValue { get; private set; }
    public float LeftHandValue { get; private set; }
    public float Score { get; private set; }
    public SlapSide SlapSide { get; private set; }
    public bool IsRightHandInputSelected { get; private set; }

    #region Singleton
    public static SlapManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public void OnSlap(SlapSide slapSide)
    {
        if (_isItTriggered)
        {
            return;
        }

        if (_triggerResetterCoroutine != null)
        {
            StopCoroutine(_triggerResetterCoroutine);
        }
        _triggerResetterCoroutine = TriggerResetterCoroutine();
        StartCoroutine(_triggerResetterCoroutine);
        
        SlapSide = slapSide;
        SliderValue = Mathf.Pow(sliderController.OnEnd(), 2);
        RightHandValue = InputBridge.Instance.GetControllerVelocity(ControllerHand.Right).magnitude;
        LeftHandValue = InputBridge.Instance.GetControllerVelocity(ControllerHand.Left).magnitude;
        var rightHandScore = RightHandValue * 100.0f * SliderValue;
        var leftHandScore = LeftHandValue * 100.0f * SliderValue;
        if (rightHandScore >= leftHandScore)
        {
            //right hand input selected
            Score = rightHandScore;
            IsRightHandInputSelected = true;
        }
        else
        {
            //left hand input selected
            Score = leftHandScore;
            IsRightHandInputSelected = false;
        }
        
        OnSlapEvent?.Invoke();
    }

    private IEnumerator TriggerResetterCoroutine()
    {
        _isItTriggered = true;
        yield return new WaitForSeconds(0.1f);
        _isItTriggered = false;
    }
}
