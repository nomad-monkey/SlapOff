using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private List<string> attackAnimationNameList;
    [SerializeField] private HealthController playerHealthController;
    [SerializeField] private float minimumDamageAmount;
    [SerializeField] private float maximumDamageAmount;
    [SerializeField] private SlapAudioSourceController slapAudioSourceController;

    public void Attack()
    {
        var attackAnimationName = attackAnimationNameList[Random.Range(0, attackAnimationNameList.Count)];
        enemyAnimator.Play(attackAnimationName);
    }

    public void InflictDamage()
    {
        var damageAmount = Mathf.Round(Random.Range(minimumDamageAmount, maximumDamageAmount));
        slapAudioSourceController.PlayOneOfTheSlapSounds(damageAmount);
        playerHealthController.GetDamage(damageAmount);
    }
}
