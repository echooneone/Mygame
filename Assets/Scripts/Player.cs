using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float inputX;
    public float inputZ;
    public float speed = 5f;
    public Camera viewCamera;
    Vector3 curSpeed;
    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        turnToMouse();
        
    }
    private void FixedUpdate()
    {
        input();
        beforeMove();
        Move();
    }
    void beforeMove()
    {
        curSpeed.x = speed * inputX;
        curSpeed.z = speed * inputZ;
        newPosition.x = curSpeed.x * Time.deltaTime;
        newPosition.z = curSpeed.z * Time.deltaTime;
    }
    void Move()
    {
        this.transform.Translate(newPosition, Space.World);
    }
    void input()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }
    void turnToMouse()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up,Vector3.zero);//以法线、点创建平面，面高为枪管高度
        float rayDistance=0.0f;
        if(groundPlane.Raycast(ray,out rayDistance))//使射线与平面相交。rayDistance设置为沿射线与平面相交的距离
        {
            Vector3 point = ray.GetPoint(rayDistance);//返回沿射线距离单位处的点。
                                                      // Debug.DrawLine(ray.origin,point, Color.red);
            Vector3 correctedPoint = new Vector3(point.x, this.transform.position.y, point.z);
           this.transform.LookAt(correctedPoint);
        }
    }
}
