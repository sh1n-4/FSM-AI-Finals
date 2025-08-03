using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private Button settingsBTN;

        void Awake()
        {
            if (settingsPanel != null)
            {
                settingsPanel.SetActive(false);
                settingsBTN.onClick.AddListener(Pause);

            }
        }


        public void Pause()
        {
            if (settingsPanel != null)
            {
                settingsPanel.SetActive(true);
                settingsBTN.gameObject.SetActive(false);
                Time.timeScale = 0f;
            }
        }

        public void Resume()
        {
            if (settingsPanel != null)
            {
                settingsPanel.SetActive(false);
                settingsBTN.gameObject.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }
}
