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
        List<BuildingModel> buildings = Session.Instance.config.buildings;
        GameObject prefab = await Prefabs.GetAddressable<GameObject>("BuildingUI");
        buildings.ForEach((x)=>{
            BuildingUI item = Instantiate(prefab,content).GetComponent<BuildingUI>();
            item.Setup(x);
            item.buy.onClick.AddListener(()=>Buy(item.model));
        });
        return true;
    }

    private void Buy(BuildingModel model){
        Debug.Log("Buying Building "+ model.assetId);
    }
    public async void Show(){
        await Load();
        TweenHelper.DoPop(popup,Vector3.one,.5f);
    }
    public void Hide(){
        TweenHelper.DoPop(popup,Vector3.zero,.5f);
    }
}
