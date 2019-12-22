using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimationSaver : MonoBehaviour
{

#if UNITY_EDITOR
    [System.Serializable]
    public class SavingTarget
    {
        public bool position;
        public bool rotation;
        public bool scale;

        public SavingTarget(bool _position, bool _rotation, bool _scale)
        {
            position = _position;
            rotation = _rotation;
            scale = _scale;
        }
    }

    private SavingTarget target;
    private bool saving = false;
    private string filename;
    private AnimationClip clip;

    private Dictionary<string, AnimationCurve> curves;
    private float timeStartSaving = 0;

    Transform thisTransform;
    Rigidbody thisRigidbody;

    bool useRigidbody = false;

    // Use this for initialization
    void Start()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Resources"))
            AssetDatabase.CreateFolder("Assets", "Resources");
        if (!AssetDatabase.IsValidFolder("Assets/Resources/SavedAnimations"))
            AssetDatabase.CreateFolder("Assets/Resources", "SavedAnimations");

        thisRigidbody = GetComponent<Rigidbody>();
        if (thisRigidbody == null)
            thisTransform = transform;
        else
            useRigidbody = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (saving)
            SavingProcess();
    }

    private void SavingProcess()
    {
        float elapsedTime = Time.time - timeStartSaving;
        if (target.position)
        {
            Vector3 pos = (useRigidbody) ? thisRigidbody.position : thisTransform.position;
            curves["positionx"].AddKey(elapsedTime, pos.x);
            curves["positiony"].AddKey(elapsedTime, pos.y);
            curves["positionz"].AddKey(elapsedTime, pos.z);
        }
        if (target.rotation)
        {
            Vector3 rota = (useRigidbody) ? thisRigidbody.rotation.eulerAngles : thisTransform.eulerAngles;
            Debug.Log(rota);
            curves["rotationx"].AddKey(elapsedTime, rota.x);
            curves["rotationy"].AddKey(elapsedTime, rota.y);
            curves["rotationz"].AddKey(elapsedTime, rota.z);
        }
        if (target.scale)
        {
            Vector3 scale = thisTransform.localScale;
            curves["scalex"].AddKey(elapsedTime, scale.x);
            curves["scaley"].AddKey(elapsedTime, scale.y);
            curves["scalez"].AddKey(elapsedTime, scale.z);
        }
    }

    public void CreateNew(SavingTarget _target, string _fileName = "")
    {
        if (saving)
        {
            Debug.LogError("Animation is saving");
            return;
        }

        saving = true;

        clip = new AnimationClip();
        target = _target;

        curves = new Dictionary<string, AnimationCurve>();

        if (target.position)
        {
            curves["positionx"] = new AnimationCurve();
            curves["positiony"] = new AnimationCurve();
            curves["positionz"] = new AnimationCurve();
        }

        if (target.rotation)
        {
            curves["rotationx"] = new AnimationCurve();
            curves["rotationy"] = new AnimationCurve();
            curves["rotationz"] = new AnimationCurve();
        }

        if (target.scale)
        {
            curves["scalex"] = new AnimationCurve();
            curves["scaley"] = new AnimationCurve();
            curves["scalez"] = new AnimationCurve();
        }


        filename = _fileName + ((_fileName == "") ? "" : "-") + System.DateTime.Now.ToFileTimeUtc() + ".anim";

        Debug.Log("start saving!");

        timeStartSaving = Time.time;
    }

    public void Save()
    {
        if (!saving)
        {
            Debug.LogError("Animation is not saving!");
            return;
        }

        if (target.position)
        {
            clip.SetCurve("", typeof(Transform), "localPosition.x", curves["positionx"]);
            clip.SetCurve("", typeof(Transform), "localPosition.y", curves["positiony"]);
            clip.SetCurve("", typeof(Transform), "localPosition.z", curves["positionz"]);
        }

        if (target.rotation)
        {
            clip.SetCurve("", typeof(Transform), "localRotation.x", curves["rotationx"]);
            clip.SetCurve("", typeof(Transform), "localRotation.y", curves["rotationy"]);
            clip.SetCurve("", typeof(Transform), "localRotation.z", curves["rotationz"]);
        }

        if (target.scale)
        {
            clip.SetCurve("", typeof(Transform), "localScale.x", curves["scalex"]);
            clip.SetCurve("", typeof(Transform), "localScale.y", curves["scaley"]);
            clip.SetCurve("", typeof(Transform), "localScale.z", curves["scalez"]);
        }

        AssetDatabase.CreateAsset(
                clip,
                AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/SavedAnimations/" + filename)
            );

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        saving = false;
        clip = null;
        filename = "";

        Debug.Log("finish saving!");
    }

    private void OnDestroy()
    {
        if (saving)
            Save();
    }

    private void OnGUI()
    {
#if UNITY_EDITOR
        if (GUI.Button(new Rect(0, 0, 100, 100), "StartSaving"))
        {
            CreateNew(new SavingTarget(true, true, true));
        }
        if (GUI.Button(new Rect(120, 0, 100, 100), "FinishSaving"))
        {
            Save();
        }
#endif
    }
#endif
}
