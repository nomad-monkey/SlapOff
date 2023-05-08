using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyWaitState : EnemyState
{
    private bool _isSlapEventHappened;
    public EnemyWaitState(Enemy enemy, EnemyStateMachine enemyStateMachine,
        Animator enemyAnimator, Rig enemyRig)
        : base(enemy, enemyStateMachine, enemyAnimator, enemyRig)
    {
    }

    public override void Enter()
    {
        base.Enter();
        TurnManager.Instance.OnPlayerTurnStarted();
        _isSlapEventHappened = false;
        enemyRig.weight = 1.0f;
        enemy.SetSlapReceiver(true);
        SlapManager.Instance.OnSlapEvent.AddListener(OnSlapEvent);
    }

    private void OnSlapEvent()
    {
        if (_isSlapEventHappened)
        {
            return;
        }
        _isSlapEventHappened = true;
        
        TurnManager.Instance.OnPlayerTurnEnded();
        _isSlapEventHappened = false;
        enemyStateMachine.ChangeState(enemy.EnemyTauntState);
    }
}
