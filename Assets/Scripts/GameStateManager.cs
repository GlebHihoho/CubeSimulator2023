using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance;
        
        private bool _isDead = false;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
                return;
            }
            
            Instance = this;
        }

        public void Die()
        {
            Debug.Log("Player Died");
            _isDead = true;
        }
    }
}