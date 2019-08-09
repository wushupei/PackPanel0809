using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 背包面板
/// </summary>
public class PackPanel : MonoBehaviour
{
    public Transform canvas;
    public RectTransform viewport;
    public InfoPanel infoPanel;
    public Dropdown dropdown;

    public void LoadImage(ModelController model) //加载图片
    {
        //根据类型选择Content
        Transform content = viewport.GetChild(model.data.type - 1);

        for (int i = 0; i < content.childCount; i++)
        {
            if (content.GetChild(i).childCount == 0)
            {
                Destroy(model.gameObject);
                ImageController image = Instantiate(Resources.Load<ImageController>(model.data.imagePath));
                image.InitImage(model.data, canvas, this, viewport, content, infoPanel);
                image.transform.SetParent(content.GetChild(i), false);
                image.transform.localPosition = Vector3.zero;
                return;
            }
        }
    }
    public void LoadModel(ImageController image) //加载模型
    {
        RaycastHit hit;
        Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.tag == "Ground")
            {
                Destroy(image.gameObject);
                Instantiate(Resources.Load<ModelController>(image.data.modelPath), hit.point, Quaternion.identity).InitModel(infoPanel, image.data);
            }
        }
    }

    public void StarPackPanel() //开关背包面板
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void SwitchContent() //切换背包
    {
        for (int i = 0; i < viewport.childCount; i++)
        {
            viewport.GetChild(i).gameObject.SetActive(false);
        }
        viewport.GetChild(dropdown.value).gameObject.SetActive(true);
    }

    public void ArrangeImage() //整理图片
    {
        for (int h = 0; h < viewport.childCount; h++)
        {
            for (int i = 0; i < viewport.GetChild(h).childCount; i++)
            {
                if (viewport.GetChild(h).GetChild(i).childCount == 0)
                {
                    for (int j = i + 1; j < viewport.GetChild(h).childCount; j++)
                    {
                        if (viewport.GetChild(h).GetChild(j).childCount > 0)
                        {
                            Transform image = viewport.GetChild(h).GetChild(j).GetChild(0);
                            image.SetParent(viewport.GetChild(h).GetChild(i));
                            image.localPosition = Vector3.zero;
                            break;
                        }
                    }
                }
            }
        }
    }
}
