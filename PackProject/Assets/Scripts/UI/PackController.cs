using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 背包拖动控制类
/// </summary>
public class PackController : MonoBehaviour, IDragHandler
{
    Transform parent; //背包面板
    private void Start()
    {
        parent = transform.parent;
    }
    //拖拽时背包面板跟随鼠标移动
    public void OnDrag(PointerEventData eventData)
    {
        parent.position = eventData.position;
    }
}
