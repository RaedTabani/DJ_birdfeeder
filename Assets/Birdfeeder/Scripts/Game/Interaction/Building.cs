using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour,IInteractable
{
    public BuildingModel model;
    private bool ready = false;
    private float progress =0 ;
    private GameObject currency;
    private GameObject progressbar;
    private Image fill;
    void Start()
    {
        currency = transform.Find("Canvas/Currency").gameObject;
        progressbar = transform.Find("Canvas/Progress").gameObject;
        fill = transform.Find("Canvas/Progress/Fill").GetComponent<Image>();
    }

    public void Setup(BuildingModel model){
        this.model = model;
    }

    // Update is called once per frame
    void Update()
    {
        if(ready)
            return;
        progress +=Time.deltaTime;
        fill.fillAmount = progress/3f;

        if(progress>= 3){
            currency.SetActive(true);
            progressbar.SetActive(false);
            ready=true;
        }
            
    }
    public void Interact(){
        //Play Animation
        //Harvest Money if ready
        if(!ready)
            return;
        currency.SetActive(false);
        progress = 0;
        ready = false;
        progressbar.SetActive(true);

    }
}
