using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

public class EffectsUI: MonoBehaviour
{
    private Transform blackScreen;
    void OnEnable(){
        Session.Instance.events.onSceneReady.AddListener(()=>Show());
    }
    async void Start()
    {
        blackScreen = transform.Find("BlackScreen");
        
    }

    private async void Show(){
        await TweenHelper.DoSlideX(blackScreen,2000,1f);
        
    }
}
