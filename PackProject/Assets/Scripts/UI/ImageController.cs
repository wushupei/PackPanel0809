using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ItemData data;
    Transform oriParent;
    Transform canvas;
    PackPanel packPanel;
    RectTransform viewport;
    Transform content;
    InfoPanel infoPanel;
    public void InitImage(ItemData _data, Transform _canvas, PackPanel _packPanel, RectTransform _viewport, Transform _content, InfoPanel _infoPanel) //图片初始化
    {
        data = _data; //获取数据
        name = data.name + Time.time; //设置名字

        canvas = _canvas;
        packPanel = _packPanel;
        viewport = _viewport;
        content = _content;
        infoPanel = _infoPanel;
    }
    public void OnBeginDrag(PointerEventData eventData) //开始拖拽
    {
        //记录原父物体，改变层级
        oriParent = transform.parent;
        transform.SetParent(canvas.transform);
        infoPanel.gameObject.SetActive(false);
    }
    public void OnDrag(PointerEventData eventData) //持续拖拽
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) //结束拖拽
    {
        OnScene();
        OnSolt();
    }
    private void OnScene() //放入场景
    {
        RectTransform vie = viewport;
        if (!vie.rect.Contains(Input.mousePosition - vie.position))
            packPanel.LoadModel(this);
    }
    public void OnSolt() //放入格子
    {
        for (int i = 0; i < content.childCount; i++)
        {
            RectTransform solt = content.GetChild(i).GetComponent<RectTransform>();

            if (solt.rect.Contains(Input.mousePosition - solt.position))
            {
                if (solt.childCount > 0)
                {
                    solt.GetChild(0).SetParent(oriParent);
                    oriParent.GetChild(0).localPosition = Vector3.zero;
                }

                transform.SetParent(solt);
                transform.localPosition = Vector3.zero;
                return;
            }
        }
        transform.SetParent(oriParent);
        transform.localPosition = Vector3.zero;
    }

    public void OnPointerEnter(PointerEventData eventData) //鼠标进入时调用
    {
        //启用信息面板
        if (!Input.GetMouseButton(0))
        {
            infoPanel.gameObject.SetActive(true);
            infoPanel.ShowInfo(data);
        }
        GetComponent<Outline>().enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)  //鼠标离开时调用
    {
        //禁用信息面板
        infoPanel.gameObject.SetActive(false);
        GetComponent<Outline>().enabled = false;
    }
}