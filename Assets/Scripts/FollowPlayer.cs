using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 2;
    public float scrollSpeed = 50f;
    Transform target;
    Vector3 offset;
    Vector3 curPos;
    float curFieldOfView;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").gameObject.transform;
        offset = target.position - transform.position;
        curFieldOfView = Camera.main.fieldOfView;
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {
        curPos = target.position - offset;
        transform.position = Vector3.Lerp(transform.position, curPos, speed * Time.deltaTime);
        Quaternion angel = Quaternion.LookRotation(target.position - transform.position);//获取旋转角度
        transform.rotation = Quaternion.Slerp(transform.rotation, angel, speed * Time.deltaTime);
    }
    private void Update()
    {
        if(!(Input.GetAxis("Mouse ScrollWheel")==0))
        {
            curFieldOfView += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
        if (curFieldOfView > 75)
            curFieldOfView = 75;
        if (curFieldOfView < 30)
            curFieldOfView = 30;
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, curFieldOfView, speed * Time.deltaTime);
   
    }
}
