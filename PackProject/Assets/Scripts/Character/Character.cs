using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed, rotateSpeed, downSpeed; //移动,转身,下落速度
    CharacterController cc;
    public Animator anima;
    public PackPanel packPanel;
    bool isAttack;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anima = GetComponentInChildren<Animator>();
    }
    public void PlayerMove(float x, float z) //移动
    {
        //移动方向
        Vector3 moveDir = new Vector3(x, 0, z).normalized;
        //面向移动方向
        if (x != 0 || z != 0)
        {
            Quaternion lookDir = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookDir, Time.deltaTime * rotateSpeed);
        }
        //移动方向为自身前方
        //moveDir = transform.forward * moveDir.magnitude;
        //朝移动方向移动
        cc.Move((moveDir * moveSpeed + Physics.gravity * downSpeed) * Time.deltaTime);
        //动画
        anima.SetBool("Move", x != 0 || z != 0);
    }
    public void Attack() //攻击
    {
        anima.Play("Attack");
        //攻击冷却完毕
        isAttack = true;
    }
    public void CheakTarget() //检测目标
    {
        if (isAttack)
        {
            //球型射线检测敌人
            Collider[] colliders = Physics.OverlapSphere(transform.position, 4);
            for (int i = 0; i < colliders.Length; i++)
            {
                EnemyController enemy = colliders[i].GetComponent<EnemyController>();
                if (enemy != null)
                {
                    //在前方120度位置的敌人受到攻击
                    Vector3 enemyDir = enemy.transform.position - transform.position;
                    if (Vector3.Angle(transform.forward, enemyDir) < 60)
                        enemy.Fly();
                }
            }
            isAttack = false; //不能攻击
        }
    }

    public void PickUp() //捡东西
    {
        //球型射线检测装备模型
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Model"))
            {
                packPanel.LoadImage(colliders[i].GetComponent<ModelController>());
                break;
            }
        }
    }
}
