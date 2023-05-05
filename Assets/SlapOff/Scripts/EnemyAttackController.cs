using System.Threading.Tasks;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private string attackAnimationName;
    [SerializeField] private HealthController playerHealthController;
    [SerializeField] private float minimumDamageAmount;
    [SerializeField] private float maximumDamageAmount;

    public void Attack()
    {
        enemyAnimator.Play(attackAnimationName);
    }

    public void InflictDamage()
    {
        var damageAmount = Mathf.Round(Random.Range(minimumDamageAmount, maximumDamageAmount));
        playerHealthController.GetDamage(damageAmount);
    }
}
