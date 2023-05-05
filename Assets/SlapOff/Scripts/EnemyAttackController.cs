using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private string attackAnimationName;
    [SerializeField] private HealthController playerHealthController;
    [SerializeField] private float minimumDamageAmount;
    [SerializeField] private float maximumDamageAmount;
    [SerializeField] private SlapAudioSourceController slapAudioSourceController;

    public void Attack()
    {
        enemyAnimator.Play(attackAnimationName);
    }

    public void InflictDamage()
    {
        slapAudioSourceController.PlaySlapSound();
        var damageAmount = Mathf.Round(Random.Range(minimumDamageAmount, maximumDamageAmount));
        playerHealthController.GetDamage(damageAmount);
    }
}
