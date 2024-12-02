using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public bool check;
    public Door door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(Vector3 direction)
    {
        direction = GetClosestAxisDirection(direction);
        Debug.Log("direction: " + direction);
        // ��ȡ������ı߳�
        float cubeSize = transform.localScale.x;
        //float angle = ConvertDirectionToAngle(direction);
        //Debug.Log("angle: " + angle);
        //Vector3 directionFromAngle = GetDirectionFromAngle(angle);
        //Debug.Log("directionFromAngle: " + directionFromAngle);

        // �������ƶ�����
        Vector3 detectionStart = transform.position;
        Vector3 detectionEnd = detectionStart + direction.normalized * cubeSize;

        // ʹ��Raycast���ǰ���Ƿ����ϰ���
        RaycastHit hit;
        if (Physics.Raycast(detectionStart, direction, out hit, cubeSize))
        {
            // �����⵽�ϰ���������Ϣ��ֹͣ�ƶ�
            Debug.Log("��⵽�ϰ���");
        }
        else
        {
            Debug.Log("direction: " + direction.normalized );
            // û���ϰ��ִ���ƶ�
            transform.position += direction.normalized * cubeSize;
        }
    }

    // �������Vector3����ת��Ϊһ���Ƕ�
    public float ConvertDirectionToAngle(Vector3 direction)
    {
        // ������XZƽ��ķ��򣬺���y��
        Vector3 flatDirection = new Vector3(direction.x, 0, direction.z);

        // ʹ��Atan2������Z��ĽǶȣ����ص��ǻ��ȣ�
        float angle = Mathf.Atan2(flatDirection.z, flatDirection.x) * Mathf.Rad2Deg;

        // �����Ƕȷ�Χʹ����Ӧ0-360��
        if (angle < 0)
        {
            angle += 360f;  // �����Ƕ�ת��Ϊ���Ƕ�
        }

        return angle;
    }

    // ���Ƕ�ת��Ϊ��ӽ��ķ���
    private Vector3 GetDirectionFromAngle(float angle)
    {
        // ���Ƕ�ӳ�䵽0, 90, 180, 270
        if ((angle >= 0f && angle < 45f) || (angle >= 315f && angle < 360f))
        {
            return Vector3.forward;  // 0�ȣ�ǰ��
        }
        else if (angle >= 45f && angle < 135f)
        {
            return Vector3.right;    // 90�ȣ��ң�
        }
        else if (angle >= 135f && angle < 225f)
        {
            return Vector3.back;     // 180�ȣ���
        }
        else
        {
            return Vector3.left;     // 270�ȣ���
        }
    }
    Vector3 GetClosestAxisDirection(Vector3 direction)
    {
        // ��׼������������ȷ��ԭʼ�����ǵ�λ������
        direction.Normalize();

        // ����X���Z�᷽��
        Vector3 xAxis = new Vector3(1, 0, 0);
        Vector3 zAxis = new Vector3(0, 0, 1);

        // ������X���Z��ĵ��
        float dotWithXAxis = Vector3.Dot(direction, xAxis);
        float dotWithZAxis = Vector3.Dot(direction, zAxis);

        // �ж��ĸ�����ľ���ֵ�ϴ�ȷ����ӽ�����
        if (Mathf.Abs(dotWithXAxis) > Mathf.Abs(dotWithZAxis))
        {
            // ��X����ӽ���ѡ�����򸺷���
            return dotWithXAxis > 0 ? xAxis : -xAxis; // ���ݵ���ķ���ѡ����
        }
        else
        {
            // ��Z����ӽ���ѡ�����򸺷���
            return dotWithZAxis > 0 ? zAxis : -zAxis; // ���ݵ���ķ���ѡ����
        }
    }
}
