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

        ExponentialOut,
        ExponentialIn,
        ExponentialInOut,

        EaseInBack,
        EaseOutBack,
        EaseInOutBack,

        BounceOut,
        BounceIn,
    }

    public class EasingCore
    {

        public static AnimationCurve GetCurve(EaseType easeType,
            float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            return easeType switch
            {
                EaseType.Linear => Linear(startTime, endTime, initPosition, finalPosition),
                EaseType.EaseInOut => EaseInOut(startTime, endTime, initPosition, finalPosition),
                EaseType.EaseOut => EaseOut(startTime, endTime, initPosition, finalPosition),
                EaseType.EaseIn => EaseIn(startTime, endTime, initPosition, finalPosition),
                EaseType.Constant => Constant(startTime, endTime, finalPosition),
                EaseType.ExponentialIn => ExponentialIn(startTime, endTime, initPosition, finalPosition),
                EaseType.ExponentialOut => ExponentialOut(startTime, endTime, initPosition, finalPosition),
                EaseType.ExponentialInOut => ExponentialInOut(startTime, endTime, initPosition, finalPosition),
                EaseType.EaseInBack => EaseInBack(startTime, endTime, initPosition, finalPosition),
                EaseType.EaseOutBack => EaseOutBack(startTime, endTime, initPosition, finalPosition),
                EaseType.EaseInOutBack => EaseInOutBack(startTime, endTime, initPosition, finalPosition),
                EaseType.BounceOut => BounceOut(startTime, endTime, initPosition, finalPosition),
                EaseType.BounceIn => BounceIn(startTime, endTime, initPosition, finalPosition),
                _ => Linear(startTime, endTime, initPosition, finalPosition),
            };
        }

        public static AnimationCurve BounceIn(float startTime, float endTime,
            float startPos, float endPos)
        {
            var totalTime = endTime - startTime;
            var linearStartTime = startTime + totalTime * 0.4f;
            float linearSlope = (endPos - startPos) / (endTime - linearStartTime);
            Keyframe[] easeInBackKeys = new Keyframe[5]
            {
                new(startTime, startPos, 0f, linearSlope),
                new(startTime + totalTime * 0.05f, startPos, -linearSlope, linearSlope),
                new(startTime + totalTime * 0.2f, startPos, -linearSlope, linearSlope),
                new(startTime + totalTime * 0.4f, startPos, -linearSlope, linearSlope),
                new(endTime, endPos),
            };
            var test = new AnimationCurve(easeInBackKeys);
            return test;
        }

        public static AnimationCurve BounceOut(float startTime, float endTime,
            float startPos, float endPos)
        {
            var totalTime = endTime - startTime;
            var linearEndTime = startTime + totalTime * 0.6f;
            float linearSlope = (endPos - startPos) / (linearEndTime - startTime);
            Keyframe[] easeInBackKeys = new Keyframe[5]
            {
                new(startTime, startPos),
                new(linearEndTime, endPos, linearSlope, -linearSlope),
                new(startTime + totalTime * 0.8f, endPos, linearSlope, -linearSlope),
                new(startTime + totalTime * 0.95f, endPos, linearSlope, -linearSlope),
                new(endTime, endPos, linearSlope, 0f),
            };
            return new AnimationCurve(easeInBackKeys);
        }

        public static AnimationCurve EaseInOutBack(float startTime, float endTime,
            float startPos, float endPos)
        {
            var positionDiff = endPos - startPos;
            Keyframe[] easeInBackKeys = new Keyframe[2]
            {
                new(startTime, startPos, 0, -positionDiff, 0, 0.25f),
                new(endTime, endPos, -positionDiff, 0f, 0.25f, 0f),
            };
            return new AnimationCurve(easeInBackKeys);
        }

        public static AnimationCurve EaseOutBack(float startTime, float endTime,
            float startPos, float endPos)
        {
            var positionDiff = endPos - startPos;
            Keyframe[] easeInBackKeys = new Keyframe[2]
            {
                new(startTime, startPos, 0, 0f),
                new(endTime, endPos, -positionDiff, 0f, 0.25f, 0f),
            };
            return new AnimationCurve(easeInBackKeys);
        }

        public static AnimationCurve EaseInBack(float startTime, float endTime,
            float startPos, float endPos)
        {
            var positionDiff = endPos - startPos;
            Keyframe[] easeInBackKeys = new Keyframe[2]
            {
                new(startTime, startPos, 0, -positionDiff, 0f, 0.25f),
                new(endTime, endPos, 0f, 0f),
            };
            return new AnimationCurve(easeInBackKeys);
        }

        public static AnimationCurve ExponentialInOut(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            float slope = (finalPosition - initPosition) / (endTime - startTime);
            Keyframe[] exponentialKeys = new Keyframe[3]
            {
                new(startTime, initPosition,
                    0f, 0f, 0f, 0.9f),
                new(endTime * 0.5f, (finalPosition + initPosition) * 0.5f,
                    slope * 10f, slope * 10f, 0.1f, 0.1f),
                new(endTime, finalPosition,
                    0f, 0f, 0.9f, 0f)
            };
            return new AnimationCurve(exponentialKeys);
        }

        public static AnimationCurve ExponentialOut(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            float slope = (finalPosition - initPosition) / (endTime - startTime);
            Keyframe[] exponentialKeys = new Keyframe[2]
            {
                new(startTime, initPosition,
                    0f, slope * 10f, 0f, 0.1f),
                new(endTime, finalPosition,
                    0f, 0f, 0.9f, 0f),
            };
            return new AnimationCurve(exponentialKeys);
        }

        public static AnimationCurve ExponentialIn(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            float slope = (finalPosition - initPosition) / (endTime - startTime);
            Keyframe[] exponentialKeys = new Keyframe[2]
            {
                new(startTime, initPosition, 0f, 0f, 0f, 0.9f),
                new(endTime, finalPosition, slope * 10f, 0f, 0.1f, 0f)
            };
            return new AnimationCurve(exponentialKeys);
        }

        public static AnimationCurve EaseOut(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            float slope = (finalPosition - initPosition) / (endTime - startTime);
            Keyframe[] array = new Keyframe[2]
            {
                new(startTime, initPosition, slope, slope),
                new(endTime, finalPosition, 0f, 0f)
            };
            return new AnimationCurve(array);
        }

        public static AnimationCurve EaseIn(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            float slope = (finalPosition - initPosition) / (endTime - startTime);
            Keyframe[] array = new Keyframe[2]
            {
                new(startTime, initPosition, 0f, 0f),
                new(endTime, finalPosition, slope, 0f)
            };
            return new AnimationCurve(array);
        }

        public static AnimationCurve EaseInOut(float startTime, float endTime,
            float initPosition, float finalPosition)
        {
            Keyframe[] array = new Keyframe[2]
            {
                new(startTime, initPosition),
                new(endTime, finalPosition)
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