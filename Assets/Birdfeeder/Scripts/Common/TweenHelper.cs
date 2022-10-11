using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DG.Tweening;
public static class TweenHelper 
{
    public static void DoPop(Transform obj,Vector3 value, float duration){
        obj.DOScale(value,duration);
    }
}
