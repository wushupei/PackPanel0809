using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public Text t0, t1, t2;
    public void ShowInfo(ItemData data) //显示信息
    {
        switch (data.type)
        {
            case 1:
                t0.text = data.name;
                t1.text = "攻击力: " + data.attack;
                t2.text = "暴击率: " + data.crit;
                break;
            case 2:
                t0.text = data.name;
                t1.text = "防御力: " + data.defense;
                t2.text = "闪避率: " + data.dodge;
                break;
        }
    }
}
