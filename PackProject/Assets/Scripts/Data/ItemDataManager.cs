using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class ItemDataManager
{
    //单例模式
    private static ItemDataManager _Instance;
    public static ItemDataManager Instance
    {

        get
        {
            if (_Instance == null)
            {
                _Instance = new ItemDataManager();
                _Instance.InitItemData();
            }
            return _Instance;
        }
    }

    //读取表信息,将每条数据分别存入一个ItemData类中
    private Dictionary<int, ItemData> itemDatas = new Dictionary<int, ItemData>();

    private void InitItemData() //初始化表数据
    {
        JsonData allData = JsonMapper.ToObject(Resources.Load<TextAsset>("Data/ItemData").text);
        for (int i = 0; i < allData.Count; i++)
        {
            itemDatas.Add(int.Parse(allData[i]["ID"].ToString()), new ItemData(
                int.Parse(allData[i]["ID"].ToString()),
                int.Parse(allData[i]["Type"].ToString()),
                allData[i]["Name"].ToString(),
                float.Parse(allData[i]["Attack"].ToString()),
                float.Parse(allData[i]["Crit"].ToString()),
                float.Parse(allData[i]["Defense"].ToString()),
                float.Parse(allData[i]["Dodge"].ToString()),
                allData[i]["ModelPath"].ToString(),
                allData[i]["ImagePath"].ToString()
                ));
        }
    }

    //随机爆出一个装备
    public ModelController CreateModel(int randomID)
    {
        ItemData item = itemDatas[randomID];
        return Resources.Load<ModelController>(item.modelPath);
    }

    //根据Id获取数据
    public ItemData GetItemData(int id)
    {
        return itemDatas[id];
    }
}
