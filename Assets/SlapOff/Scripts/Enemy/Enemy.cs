using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private EnemyAttackController enemyAttackController;
    [SerializeField] private Rig enemyRig;
    [SerializeField] private string enemyWinAnimationName;
    [SerializeField] private string enemyLoseAnimationName;
    
    private EnemyStateMachine _enemyStateMachine;
    private EnemyState _enemyWaitState;
    private EnemyState _enemyAttackState;
    private EnemyState _enemyWinState;
    private EnemyState _enemyLoseState;

    public bool IsEnemyReadyToReceiveSlap { get; private set; }
    public EnemyState EnemyWaitState => _enemyWaitState;
    public EnemyState EnemyAttackState => _enemyAttackState;

    void Start()
    {
        _enemyStateMachine = new EnemyStateMachine();
        _enemyLoseState = new EnemyWinState(this, _enemyStateMachine, enemyAnimator, enemyRig, enemyLoseAnimationName);
        _enemyWinState = new EnemyWinState(this, _enemyStateMachine, enemyAnimator, enemyRig, enemyWinAnimationName);
        _enemyAttackState = new EnemyAttackState(this, _enemyStateMachine, enemyAnimator, enemyAttackController, enemyRig);
        _enemyWaitState = new EnemyWaitState(this, _enemyStateMachine, enemyAnimator, enemyRig);

        _enemyStateMachine.Initialize(_enemyWaitState);

        var turnManager = TurnManager.Instance;
        turnManager.onPlayerLose.AddListener(() => _enemyStateMachine.ChangeState(_enemyWinState));
        turnManager.onPlayerWin.AddListener(() => _enemyStateMachine.ChangeState(_enemyLoseState));
    }

    public void SetSlapReceiver(bool status)
    {
        IsEnemyReadyToReceiveSlap = status;
    }
}
