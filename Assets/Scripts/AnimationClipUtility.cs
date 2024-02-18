using UnityEngine;

namespace AnimationClipUtility
{
    using Type;

    public static class AnimationClipUtility
    {
        #region Linear
        public static void SetCurveLinearPosition(this AnimationClip clip, Vector2 initialState, Vector2 targetState, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurveLinear(AnimationPropertyType.AnchoredPositionX, initialState.x, targetState.x,
                startTime, duration, eventFunctionName, destinationHierarchy); ;
            clip.SetCurveLinear(AnimationPropertyType.AnchoredPositionY, initialState.y, targetState.y,
                startTime, duration, eventFunctionName, destinationHierarchy);
        }

        public static void SetCurveLinearRotation(this AnimationClip clip, Quaternion initialRotation, Quaternion targetRotation, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurveLinear(AnimationPropertyType.RotationX, initialRotation.x, targetRotation.x,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveLinear(AnimationPropertyType.RotationY, initialRotation.y, targetRotation.y,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveLinear(AnimationPropertyType.RotationZ, initialRotation.z, targetRotation.z,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveLinear(AnimationPropertyType.RotationW, initialRotation.w, targetRotation.w,
                startTime, duration, eventFunctionName, destinationHierarchy);
        }

        public static void SetCurveLinearSizeDelta(this AnimationClip clip, Vector2 initialSize, Vector2 targetSize, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurveLinear(AnimationPropertyType.SizeDeltaX, initialSize.x, targetSize.x,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveLinear(AnimationPropertyType.SizeDeltaY, initialSize.y, targetSize.y,
                startTime, duration, eventFunctionName, destinationHierarchy);
        }
        #endregion

        #region EaseInOut
        public static void SetCurveEaseInOutPosition(this AnimationClip clip, Vector2 initialState, Vector2 targetState, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurveEaseInOut(AnimationPropertyType.AnchoredPositionX, initialState.x, targetState.x,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveEaseInOut(AnimationPropertyType.AnchoredPositionY, initialState.y, targetState.y,
                startTime, duration, eventFunctionName, destinationHierarchy);
        }

        public static void SetCurveEaseInOutRotation(this AnimationClip clip, Quaternion initialRotation, Quaternion targetRotation, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurveEaseInOut(AnimationPropertyType.RotationX, initialRotation.x, targetRotation.x,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveEaseInOut(AnimationPropertyType.RotationY, initialRotation.y, targetRotation.y,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveEaseInOut(AnimationPropertyType.RotationZ, initialRotation.z, targetRotation.z,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveEaseInOut(AnimationPropertyType.RotationW, initialRotation.w, targetRotation.w,
                startTime, duration, eventFunctionName, destinationHierarchy);
        }

        public static void SetCurveEaseIntOutSizeDelta(this AnimationClip clip, Vector2 initialSize, Vector2 targetSize, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurveEaseInOut(AnimationPropertyType.SizeDeltaX, initialSize.x, targetSize.x,
                startTime, duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveEaseInOut(AnimationPropertyType.SizeDeltaY, initialSize.y, targetSize.y,
                startTime, duration, eventFunctionName, destinationHierarchy);
        }
        #endregion

        #region EaseOut

        #endregion

        #region Constant
        public static void SetCurveConstantPosition(this AnimationClip clip, Vector2 targetState, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurveConstant(AnimationPropertyType.AnchoredPositionX, targetState.x,
                duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveConstant(AnimationPropertyType.AnchoredPositionY, targetState.y,
                duration, eventFunctionName, destinationHierarchy);
        }

        public static void SetCurveConstantRotation(this AnimationClip clip, Quaternion targetRotation, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurveConstant(AnimationPropertyType.RotationX, targetRotation.x,
                duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveConstant(AnimationPropertyType.RotationY, targetRotation.y,
                duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveConstant(AnimationPropertyType.RotationZ, targetRotation.z,
                duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveConstant(AnimationPropertyType.RotationW, targetRotation.w,
                duration, eventFunctionName, destinationHierarchy);
        }

        public static void SetCurveConstantSizeDelta(this AnimationClip clip, Vector2 targetSize, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            clip.SetCurveConstant(AnimationPropertyType.SizeDeltaX, targetSize.x,
                duration, eventFunctionName, destinationHierarchy);
            clip.SetCurveConstant(AnimationPropertyType.SizeDeltaY, targetSize.y,
                duration, eventFunctionName, destinationHierarchy);
        }
        #endregion

        #region Base

        public static AnimationCurve SetCurve(this AnimationClip clip, AnimationPropertyType animationPropertyType,
            EaseType easeType,
            float initialPosition, float endPosition, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            if (AnimationPropertyType.CombinedType.Contains(animationPropertyType))
            {
                Debug.LogWarning($"AnimationClipUtility : Should not use combined type for this function. use combined function instead");
                return null ;
            }

            var curve = EasingCore.GetCurve(easeType, startTime, duration, initialPosition, endPosition);

            clip.SetCurve(destinationHierarchy, AnimationPropertyType.PropertyType[animationPropertyType], animationPropertyType.Name, curve);

            if (string.IsNullOrEmpty(eventFunctionName)) return null;
            clip.AddEvent(duration, eventFunctionName);

            return curve;
        }
        /// <summary>
        /// 동적으로 애니메이션 클립 키프레임을 삽입해야 하는 경우 사용하는 함수 (EASE-IN-OUT)
        /// </summary>
        /// <param name="animationPropertyType">애니메이션의 움직임 종류</param>
        /// <param name="initialPosition">시작 위치</param>
        /// <param name="endPosition">끝 위치 </param>
        /// <param name="duration">지속 시간 (second)</param>
        /// <param name="clip">애니메이션 클립</param>
        /// <param name="eventFunctionName">이벤트 함수 이름</br>이벤트 이름은</param>
        /// <param name="destinationHierarchy">키 프레임이 삽입될 하이라키 상 경로</param>
        public static void SetCurveEaseInOut(this AnimationClip clip, AnimationPropertyType animationPropertyType,
            float initialPosition, float endPosition, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            if (AnimationPropertyType.CombinedType.Contains(animationPropertyType))
            {
                Debug.LogWarning($"AnimationClipUtility : Should not use combined type for this function. use combined function instead");
                return;
            }

            Keyframe[] keyframes = new Keyframe[2];
            keyframes[0] = new Keyframe(startTime, initialPosition);
            keyframes[1] = new Keyframe(duration, endPosition);
            AnimationCurve curve = new(keyframes);

            clip.SetCurve(destinationHierarchy, AnimationPropertyType.PropertyType[animationPropertyType], animationPropertyType.Name, curve);

            if (string.IsNullOrEmpty(eventFunctionName)) return;
            clip.AddEvent(duration, eventFunctionName);
        }

        /// <summary>
        /// 동적으로 애니메이션 클립 키프레임을 삽입해야 하는 경우 사용하는 함수 (EASE-OUT)
        /// </summary>
        /// <param name="animationPropertyType">애니메이션의 움직임 종류</param>
        /// <param name="initialPosition">시작 위치</param>
        /// <param name="endPosition">끝 위치 </param>
        /// <param name="duration">지속 시간 (second)</param>
        /// <param name="clip">애니메이션 클립</param>
        /// <param name="eventFunctionName">이벤트 함수 이름</br>이벤트 이름은</param>
        /// <param name="destinationHierarchy">키 프레임이 삽입될 하이라키 상 경로</param>
        public static void SetCurveEaseOut(this AnimationClip clip, AnimationPropertyType animationPropertyType,
            float initialPosition, float endPosition, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            if (AnimationPropertyType.CombinedType.Contains(animationPropertyType))
            {
                Debug.LogWarning($"AnimationClipUtility : Should not use combined type for this function. use combined function instead");
                return;
            }

            float slope = (endPosition - initialPosition) / (duration - startTime);
            Keyframe[] array = new Keyframe[2]
            {
                new Keyframe(startTime, initialPosition, 0f, slope),
                new Keyframe(duration, endPosition, 0f, 0f)
            };
            var curve = new AnimationCurve(array);

            clip.SetCurve(destinationHierarchy, AnimationPropertyType.PropertyType[animationPropertyType], animationPropertyType.Name, curve);

            if (string.IsNullOrEmpty(eventFunctionName)) return;
            clip.AddEvent(duration, eventFunctionName);
        }

        /// <summary>
        /// 동적으로 애니메이션 클립 키프레임을 삽입해야 하는 경우 사용하는 함수 (Linear)
        /// </summary>
        /// <param name="animationPropertyType">애니메이션의 움직임 종류</param>
        /// <param name="initialPosition">시작 위치</param>
        /// <param name="endPosition">끝 위치 </param>
        /// <param name="duration">지속 시간 (second)</param>
        /// <param name="clip">애니메이션 클립</param>
        /// <param name="eventFunctionName">이벤트 함수 이름</param>
        /// <param name="destinationHierarchy">키 프레임이 삽입될 하이라키 상 경로</param>
        public static void SetCurveLinear(this AnimationClip clip, AnimationPropertyType animationPropertyType,
            float initialPosition, float endPosition, float startTime, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            if (AnimationPropertyType.CombinedType.Contains(animationPropertyType))
            {
                Debug.LogWarning($"AnimationClipUtility : Should not use combined type for this function. Use combined function instead");
                return;
            }

            AnimationCurve curve = AnimationCurve.Linear(startTime, initialPosition, duration, endPosition);

            clip.SetCurve(destinationHierarchy, AnimationPropertyType.PropertyType[animationPropertyType], animationPropertyType.Name, curve);

            if (string.IsNullOrEmpty(eventFunctionName)) return;
            clip.AddEvent(duration, eventFunctionName);
        }

        /// <summary>
        /// 동적으로 애니메이션 클립 키프레임을 삽입해야 하는 경우 사용하는 함수 (Constant)
        /// </summary>
        /// <param name="animationPropertyType">애니메이션의 움직임 종류</param>
        /// <param name="initialPosition">시작 위치</param>
        /// <param name="endPosition">끝 위치 </param>
        /// <param name="duration">지속 시간 (second)</param>
        /// <param name="clip">애니메이션 클립</param>
        /// <param name="eventFunctionName">이벤트 함수 이름</param>
        /// <param name="destinationHierarchy">키 프레임이 삽입될 하이라키 상 경로</param>
        public static void SetCurveConstant(this AnimationClip clip, AnimationPropertyType animationPropertyType,
            float endPosition, float duration,
            string eventFunctionName = "", string destinationHierarchy = "")
        {
            if (AnimationPropertyType.CombinedType.Contains(animationPropertyType))
            {
                Debug.LogWarning($"AnimationClipUtility : Should not use combined type for this function. Use combined function instead");
                return;
            }

            AnimationCurve curve = AnimationCurve.Constant(0f, duration, endPosition);

            clip.SetCurve(destinationHierarchy, AnimationPropertyType.PropertyType[animationPropertyType], animationPropertyType.Name, curve);

            if (string.IsNullOrEmpty(eventFunctionName)) return;
            clip.AddEvent(duration, eventFunctionName);
        }

        public static void ResetAllEvent(this AnimationClip clip)
        {
            clip.events = null;
        }


        public static void AddEvent(this AnimationClip clip, float eventTime, string eventFunctionName)
        {
            AnimationEvent animEvent = new();
            animEvent.functionName = eventFunctionName;
            animEvent.time = eventTime;
            clip.AddEvent(animEvent);
        }
        #endregion
    }
}