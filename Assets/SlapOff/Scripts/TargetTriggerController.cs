using UnityEngine;

public class TargetTriggerController : MonoBehaviour
{
    [SerializeField] private SlapSide slapSide;
    
    private void OnTriggerEnter(Collider other)
    {
        SlapManager.Instance.OnSlap(slapSide);
    }
}

public enum SlapSide
{
    Up,
    Down,
    Right,
    Left,
    UpRight,
    UpLeft,
    DownRight,
    DownLeft,
}
