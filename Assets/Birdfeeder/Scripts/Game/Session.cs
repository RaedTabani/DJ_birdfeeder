using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Events;


using Newtonsoft.Json;
public class Session : MonoBehaviour
{
    public static Session Instance;
    public SessionEvents events = new SessionEvents();

    public TextAsset tempConfig;
    public TextAsset playerConfig;
    public ConfigModel config;
    public PlayerModel player;

    public bool ready = false;
    void Awake(){
        if(Instance != null && Instance !=this)
            Destroy(gameObject);
        Instance = this;
    }
    void Start()
    {
        GetConfig();
        GetPlayer();
        ready = true;
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetConfig(){
        config = JsonConvert.DeserializeObject<ConfigModel>(tempConfig.text);
    }
    private void GetPlayer(){
        player  = JsonConvert.DeserializeObject<PlayerModel>(playerConfig.text);
    }


}

public class SessionEvents{
    public UnityEvent onSplashReady = new UnityEvent();
    public UnityEvent onSceneReady = new UnityEvent();
}