using UnityEngine;

namespace AsagiHandy.Debugging
{
    public static class Logger
    {
        public static bool isDebug = true;

        public static void SetIsDebug(bool _isDebug)
        {
            isDebug = _isDebug;
        }

        public static void Log(string text)
        {
            if (isDebug)
                Debug.Log(text);
        }

        public static void Warning(string text)
        {
            if (isDebug)
                Debug.LogWarning(text);
        }

        public static void Error(string text)
        {
            if (isDebug)
                Debug.LogError(text);
        }
    }
}