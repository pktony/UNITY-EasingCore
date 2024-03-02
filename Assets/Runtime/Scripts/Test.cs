using System;

using UnityEngine;
using UnityEditor;

namespace AnimationClipUtility.Sample
{
    using Type;

    public class Test : MonoBehaviour
    {
        public EaseType easeType;
        public RectTransform rectTransform;
        public Animation anim;

        public float initialPosition = -300;
        public float finalPosition = 300;
        public float finalTime = 1;

        [Header("Test")]
        public WrapMode wrapMode;

        private void Awake()
        {
            DateTime test = new(2024, 2, 29, 0, 12, 12, 0);
            Debug.Log(test);

            Debug.Log($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayAnimation();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                var clip = anim.GetClip("");
                anim.Play(clip.name);
                EditorCurveBinding[] curveBindings = AnimationUtility.GetCurveBindings(clip);
                foreach (var binding in curveBindings)
                {
                    var curve = AnimationUtility.GetEditorCurve(clip, binding);
                    for (int i = 0, max = curve.keys.Length; i < max; ++i)
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
            clip.wrapMode = wrapMode;
            clip.SetCurve(AnimationPropertyType.AnchoredPositionY, easeType,
                initialPosition, finalPosition, 0f, finalTime);

            PlayAnimationClip(clip);
        }

        private void PlayAnimationClip(AnimationClip clip)
        {
            var originalClip = anim.GetClip(clip.name);
            if (originalClip != null) anim.RemoveClip(clip.name);
            anim.AddClip(clip, clip.name);
            anim.Play(clip.name);
        }
    }
}