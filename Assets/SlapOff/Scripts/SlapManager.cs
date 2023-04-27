using BNG;
using UnityEngine;
using UnityEngine.Events;

public class SlapManager : MonoBehaviour
{
    [SerializeField] private SliderController sliderController;

    private bool _isItTriggered;

    public UnityEvent OnSlapEvent;
    public float SliderValue { get; private set; }
    public float RightHandValue { get; private set; }
    public float LeftHandValue { get; private set; }
    public float Score { get; private set; }

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

    private void OnTriggerEnter(Collider other)
    {
        if (_isItTriggered)
        {
            return;
        }
        _isItTriggered = true;
        
        SliderValue = Mathf.Pow(sliderController.OnEnd(), 2);
        RightHandValue = InputBridge.Instance.GetControllerVelocity(ControllerHand.Right).magnitude;
        LeftHandValue = InputBridge.Instance.GetControllerVelocity(ControllerHand.Left).magnitude;
        var rightHandScore = RightHandValue * 100.0f * SliderValue;
        var leftHandScore = LeftHandValue * 100.0f * SliderValue;
        Score = rightHandScore >= leftHandScore ? rightHandScore : leftHandScore;
        
        OnSlapEvent?.Invoke();
    }
}
