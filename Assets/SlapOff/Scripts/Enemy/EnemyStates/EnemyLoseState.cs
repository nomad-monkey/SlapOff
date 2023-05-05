using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyLoseState : EnemyState
{
    private string _loseAnimationName;
    
    public EnemyLoseState(Enemy enemy, EnemyStateMachine enemyStateMachine,
        Animator enemyAnimator, Rig enemyRig, string loseAnimationName)
        : base(enemy, enemyStateMachine, enemyAnimator, enemyRig)
    {
        _loseAnimationName = loseAnimationName;
    }

    public override void Enter()
    {
        base.Enter();
        
        enemyAnimator.Play(_loseAnimationName);
    }
}
