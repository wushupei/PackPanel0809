using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    InfoPanel infoPanel;
    Rigidbody rig;
    Animator anim;
    Transform player;
    Vector3 playerPos;
    AnimatorStateInfo stateinfo;
    bool isLife;
    public void InitEnmey(InfoPanel _infoPanel) //初始化敌人
    {
        infoPanel = _infoPanel;
        rig = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        player = FindObjectOfType<Character>().transform;
        isLife = true;
    }
    private void Update()
    {
        stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        playerPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        if (stateinfo.IsName("Idle"))
            transform.LookAt(playerPos);

        if (stateinfo.IsName("Fly") && stateinfo.normalizedTime > 1.0f && rig.IsSleeping())
        {
            Destroy(gameObject);
            CreateModel();
        }
    }
    public void Fly() //被击飞
    {
        if (isLife)
        {
            isLife = false;
            Vector3 flyDir = (transform.position - playerPos).normalized;
            rig.AddForce(flyDir * 10 + transform.up * 5, ForceMode.Impulse);
            anim.Play("Fly");
        }
    }
    private void CreateModel() //爆装备
    {
        int id = Random.Range(1001, 1006);
        ModelController model = Instantiate(ItemDataManager.Instance.CreateModel(id), transform.position, Quaternion.identity);
        model.InitModel(infoPanel, ItemDataManager.Instance.GetItemData(id));
    }
}
