using System.Collections;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    
    async void Start()
    {
        await Task.Run(async ()=>{
            while(!Session.Instance.ready)
                await Task.Delay(25);
            return true;
        });
        Session.Instance.events.onSplashReady.AddListener(()=>StartCoroutine(LoadNextScene()));
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
