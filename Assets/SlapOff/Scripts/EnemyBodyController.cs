using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBodyController : MonoBehaviour
{
    [SerializeField] private List<GameObject> bodyGameObjectsList;
    private void Awake()
    {
        var randomIndex = Random.Range(0, bodyGameObjectsList.Count);
        bodyGameObjectsList[randomIndex].SetActive(true);
    }
}
