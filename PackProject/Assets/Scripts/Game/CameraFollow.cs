using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 摄像机跟随
/// </summary>
public class CameraFollow : MonoBehaviour
{
    Transform playerTF;
    Vector3 fixedPos; //固定位置
    public float speed; //跟随速度
    void Start()
    {
        playerTF = GameObject.Find("Player").transform;
        fixedPos = transform.position - playerTF.position;
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTF.position + fixedPos, Time.deltaTime * speed);
    }
}
