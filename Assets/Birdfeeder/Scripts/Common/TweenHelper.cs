using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

using DG.Tweening;
public static class TweenHelper 
{
    public static void DoPop(Transform obj,Vector3 value, float duration){
        obj.DOScale(value,duration);
    }
    public static async Task DoSlideX(Transform obj,float value, float duration){
        await obj.DOLocalMoveX(value,duration).AsyncWaitForCompletion();
    }
    public static async Task DoSlideY(Transform obj,float value, float duration){
        await obj.DOLocalMoveY(value,duration).AsyncWaitForCompletion();
    }
}
