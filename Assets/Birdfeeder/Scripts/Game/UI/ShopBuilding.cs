using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ShopBuilding : MonoBehaviour
{
    private Transform popup;
    private Transform content;
    private Button show;
    private Button hide;

    void Start()
    {
        popup = transform.Find("Popup");
        content = popup.Find("Viewport/Content");
        show = transform.Find("Show").GetComponent<Button>();
        hide = popup.Find("Hide").GetComponent<Button>();

        show.onClick.AddListener(()=>Show());
        hide.onClick.AddListener(()=>Hide());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async Task<bool> Load(){
        foreach(Transform child in content)
            Destroy(child.gameObject);

        
        var ownedPrefab = await Prefabs.GetAddressable<GameObject>("OwnedBuildingUI");
        Session.Instance.player.buildings.ForEach((x)=>{
            BuildingUI item = Instantiate(ownedPrefab,content).GetComponent<BuildingUI>();
            item.Setup(x);
            item.buy.onClick.AddListener(()=>Upgrade(item.model));
        });
        var prefab = await Prefabs.GetAddressable<GameObject>("ToBeBuiltBuildingUI");
        List<BuildingModel> toBeBuilt = Session.Instance.config.buildings.Where((x)=>!Session.Instance.player.buildings.Any((y)=>y.assetId.Equals(x.assetId))).ToList();
        toBeBuilt.ForEach((x)=>{
            BuildingUI item = Instantiate(prefab,content).GetComponent<BuildingUI>();
            item.Setup(x);
            item.buy.onClick.AddListener(()=>Buy(item.model));
        });
        return true;
    }
    private void Upgrade(BuildingModel model){
        Debug.Log(model.assetId +" Upgraded");
        Session.Instance.events.onBuildingUpgrade.Invoke(model.assetId);
    }
    private async void Buy(BuildingModel model){
        var prefab = await Prefabs.GetAddressable<GameObject>(model.assetId);
        Building building = Instantiate(prefab,new Vector3(model.coord.x , model.coord.y-1 , model.coord.z ),Quaternion.identity).GetComponentInChildren<Building>();
        building.Setup(model);
        await TweenHelper.DoSlideY(building.transform.parent,model.coord.y,1);
    }
    public async void Show(){
        await Load();
        TweenHelper.DoPop(popup,Vector3.one,.5f);
    }
    public void Hide(){
        TweenHelper.DoPop(popup,Vector3.zero,.5f);
    }
}
