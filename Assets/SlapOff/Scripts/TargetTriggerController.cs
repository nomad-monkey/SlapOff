using UnityEngine;

public class TargetTriggerController : MonoBehaviour
{
    [SerializeField] private SlapSide slapSide;
    [SerializeField] private Enemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (!enemy.IsEnemyReadyToReceiveSlap)
        {
            return;
        }
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
