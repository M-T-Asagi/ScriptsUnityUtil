using UnityEngine;

namespace AsagiHandy.Debugging
{
    public class LoggerMono : MonoBehaviour
    {
        [SerializeField]
        bool isDebug = false;

        private void Start()
        {
            Logger.SetIsDebug(isDebug);
        }

        public void Log(string text)
        {
            Logger.Log(text);
        }

        public void Warning(string text)
        {
            Logger.Warning(text);
        }

        public void Error(string text)
        {
            Logger.Error(text);
        }
    }
}