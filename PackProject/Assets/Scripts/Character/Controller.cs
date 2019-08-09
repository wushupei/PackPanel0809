using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Character chara;
    void Start()
    {
        chara = GetComponent<Character>();
    }
    void Update()
    {
        AnimatorStateInfo stateinfo = chara.anima.GetCurrentAnimatorStateInfo(0);
        //不在攻击动画时才能移动旋转
        if (!stateinfo.IsName("Attack"))
            chara.PlayerMove(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        else if (stateinfo.normalizedTime > 0.4f)
            chara.CheakTarget();

        if (Input.GetKeyDown(KeyCode.Space))
            chara.Attack();
        if (Input.GetKeyDown(KeyCode.E))
            chara.PickUp();
    }
}
