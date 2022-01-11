using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learntest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(10f, 10f, 100f, 100f), "test");
        if (GUI.Button(new Rect(10f, 120f, 100f, 50f), "Button"))
        {
            //按钮点击事件
            Debug.Log(Screen.width);
        }
    }
}
