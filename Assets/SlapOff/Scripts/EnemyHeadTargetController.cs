using DG.Tweening;
using UnityEngine;

public class EnemyHeadTargetController : MonoBehaviour
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
    private Vector3 _initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _slapManager = SlapManager.Instance;
        
        _slapManager.OnSlapEvent.AddListener(MoveTheHead);
        _initialPosition = headTargetTransform.position;
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

        var sequence = DOTween.Sequence();
        var score = _slapManager.Score;
        var minimumScore = 0.0f;
        var maximumScore = _slapManager.MaximumSlapScore;
        var editedScore = Mathf.InverseLerp(minimumScore, maximumScore, score);
        var editedFinalPosition = Vector3.Lerp(_initialPosition, finalPosition, editedScore);
        sequence.Append(headTargetTransform.DOMove(editedFinalPosition, 0.5f)).SetEase(Ease.OutSine);
        sequence.Insert(0.5f, headTargetTransform.DOMove(_initialPosition, 0.5f));
    }
}
