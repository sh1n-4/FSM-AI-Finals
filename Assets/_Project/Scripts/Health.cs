using UnityEngine;

namespace Platformer {
    public class Health : MonoBehaviour {
        [SerializeField] int maxHealth = 100;
        [SerializeField] FloatEventChannel playerHealthChannel;
        [SerializeField] private HealthBar healthBarUI;

        [SerializeField] public int currentHealth;
        
        public bool IsDead => currentHealth <= 0;
        
        void Awake() {
            currentHealth = maxHealth;
        }

        void Start() {
            PublishHealthPercentage();
        }
        
        public void TakeDamage(int damage) {
            currentHealth -= damage;
            PublishHealthPercentage();
        }

        void PublishHealthPercentage() 
        {
            float percent = currentHealth / (float)maxHealth;

            if (playerHealthChannel != null)
            {
                playerHealthChannel.Invoke(percent);
            }

            if (healthBarUI != null)
            {
                healthBarUI.UpdateHealthBar(percent);
            }
         
        }
    }
}