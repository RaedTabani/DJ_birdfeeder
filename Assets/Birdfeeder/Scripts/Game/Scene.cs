using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using UnityEngine;

public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        await LoadLevel();
        Session.Instance.events.onSceneReady.Invoke();
    }

    private async Task LoadLevel(){
        int count =0;
        Session.Instance.player.buildings.ForEach(async (x)=>{
            var prefab = await Prefabs.GetAddressable<GameObject>(x.assetId);
            Building building = Instantiate(prefab,new Vector3(x.coord.x,x.coord.y,x.coord.z),Quaternion.identity,transform).GetComponentInChildren<Building>();
            building.Setup(x);
            count++;
        });
        await Task.Run(async ()=>{
            while(count != Session.Instance.player.buildings.Count)
                await Task.Delay(25);
            return true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
