using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    InfoPanel infoPanel;
    public ItemData data;
    Character chara;
    public void InitModel(InfoPanel _infoPanel, ItemData _data)
    {
        infoPanel = _infoPanel;
        data = _data; //获取数据
        name = data.name + Time.time; //设置名字  

        chara = FindObjectOfType<Character>();

        //print(data.id);
        //print(data.type);
        //print(data.name);
        //print(data.attack);
        //print(data.crit);
        //print(data.defense);
        //print(data.dodge);
        //print(data.modelPath);
        //print(data.imagePath);
    }
    private void OnMouseEnter()  //鼠标进入时调用
    {
        //显示信息面板
        infoPanel.gameObject.SetActive(true);
        infoPanel.ShowInfo(data);
    }
    private void OnMouseExit()  //鼠标离开时调用
    {
        infoPanel.gameObject.SetActive(false);
    }
}
