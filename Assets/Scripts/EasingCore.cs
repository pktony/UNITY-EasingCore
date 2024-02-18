using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationClipUtility
{
    public enum EaseType
    {
        Linear,
        EaseInOut,
        EaseOut,
        EaseIn,
        Constant,

        Exponential,
        EaseInBack,
        EaseOutBack,
    }

    public class EasingCore
    {

        public static AnimationCurve GetCurve(EaseType easeType,
            float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            switch (easeType)
            {
                case EaseType.Linear:
                    return Linear(startTime, endTime, initPosition, finalPosition);//Linear(startTime, endTime, initPosition, finalPosition);
                case EaseType.EaseInOut:
                    return EaseInOut(startTime, endTime, initPosition, finalPosition);
                case EaseType.EaseOut:
                    return EaseOut(startTime, endTime, initPosition, finalPosition);
                case EaseType.EaseIn:
                    return EaseIn(startTime, endTime, initPosition, finalPosition);
                case EaseType.Constant:
                    return Constant(startTime, endTime, finalPosition);
                case EaseType.Exponential:
                    return Expoential(startTime, endTime, initPosition, finalPosition); //GenerateCurve(initPosition, finalPosition, startTime, endTime, 0.5f, 2f);
                case EaseType.EaseInBack:
                    return EaseInBack(startTime, endTime, initPosition, finalPosition);
                case EaseType.EaseOutBack:
                    return EaseOutBack(startTime, endTime, initPosition, finalPosition);
                default:
                    return Linear(startTime, endTime, initPosition, finalPosition);
            }
        }

        public static AnimationCurve EaseOutBack(float startTime, float endTime,
            float startPos, float endPos)
        {
            var positionDiff = endPos - startPos;
            Keyframe[] easeInBackKeys = new Keyframe[2];
            easeInBackKeys[0] = new Keyframe(startTime, startPos, 0, 0f);
            easeInBackKeys[1] = new Keyframe(endTime, endPos, -positionDiff, 0f, 0.25f, 0f);
            return new AnimationCurve(easeInBackKeys);
        }

        public static AnimationCurve EaseInBack(float startTime, float endTime,
            float startPos, float endPos)
        {
            var positionDiff = endPos - startPos;
            Keyframe[] easeInBackKeys = new Keyframe[2];
            easeInBackKeys[0] = new Keyframe(startTime, startPos, 0, -positionDiff, 0f, 0.25f);
            easeInBackKeys[1] = new Keyframe(endTime, endPos, 0f, 0f);
            return new AnimationCurve(easeInBackKeys);
        }

        public static AnimationCurve Expoential(float startTime, float endTime,
            float initPosition, float finalPosition)
        {//f(x) = a * e^(bx) + c
            float slope = finalPosition - initPosition
                / (endTime - startTime);
            Keyframe[] exponentialKeys = new Keyframe[2];
            exponentialKeys[0] = new Keyframe(startTime, initPosition, 0f, slope);
            exponentialKeys[1] = new Keyframe(endTime, finalPosition, 0f, 0f);

            return new AnimationCurve(exponentialKeys);
        }

        public static AnimationCurve EaseOut(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            float slope = (finalPosition - initPosition) / (endTime - startTime);
            Keyframe[] array = new Keyframe[2]
            {
                new Keyframe(startTime, initPosition, slope, slope),
                new Keyframe(endTime, finalPosition, 0f, 0f)
            };
            return new AnimationCurve(array);
        }

        public static AnimationCurve EaseIn(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            float slope = (finalPosition - initPosition) / (endTime - startTime);
            Keyframe[] array = new Keyframe[2]
            {
                new Keyframe(startTime, initPosition, 0f, 0f),
                new Keyframe(endTime, finalPosition, slope, 0f)
            };
            return new AnimationCurve(array);
        }

        public static AnimationCurve EaseInOut(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            Keyframe[] array = new Keyframe[2]
            {
                new Keyframe(startTime, initPosition),
                new Keyframe(endTime, finalPosition)
            };
            return new AnimationCurve(array);
        }

        public static AnimationCurve Linear(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            return AnimationCurve.Linear(startTime, initPosition, endTime, finalPosition);
        }

        public static AnimationCurve Constant(float startTime, float endTime,
            float finalPosition)
        {
            return AnimationCurve.Constant(startTime, endTime, finalPosition);
        }
    }
}