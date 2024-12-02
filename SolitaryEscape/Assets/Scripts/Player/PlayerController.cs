using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // 移动速度
    public float moveSpeed = 5f;        
    //旋转速度
    public float roundSpeed = 50;

    // 射线检测的距离
    public float rayDistance = 1f; 

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // 水平移动
        float horizontal = Input.GetAxis("Horizontal");  
        float vertical = Input.GetAxis("Vertical");
        if(horizontal!= 0 || vertical!= 0)
        {
            Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
            animator.SetBool("isRun", true);
        }    
        else{
            animator.SetBool("isRun", false);
        }
        //旋转
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * roundSpeed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.E))
        {
            pushBox();
        }
    }

    public void pushBox()
    {
            // 获取玩家的前方方向
            Vector3 forwardDirection = transform.forward;

            // 从玩家位置向前发射射线
            Ray ray = new Ray(transform.position, forwardDirection);
            RaycastHit hit;

            // 射线检测
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // 检查射线是否击中
                if (hit.collider != null)
                {
                    BoxMove boxMove = hit.collider.GetComponent<BoxMove>();
                    if(boxMove!= null)
                    {
                        boxMove.Move(forwardDirection);
                    }
                }
            }
    }
}
