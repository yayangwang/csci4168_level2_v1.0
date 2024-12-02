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
        // 获取立方体的边长
        float cubeSize = transform.localScale.x;
        //float angle = ConvertDirectionToAngle(direction);
        //Debug.Log("angle: " + angle);
        //Vector3 directionFromAngle = GetDirectionFromAngle(angle);
        //Debug.Log("directionFromAngle: " + directionFromAngle);

        // 立方体移动方向
        Vector3 detectionStart = transform.position;
        Vector3 detectionEnd = detectionStart + direction.normalized * cubeSize;

        // 使用Raycast检测前方是否有障碍物
        RaycastHit hit;
        if (Physics.Raycast(detectionStart, direction, out hit, cubeSize))
        {
            // 如果检测到障碍物，则输出信息并停止移动
            Debug.Log("检测到障碍物");
        }
        else
        {
            Debug.Log("direction: " + direction.normalized );
            // 没有障碍物，执行移动
            transform.position += direction.normalized * cubeSize;
        }
    }

    // 将传入的Vector3方向转换为一个角度
    public float ConvertDirectionToAngle(Vector3 direction)
    {
        // 仅考虑XZ平面的方向，忽略y轴
        Vector3 flatDirection = new Vector3(direction.x, 0, direction.z);

        // 使用Atan2计算与Z轴的角度（返回的是弧度）
        float angle = Mathf.Atan2(flatDirection.z, flatDirection.x) * Mathf.Rad2Deg;

        // 调整角度范围使其适应0-360度
        if (angle < 0)
        {
            angle += 360f;  // 将负角度转换为正角度
        }

        return angle;
    }

    // 将角度转换为最接近的方向
    private Vector3 GetDirectionFromAngle(float angle)
    {
        // 将角度映射到0, 90, 180, 270
        if ((angle >= 0f && angle < 45f) || (angle >= 315f && angle < 360f))
        {
            return Vector3.forward;  // 0度（前）
        }
        else if (angle >= 45f && angle < 135f)
        {
            return Vector3.right;    // 90度（右）
        }
        else if (angle >= 135f && angle < 225f)
        {
            return Vector3.back;     // 180度（后）
        }
        else
        {
            return Vector3.left;     // 270度（左）
        }
    }
    Vector3 GetClosestAxisDirection(Vector3 direction)
    {
        // 标准化输入向量（确保原始向量是单位向量）
        direction.Normalize();

        // 定义X轴和Z轴方向
        Vector3 xAxis = new Vector3(1, 0, 0);
        Vector3 zAxis = new Vector3(0, 0, 1);

        // 计算与X轴和Z轴的点积
        float dotWithXAxis = Vector3.Dot(direction, xAxis);
        float dotWithZAxis = Vector3.Dot(direction, zAxis);

        // 判断哪个点积的绝对值较大，确定最接近的轴
        if (Mathf.Abs(dotWithXAxis) > Mathf.Abs(dotWithZAxis))
        {
            // 与X轴更接近，选择正或负方向
            return dotWithXAxis > 0 ? xAxis : -xAxis; // 根据点积的符号选择方向
        }
        else
        {
            // 与Z轴更接近，选择正或负方向
            return dotWithZAxis > 0 ? zAxis : -zAxis; // 根据点积的符号选择方向
        }
    }
}
