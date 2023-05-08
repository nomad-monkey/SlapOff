using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyTauntState : EnemyState
{
    private CancellationTokenSource _cancellationTokenSource;
    public EnemyTauntState(Enemy enemy, EnemyStateMachine enemyStateMachine,
        Animator enemyAnimator, Rig enemyRig)
        : base(enemy, enemyStateMachine, enemyAnimator, enemyRig)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        TurnManager.Instance.OnEnemyTurnStarted();
        
        _cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = _cancellationTokenSource.Token;
        var waitAndAttackTask = WaitAndAttack(cancellationToken);
    }

    private async Task WaitAndAttack(CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);
        enemyRig.weight = 0.0f;
        var tauntTrigger =
            enemy.EnemyTauntAnimationTriggersList[Random.Range(0, enemy.EnemyTauntAnimationTriggersList.Count)];
        enemyAnimator.SetBool(tauntTrigger, true);
        await Task.Delay(2000, cancellationToken);
        
        enemyStateMachine.ChangeState(enemy.EnemyAttackState);
    }

    public override void Exit()
    {
        base.Exit();
        
        _cancellationTokenSource.Cancel();
    }
}
