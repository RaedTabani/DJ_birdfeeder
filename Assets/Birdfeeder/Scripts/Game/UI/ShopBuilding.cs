using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ShopBuilding : MonoBehaviour
{
    private Transform popup;
    private Button show;
    private Button hide;

    void Start()
    {
        popup = transform.Find("Popup");
        show = transform.Find("Show").GetComponent<Button>();
        hide = transform.Find("Hide").GetComponent<Button>();

        show.onClick.AddListener(()=>Show());
        hide.onClick.AddListener(()=>Hide());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show(){

    }
    public void Hide(){
        
    }
}
