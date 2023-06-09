using System;
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
    public float MaximumSlapScore = 700.0f;
    public float RawSliderValue { get; private set; }
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

    private void Start()
    {
        TurnManager.Instance.onPlayerTurnStarted.AddListener(() => _isItTriggered = false);
    }

    public void OnSlap(SlapSide slapSide)
    {
        if (_isItTriggered)
        {
            return;
        }
        _isItTriggered = true;
        
        SlapSide = slapSide;
        RawSliderValue = sliderController.OnEnd();
        SliderValue = Mathf.Pow(RawSliderValue, 2);
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

        Score = Mathf.Round(Score);

        OnSlapEvent?.Invoke();
    }
}
