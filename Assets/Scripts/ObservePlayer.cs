using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservePlayer : MonoBehaviour
{
    Transform targer;
    new Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        targer = GameObject.FindWithTag("Player").transform;
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
           transform.LookAt(targer);
    }
}
