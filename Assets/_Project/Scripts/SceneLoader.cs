using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] public string sceneName = "";

        public void GoToScene()
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Time.timeScale = 1f;
        }

        public void QuitGame()
        {
            //Application.Quit();

            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
