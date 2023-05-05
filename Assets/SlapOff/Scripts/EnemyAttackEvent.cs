using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEvent : MonoBehaviour
{
    [SerializeField] private EnemyAttackController enemyAttackController;
    
    public void OnAnimationEvent()
    {
        enemyAttackController.InflictDamage();
    }
}
