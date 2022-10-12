using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

public class EffectsSplash: MonoBehaviour
{
    private Transform blackScreen;
    async void Start()
    {
        blackScreen = transform.Find("BlackScreen");
        await Task.Run(async ()=>{
            while(!Session.Instance.ready)
                await Task.Delay(25);
            return true;
        });
        await TweenHelper.DoSlideX(blackScreen,0,1f);
        Session.Instance.events.onSplashReady.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
