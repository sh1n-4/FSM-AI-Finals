using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class GameOver : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] PlayerController player;
        Health playerHealth;

        [Header("Enemy")]
        [SerializeField] private GameObject enemyDefeatedPanel;
        [SerializeField] EnemyController enemy;
        Health enemyHealth;


        //[SerializeField] public string sceneName = "Stage";
        [SerializeField] SceneLoader sceneLoader;



        void Awake()
        {
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(false);
            }

            if (enemyDefeatedPanel != null)
            {
                enemyDefeatedPanel.SetActive(false);
            }

            playerHealth = player.GetComponentInParent<Health>();
            enemyHealth = enemy.GetComponentInParent<Health>();
        }

        

        void Update()
        {
            if (playerHealth != null)
            {
                if (playerHealth.IsDead)
                {
                    gameOverPanel.SetActive(true);
                    Time.timeScale = 0f;
                }
            }

            if (enemyHealth != null)
            {
                if (enemyHealth.IsDead)
                {
                    enemyDefeatedPanel.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
        }



        /*public void Restart()
        {
            sceneLoader.ReloadCurrentScene();
        }*/

        public void MainMenu()
        {
            sceneLoader.sceneName = "Main Menu";
            sceneLoader.GoToScene();
        }
    }
}
