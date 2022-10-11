using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

using Newtonsoft.Json;
public class Session : MonoBehaviour
{
    public static Session Instance;
    public SessionEvents events;

    public TextAsset tempConfig;
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
        Debug.Log(config.buildings.Count);
        ready = true;
        StartCoroutine(LoadNextScene());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetConfig(){
        config = JsonConvert.DeserializeObject<ConfigModel>(tempConfig.text);
    }

    private IEnumerator LoadNextScene(){
        AsyncOperation operation = SceneManager.LoadSceneAsync(1,LoadSceneMode.Single);
        while(!operation.isDone){
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}

public class SessionEvents{

}