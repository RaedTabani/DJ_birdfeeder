using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

        ready = true;
        StartCoroutine(LoadNextScene());   
    }

    // Update is called once per frame
    void Update()
    {
        
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