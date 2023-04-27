using BNG;
using UnityEngine;

public class PlayerHapticController : MonoBehaviour
{
    private InputBridge _inputBridge;
    
    void Start()
    {
        SlapManager.Instance.OnSlapEvent.AddListener(SlapHaptic);

        _inputBridge = InputBridge.Instance;
    }

    private void SlapHaptic()
    {
        _inputBridge.VibrateController(0.2f, 0.4f, 0.2f, ControllerHand.Right);
        _inputBridge.VibrateController(0.2f, 0.4f, 0.2f, ControllerHand.Left);
    }
}
