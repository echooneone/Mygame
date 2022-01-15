using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playerController))]
[RequireComponent(typeof(gunController))]
public class Player : MonoBehaviour
{
    public float moveSpeed=5f;
    Camera viewCamera;
    playerController controller;
    gunController gunController;
     void Start()
    {
        viewCamera = Camera.main;
        controller = GetComponent<playerController>();
        gunController = GetComponent<gunController>();
    }
     void Update()
    {
        MovementInput();
        TurnToMouse();
        WeaponInput();
        SwitchWeapon();
    }

    #region 移动输入
    void MovementInput()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        if (controller != null)
            controller.Move(moveVelocity);
    }
    #endregion

    #region 角色旋转视角
    void TurnToMouse()
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
    #endregion

    #region 武器输入 
    void WeaponInput()
    {
        if (Input.GetMouseButton(0)&&gunController!=null)
        {
            gunController.Shoot();
        }
    }
    #endregion

    #region 切换武器
    void SwitchWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            gunController.SwitchWeapon();
        }
    }
    #endregion
}
