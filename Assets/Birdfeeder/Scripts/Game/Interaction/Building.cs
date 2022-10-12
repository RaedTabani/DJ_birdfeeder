using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

    void OnEnable(){
        Session.Instance.events.onBuildingUpgrade.AddListener((assetId)=>Upgrade(assetId));
    }
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
        fill.fillAmount = progress/model.time;

        if(progress>= model.time){
            currency.SetActive(true);
            progressbar.SetActive(false);
            ready=true;
        }
            
    }
    public void Interact(){
        //Play Animation
        //Harvest Money if ready
        Debug.Log("Are we here");
        if(!ready)
            return;
        currency.SetActive(false);
        progress = 0;
        ready = false;
        progressbar.SetActive(true);

    }

    private void Upgrade(string assetId){
        if(!model.assetId.Equals(assetId))
            return;
        Debug.Log("Upgrading building "+model.assetId);
        
        var modelDB = Session.Instance.config.buildings.FirstOrDefault((x)=>x.assetId.Equals(model.assetId));
        if(modelDB == null)
            return;
        if(modelDB.upgrades.Count<model.level)
            return;
        var upgrade = modelDB.upgrades[model.level];
        model.level++;
        Debug.Log("Upgrading "+ upgrade.key );
    }

}
