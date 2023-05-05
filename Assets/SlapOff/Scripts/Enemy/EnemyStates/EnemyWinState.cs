using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyWinState : EnemyState
{
    private string _winAnimationName;
    
    public EnemyWinState(Enemy enemy, EnemyStateMachine enemyStateMachine,
        Animator enemyAnimator, Rig enemyRig, string winAnimationName)
        : base(enemy, enemyStateMachine, enemyAnimator, enemyRig)
    {
        _winAnimationName = winAnimationName;
    }

    public override void Enter()
    {
        base.Enter();
        
        enemyRig.weight = 0.0f;
        //enemyAnimator.Play(_winAnimationName);
        enemyAnimator.SetBool("OnWin", true);
    }
}
