
using UnityEngine;
using UnityEditor;

using AnimationClipUtility;
using AnimationClipUtility.Type;

public class Test : MonoBehaviour
{
    public EaseType easeType;
    public RectTransform rectTransform;
    public Animation anim;

    public float initialPosition = -300;
    public float finalPosition = 300;
    public float finalTime = 1;

    [Header("Test")]
    public AnimationCurve curve;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayAnimation();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.Play();
            var clip = anim.GetClip("");
            EditorCurveBinding[] curveBindings = AnimationUtility.GetCurveBindings(clip);
            foreach(var binding in curveBindings)
            {
                var curve = AnimationUtility.GetEditorCurve(clip, binding);
                for(int i = 0, max = curve.keys.Length; i < max; ++i)
                {
                    Debug.Log($"----------- Key {i} -----------");
                    Debug.Log($"Curve In-tangent : {curve.keys[i].inTangent}");
                    Debug.Log($"Curve out-tangent : {curve.keys[i].outTangent}");
                    Debug.Log($"Curve in-weight : {curve.keys[i].inWeight}");
                    Debug.Log($"Curve out-weight : {curve.keys[i].outWeight}");
                }
            }
        }
    }

    private void PlayAnimation()
    {
        AnimationClip clip = new() { legacy = true };
        curve = clip.SetCurve(AnimationPropertyType.AnchoredPositionY, easeType,
            initialPosition, finalPosition, 0f, finalTime);
        
        PlayAnimationClip(clip);
    }

    private void PlayAnimationClip(AnimationClip clip)
    {
        var originalClip = anim.GetClip(clip.name);
        if(originalClip != null) anim.RemoveClip(clip.name);
        anim.AddClip(clip, clip.name);
        anim.Play(clip.name);
    }
}
