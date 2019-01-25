using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro; //Text mesh Pro
using UnityEngine;

public class UI_Engine : MonoBehaviour
{

    public TextMeshProUGUI InteractionText;
    [HideInInspector]
    public bool check;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterDeathShop(string name)
    {
        if(check)
        {
            Debug.Log("true");
            InteractionText.text = name;

        }
    }
}
