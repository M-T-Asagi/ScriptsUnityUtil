using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ApplicationFocusPosedEventer : MonoBehaviour
{
    public UnityEvent ApplicationOut = null;
    public UnityEvent ApplicationFocusIn = null;
    public UnityEvent ApplicationFocusOut = null;
    public UnityEvent ApplicationPauseOut = null;
    public UnityEvent ApplicationPauseIn = null;

    private void OnApplicationQuit()
    {
        ApplicationOut?.Invoke();
    }

    private void OnApplicationFocus(bool focus)
    {
        if(focus)
        {
            ApplicationFocusIn?.Invoke();
        } else
        {
            ApplicationFocusOut?.Invoke();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            ApplicationPauseIn?.Invoke();
        } else
        {
            ApplicationPauseOut?.Invoke();
        }
    }
}
