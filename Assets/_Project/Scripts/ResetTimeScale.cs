using UnityEngine;

namespace Platformer
{
    public class ResetTimeScale : MonoBehaviour
    {
        void Awake()
        {
            Time.timeScale = 1f;
        }
    }
}
