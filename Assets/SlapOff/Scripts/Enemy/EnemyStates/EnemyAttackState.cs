using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyAttackState : EnemyState
{
    private EnemyAttackController _enemyAttackController;
    private CancellationTokenSource _cancellationTokenSource;
    
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine,
        Animator enemyAnimator, EnemyAttackController enemyAttackController, Rig enemyRig)
        : base(enemy, enemyStateMachine, enemyAnimator, enemyRig)
    {
        _enemyAttackController = enemyAttackController;
    }

    public override void Enter()
    {
        base.Enter();
        
        _cancellationTokenSource = new CancellationTokenSource();
        
        TurnManager.Instance.OnEnemyTurnStarted();
        
        enemy.SetSlapReceiver(false);
        var cancellationToken = _cancellationTokenSource.Token;
        var waitAndAttackTask = WaitAndAttack(cancellationToken);
    }

    private async Task WaitAndAttack(CancellationToken cancellationToken)
    {
        await Task.Delay(3000, cancellationToken);
        enemyRig.weight = 0.0f;
        _enemyAttackController.Attack();
        await Task.Delay(3000, cancellationToken);
        
        TurnManager.Instance.OnEnemyTurnEnded();
        
        enemyStateMachine.ChangeState(enemy.EnemyWaitState);
    }

    public override void Exit()
    {
        base.Exit();
        
        _cancellationTokenSource.Cancel();
    }
}
