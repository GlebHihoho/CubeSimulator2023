using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class KillPlane : MonoBehaviour
    {
        [SerializeField] private string _playerTag;
        
        // private void OnCollisionEnter(Collision collision)
        // {
        //     if (collision.gameObject.CompareTag(_playerTag))
        //     {
        //         GameStateManager.Instance.Die();
        //     
        //         Destroy(collision.gameObject);
        //     }
        // }
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag(_playerTag))
            {
                GameStateManager.Instance.Die();
            
                Destroy(collision.gameObject);
            }
        }
    }
}