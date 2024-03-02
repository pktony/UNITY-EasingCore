# Animation Utility For Unity

## Table of Contents

- [About](#about)
- [Getting Started](#getting_started)
- [Examples](#example)
- [Code Overview](#code_overview)
- [Reference](#references)

## About <a name = "about"></a>

This repository implements animation utility for Unity 3D. It uses legacy animation clip and animation curve. It is implemented base on the official Unity document + a. see [referece](#references) section for details.

I'm not an expert at animation, so I made an easy way to animate, especially in UIs. I understand that the function has multiple parameters, and not easy to understand at a glance, nevertheless, I tried my best to generalize and simplify the function. Feel free to modify this code! Use your imagination to develop this codes !

Also take a look at my blog for more detailed explanation. (KOREAN) [Tistory Blog](coming soon)

**NOTICE** <br>
Some animation curves are not really based on the exact equation. But I tried my best to look similar. see [reference](#references) where I referenced curves.

## Getting Started <a name = "getting_started"></a>

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See [deployment](#deployment) for notes on how to deploy the project on a live system.

### Tested On

Unity 2021.3.33f1
Currently live on a product. (AOS / iOS)

### Installation

A step by step series of examples that tell you how to get a development env running.

```
Unity Package git url
```

Now you are all set ! Enjoy animating !


### Tips

#### Playing Animation : <br>
 Use Unity component, "[Animation](#https://docs.unity3d.com/ScriptReference/Animation.html)". Create animation clip in run-time, and 

Recommended way
 ```
private void PlayAnimationClip(AnimationClip clip)
{
    var originalClip = anim.GetClip(clip.name);
    if (originalClip != null) anim.RemoveClip(clip.name);
    anim.AddClip(clip, clip.name);
    anim.Play(clip.name);
}
 ```

#### Animation Loop : 
 Use [Wrapmode](#https://docs.unity3d.com/ScriptReference/AnimationClip-wrapMode.html) in animation clip to control loop mode.<br>
 There are **Once, Loop, PingPong, Default, ClampForever**
 
#### Using Hierarchy :
 When you want to animate the component in the child component, use hierarchy parmeter.<br>
 hierarchy should be the name of the child Transform, and should be joined with '/' <br>
 Example:<br>
      - Parent (Animation Component) <br>
        |-- child_1 (Transform) <br>
        |-- child_2 (Image) <br>
                |-- grandchild () <br>
        
when you want to animate child_1 the hierarchy parameter should look like "Parent/child_1"

## Example <a name = "example"></a>

Refer to Example Scene in the package.

Animation Samples


## Code Overview <a name= "code_overview"></a>

### AnimationClipUtility
An extension class for animation. Mostly extends Animation Clip.
#### SetCurve
```
public static AnimationCurve SetCurve(this AnimationClip clip, 
    AnimationPropertyType animationPropertyType,
    EaseType easeType,
    float startPos, float endPos, float startTime, float duration,
    string eventFunctionName = "", string destinationHierarchy = "")
```
##### Details
Extends AnimationClip. Base function of all the other methods. 
##### Parameters
**AnimationPropertyType** | [AnimationPropertyType](#animation_property_type) Type of the property you would like to animate<br>
**EaseType** | [EaseType](#ease_type) Type of curve<br>
**startPos(float)** | initial value of the animation<br>
**endPos(float)** | final value of the animation<br>
**startTime(float)** | initial time of the animation (usually 0).<br>
**duration(float)** | duration of the animation.
**eventFunctionName(string)** | name of the custom function, you would like to trigger. Leave empty if no event is triggered.<br>
**destinationHierarachy(string)** | hierarchy of the object you want to animate. Leave empty if animating the object where animation component is attached.<br>

#### SetCurvePosition
```
public static void SetCurvePosition(this AnimationClip clip, EaseType easeType,
        Vector2 initialPos, Vector2 targetPos, float startTime, float duration,
        string eventFunctionName = "", string destinationHierarchy = "")
```
##### Details
Sets a **position** animation curve to the clip.

#### SetCurveRotation
```
public static void SetCurveRotation(this AnimationClip clip, EaseType easeType,
        Quaternion initialRotation, Quaternion targetRotation, float startTime, float duration,
        string eventFunctionName = "", string destinationHierarchy = "")
```
##### Details
Sets a **rotation** animation curve to the clip.

#### SetCurveSizeDelta
```
public static void SetCurveSizeDelta(this AnimationClip clip, EaseType easeType,
        Vector2 initialSize, Vector2 targetSize, float startTime, float duration,
        string eventFunctionName = "", string destinationHierarchy = "")
```
##### Details
Sets a **Size Delta** animation curve to the clip.

--- 

### AnimationPropertyType <a name="animation_property_type"></a>
Defines the name of the animation property. i.e.) anchored position => m_AnchoredPosition
#### Supported Types
```
AnchoredPostion (X, Y)
Rotation (X, Y, Z)
SizeDelta (X, Y)
Scale (X, Y, Z)

TMPRO Font Size
Sprite
Alpha
```

You can actually add more properties yourself as long as you know the Unity's internal name for each properties.

---

### EasingCore <a name="easing_core"></a>
#### EaseType
```
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
```

## Reference <a name = "references"></a>
- [Figma Learn - Prototype easing and spring animations](#https://help.figma.com/hc/en-us/articles/360051748654-Prototype-easing-and-spring-animations#Easing_Bezier_presets)
- [Unity-EasingLibraryVisualization](#https://github.com/noisecrime/Unity-EasingLibraryVisualisation)
- [Easing Cheatsheet](#https://easings.net/)
- [Unity - AnimationCurve](#https://docs.unity3d.com/ScriptReference/AnimationCurve-ctor.html)
- [Unity - AnimationClip](#https://docs.unity3d.com/ScriptReference/AnimationClip.html)
- [Unity - Keyframe](#https://docs.unity3d.com/ScriptReference/Keyframe.html)