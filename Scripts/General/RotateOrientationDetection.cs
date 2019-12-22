using UnityEngine;
using UnityEngine.Events;

public class RotateOrientationDetection : MonoBehaviour
{
    [System.Serializable]
    public enum RotateState
    {
        Portrait = 0,
        Landscape,
        Unknown
    }

    [System.Serializable]
    public class OnRotateEvent : UnityEvent<RotateState> { }

    [SerializeField]
    public OnRotateEvent OnRotate;

    RotateState rotateState;

    public RotateState NowRotateState { get { return rotateState; } }

    // Start is called before the first frame update
    void Start()
    {
        if (OnRotate == null)
            OnRotate = new OnRotateEvent();
        rotateState = CheckRotateWithScreenSize();
    }

    // Update is called once per frame
    void Update()
    {
        RotateState newState = CheckRotate();

        if(newState != rotateState)
        {
            rotateState = newState;
            OnRotate?.Invoke(rotateState);
        }
    }

    public static RotateState CheckRotateWithDeviceOrientation()
    {
        switch(Input.deviceOrientation)
        {
            case DeviceOrientation.Portrait:
            case DeviceOrientation.PortraitUpsideDown:
                return RotateState.Portrait;
            case DeviceOrientation.LandscapeLeft:
            case DeviceOrientation.LandscapeRight:
                return RotateState.Landscape;
            default:
                return RotateState.Unknown;
        }
    }

    public static RotateState CheckRotateWithScreenSize()
    {
        Vector2Int screenSize = new Vector2Int(Screen.width, Screen.height);
        if(screenSize.x >= screenSize.y)
        {
            return RotateState.Landscape;
        } else
        {
            return RotateState.Portrait;
        }
    }

    public static RotateState CheckRotateWithScreenOrientation()
    {
        switch(Screen.orientation)
        {
            case ScreenOrientation.Portrait:
            case ScreenOrientation.PortraitUpsideDown:
                return RotateState.Portrait;
            case ScreenOrientation.Landscape:
            case ScreenOrientation.LandscapeRight:
                return RotateState.Landscape;
            default:
                return RotateState.Unknown;
        }
    }

    public static RotateState CheckRotate ()
    {
        RotateState _state;

        #if !UNITY_EDITOR
        _state = CheckRotateWithScreenOrientation();
        if (_state != RotateState.Unknown)
            return _state;

        _state = CheckRotateWithDeviceOrientation();
        if (_state != RotateState.Unknown)
            return _state;
        #endif

        _state = CheckRotateWithScreenSize();

        return _state;
    }
}
