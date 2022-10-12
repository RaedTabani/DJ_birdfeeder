using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public Image image;
    public Text _name;
    public Button buy;
    public Text cost;
    public Image status;

    public BuildingModel model;

    public async void Setup(BuildingModel model){
        this.model = model;
        //Sprite sprite = await Prefabs.GetAddressable<Sprite>(model.assetId);
        //image.sprite = sprite;
        cost.text = "BUY /n" + model.cost.ToString();
        if(true)
            return;
        buy.interactable = false;
        cost.text = "Unlock at "+ model.cost;
        status.enabled =true;
        Debug.Log("");
    }

}
