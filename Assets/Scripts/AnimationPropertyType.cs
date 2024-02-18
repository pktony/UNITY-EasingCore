using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace AnimationClipUtility.Type
{
    public class AnimationPropertyType : Enumeration
    {
        public AnimationPropertyType(int id, string name) : base(id, name) { }

        public static AnimationPropertyType AnchoredPositionX = new(0, "m_AnchoredPosition.x");
        public static AnimationPropertyType AnchoredPositionY = new(1, "m_AnchoredPosition.y");
        public static AnimationPropertyType AnchoredPosition = new(2, "m_AnchoredPosition");
        public static AnimationPropertyType RotationX = new(3, "localRotation.x");
        public static AnimationPropertyType RotationY = new(4, "localRotation.y");
        public static AnimationPropertyType RotationZ = new(5, "localRotation.z");
        public static AnimationPropertyType RotationW = new(6, "localRotation.w");
        public static AnimationPropertyType Rotation = new(7, "localRotation");
        public static AnimationPropertyType SizeDeltaX = new(8, "m_SizeDelta.x");
        public static AnimationPropertyType SizeDeltaY = new(9, "m_SizeDelta.y");
        public static AnimationPropertyType SizeDelta = new(10, "m_SizeDelta");
        public static AnimationPropertyType ScaleX = new(11, "m_LocalScale.x");
        public static AnimationPropertyType ScaleY = new(12, "m_LocalScale.y");
        public static AnimationPropertyType ScaleZ = new(13, "m_LocalScale.z");
        public static AnimationPropertyType Scale = new(14, "m_LocalScale");

        public static AnimationPropertyType FontSize = new(100, "m_fontSize");
        public static AnimationPropertyType ImageSprite = new(200, "m_Sprite");

        public static AnimationPropertyType CanvasGroupAlpha = new(300, "m_Alpha");


        public static Dictionary<AnimationPropertyType, System.Type> PropertyType = new()
        {
            { AnchoredPositionX, typeof(RectTransform)},
            { AnchoredPositionY, typeof(RectTransform)},
            { AnchoredPosition, typeof(RectTransform)},
            { RotationX, typeof(RectTransform)},
            { RotationY, typeof(RectTransform)},
            { RotationZ, typeof(RectTransform)},
            { RotationW, typeof(RectTransform)},
            { Rotation, typeof(RectTransform)},
            { SizeDeltaX, typeof(RectTransform)},
            { SizeDeltaY, typeof(RectTransform)},
            { SizeDelta, typeof(RectTransform)},
            { ScaleX, typeof(RectTransform)},
            { ScaleY, typeof(RectTransform)},
            { ScaleZ, typeof(RectTransform)},
            { Scale, typeof(RectTransform)},
            { FontSize, typeof(TextMeshProUGUI)},
            { ImageSprite, typeof(Image)},
            { CanvasGroupAlpha, typeof(CanvasGroup) },
        };

        public static List<AnimationPropertyType> CombinedType = new()
        {
            AnchoredPosition,
            Rotation,
            SizeDelta,
            Scale
        };
    }

    public abstract class Enumeration : IEquatable<Enumeration>, IComparable
    {
        public string Name { get; protected set; }

        public int ID { get; protected set; }

        protected Enumeration(int id)
        {
            ID = id;
            Name = id.ToString();
        }

        protected Enumeration(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = ID.Equals(otherValue.ID);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => ID.CompareTo(((Enumeration)other).ID);

        public bool Equals(Enumeration other)
        {
            return other != null &&
                   Name == other.Name &&
                   ID == other.ID;
        }

        public static bool operator ==(Enumeration enumeration1, Enumeration enumeration2)
        {
            return EqualityComparer<Enumeration>.Default.Equals(enumeration1, enumeration2);
        }

        public static bool operator !=(Enumeration enumeration1, Enumeration enumeration2)
        {
            return !(enumeration1 == enumeration2);
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        protected static int cashedHash = "Enumeration".GetHashCode();

        public override int GetHashCode()
        {
            return cashedHash;
        }
    }

}