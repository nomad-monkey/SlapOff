using System;
using UnityEngine;
using UnityEngine.Events;


public class Slap : MonoBehaviour
{
    [Serializable]
    public class CollisionEnterEvent : UnityEvent {}

    [SerializeField]
    public CollisionEnterEvent m_OnCollide;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "righthand")
        {
            Debug.Log("CollisionEnter");
    
            m_OnCollide.Invoke();
        }
        
    }
}

