using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private Camera cam;

        [SerializeField] private Color fullHealthColor;
        [SerializeField] private Color mediumHealthColor;
        [SerializeField] private Color lowHealthColor;

        public void UpdateHealthBar(float percent)
        {
            if (fillImage != null)
            {
                fillImage.fillAmount = Mathf.Clamp01(percent);
                fillImage.color = GetHealthColor(percent);
            }
        }

        void LateUpdate()
        {
            if (target != null)
            {
                transform.position = target.position + offset;

                if (cam == null || !cam.isActiveAndEnabled)
                {
                    cam = Camera.main;
                }

                if (cam != null)
                {
                    transform.forward = cam.transform.forward;
                }
            }
        }

        private Color GetHealthColor(float percent)
        {
            if (percent > 0.5f)
            {
                return Color.Lerp(mediumHealthColor, fullHealthColor, (percent - 0.5f) * 2f);
            } 
            else
            {
                return Color.Lerp(lowHealthColor, mediumHealthColor, percent * 2f);
            }
        }
    }
}
