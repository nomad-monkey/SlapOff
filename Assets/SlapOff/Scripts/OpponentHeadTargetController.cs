using DG.Tweening;
using UnityEngine;

public class OpponentHeadTargetController : MonoBehaviour
{
    [SerializeField] private Transform headTargetTransform;
    [SerializeField] private Transform upFinalTransform;
    [SerializeField] private Transform downFinalTransform;
    [SerializeField] private Transform rightFinalTransform;
    [SerializeField] private Transform leftFinalTransform;
    [SerializeField] private Transform upRightFinalTransform;
    [SerializeField] private Transform upLeftFinalTransform;
    [SerializeField] private Transform downRightFinalTransform;
    [SerializeField] private Transform downLeftFinalTransform;

    private SlapManager _slapManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _slapManager = SlapManager.Instance;
        
        _slapManager.OnSlapEvent.AddListener(MoveTheHead);
    }

    private void MoveTheHead()
    {
        var slapSide = _slapManager.SlapSide;
        Vector3 finalPosition = headTargetTransform.position;
        switch (slapSide)
        {
            case SlapSide.Up:
                finalPosition = upFinalTransform.position;
                break;
            case SlapSide.Down:
                finalPosition = downFinalTransform.position;
                break;
            case SlapSide.Right:
                finalPosition = rightFinalTransform.position;
                break;
            case SlapSide.Left:
                finalPosition = leftFinalTransform.position;
                break;
            case SlapSide.UpRight:
                finalPosition = upRightFinalTransform.position;
                break;
            case SlapSide.UpLeft:
                finalPosition = upLeftFinalTransform.position;
                break;
            case SlapSide.DownRight:
                finalPosition = downRightFinalTransform.position;
                break;
            case SlapSide.DownLeft:
                finalPosition = downLeftFinalTransform.position;
                break;
        }

        headTargetTransform.DOMove(finalPosition, 0.3f);
    }
}
