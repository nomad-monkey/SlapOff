using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;
    protected Animator enemyAnimator;
    protected Rig enemyRig;

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine,
        Animator enemyAnimator, Rig enemyRig)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        this.enemyAnimator = enemyAnimator;
        this.enemyRig = enemyRig;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
