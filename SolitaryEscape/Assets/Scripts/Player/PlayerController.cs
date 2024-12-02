using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // �ƶ��ٶ�
    public float moveSpeed = 5f;        
    //��ת�ٶ�
    public float roundSpeed = 50;

    // ���߼��ľ���
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

        // ˮƽ�ƶ�
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
        //��ת
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * roundSpeed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.E))
        {
            pushBox();
        }
    }

    public void pushBox()
    {
            // ��ȡ��ҵ�ǰ������
            Vector3 forwardDirection = transform.forward;

            // �����λ����ǰ��������
            Ray ray = new Ray(transform.position, forwardDirection);
            RaycastHit hit;

            // ���߼��
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // ��������Ƿ����
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
