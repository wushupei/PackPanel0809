using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 储存单个数据的所有信息
/// </summary>
public class ItemData
{
    public int id { get; }            //ID
    public int type { get; }          //类型
    public string name { get; }       //名字
    public float attack { get; }      //攻击力
    public float crit { get; }        //暴击率
    public float defense { get; }     //防御
    public float dodge { get; }       //闪避
    public string modelPath { get; }  //模型加载路径
    public string imagePath { get; }  //图片加载路径

    public ItemData(int _id, int _type, string _name, float _attack, float _crit, float _defense, float _dodge, string _modelPath, string _imagePath)
    {
        id = _id;
        type = _type;
        name = _name;
        attack = _attack;
        crit = _crit;
        defense = _defense;
        dodge = _dodge;
        modelPath = _modelPath;
        imagePath = _imagePath;
    }
}
