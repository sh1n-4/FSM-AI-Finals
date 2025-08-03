using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneName = "";

        public void GoToScene()
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
        }

        public void ReloadCurrentScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        public void QuitGame()
        {
            //Application.Quit();

            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
