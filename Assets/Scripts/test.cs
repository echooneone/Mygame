using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class test : MonoBehaviour
{

    public Transform tar;
    private void Start()
    {
        


    }

    private void Update()
    {
        Debug.DrawLine(Vector3.zero, tar.forward, Color.black);
        Debug.DrawLine(Vector3.zero, tar.right, Color.red);
        Debug.DrawLine(Vector3.zero, tar.up, Color.green);
        if(Input.GetMouseButtonDown(0))
            print(Quaternion.LookRotation(tar.position));
    }

}



