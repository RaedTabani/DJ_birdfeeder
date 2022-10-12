using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class OwnedBuildingUI : MonoBehaviour
{
    public Image image;
    public string description;
    private BuildingModel model;
    public void Setup(BuildingModel model){
        this.model = model;
    }
}
