using BNG;
using UnityEngine;

public class PlayerHapticController : MonoBehaviour
{
    private InputBridge _inputBridge;
    private SlapManager _slapManager;
    
    void Start()
    {
        _inputBridge = InputBridge.Instance;
        _slapManager = SlapManager.Instance;
        
        _slapManager.OnSlapEvent.AddListener(SlapHaptic);
    }

    private void SlapHaptic()
    {
        if (_slapManager.IsRightHandInputSelected)
        {
            _inputBridge.VibrateController(0.2f, 0.4f, 0.2f, ControllerHand.Right);
        }
        else
        {
            _inputBridge.VibrateController(0.2f, 0.4f, 0.2f, ControllerHand.Left);
        }
    }
}
