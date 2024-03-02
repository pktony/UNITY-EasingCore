using UnityEngine;

namespace AnimationClipUtility
{
    using Type;

    public static class AnimationClipUtility
    {
        #region Base
        /// <summary>
        /// Sets an animation curve to the animation clip
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="animationPropertyType"></param>
        /// <param name="easeType"></param>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <param name="startTime"></param>
        /// <param name="duration">duration(end time) of the animation</param>
        /// <param name="eventFunctionName">name of the custom event triggered in the animation. 
        /// The event is triggered at the end of the animation. Use <see cref="AddEvent"/> if you want to trigger at a speicific time.</param>
        /// <param name="destinationHierarchy">A specific hierarchy the object is animated. Use '/'to separate each hierachy</param>
        /// <returns></returns>
        public static AnimationCurve SetCurve(this AnimationClip clip, AnimationPropertyType animationPropertyType,
            EaseType easeType,
            float startPos, float endPos, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            if (AnimationPropertyType.CombinedType.Contains(animationPropertyType))
            {
                Debug.LogWarning($"AnimationClipUtility : Should not use combined type for this function. use combined function instead");
                return null ;
            }

            var curve = EasingCore.GetCurve(easeType, startTime, duration, startPos, endPos);

            clip.SetCurve(destinationHierarchy, AnimationPropertyType.PropertyType[animationPropertyType], animationPropertyType.Name, curve);

            if (string.IsNullOrEmpty(eventFunctionName)) return null;
            clip.AddEvent(duration, eventFunctionName);

            return curve;
        }

        /// <summary>
        /// Resets all the events in an animation clip.
        /// </summary>
        /// <param name="clip"></param>
        public static void ResetAllEvent(this AnimationClip clip)
        {
            clip.events = null;
        }

        /// <summary>
        /// Adds an event to an animation clip
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="eventTime"></param>
        /// <param name="eventFunctionName"></param>
        public static void AddEvent(this AnimationClip clip, float eventTime, string eventFunctionName)
        {
            AnimationEvent animEvent = new();
            animEvent.functionName = eventFunctionName;
            animEvent.time = eventTime;
            clip.AddEvent(animEvent);
        }
        #endregion
    
        public static void SetCurvePosition(this AnimationClip clip, EaseType easeType,
            Vector2 initialPos, Vector2 targetPos, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurve(AnimationPropertyType.AnchoredPositionX, easeType, initialPos.x, targetPos.x,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurve(AnimationPropertyType.AnchoredPositionY, easeType, initialPos.y, targetPos.y,
                startTime, duration, eventFunctionName, destinationHierarchy);
        }

        public static void SetCurveRotation(this AnimationClip clip, EaseType easeType,
            Quaternion initialRotation, Quaternion targetRotation, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurve(AnimationPropertyType.RotationX, easeType, initialRotation.x, targetRotation.x,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurve(AnimationPropertyType.RotationY, easeType, initialRotation.y, targetRotation.y,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurve(AnimationPropertyType.RotationZ, easeType, initialRotation.z, targetRotation.z,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurve(AnimationPropertyType.RotationW, easeType, initialRotation.w, targetRotation.w,
                startTime, duration, eventFunctionName, destinationHierarchy);
        }

        public static void SetCurveSizeDelta(this AnimationClip clip, EaseType easeType,
            Vector2 initialSize, Vector2 targetSize, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurve(AnimationPropertyType.SizeDeltaX, easeType, initialSize.x, targetSize.x,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurve(AnimationPropertyType.SizeDeltaY, easeType, initialSize.y, targetSize.y,
                startTime, duration, eventFunctionName, destinationHierarchy);
        }
    }
}