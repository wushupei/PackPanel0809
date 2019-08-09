using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : MonoBehaviour
{
    [SerializeField]
    private InfoPanel infoPanel;
    [SerializeField]
    private EnemyController enemy;
    [SerializeField]
    private int enemyTotal;
    private void Start()
    {
        CreateEnemy();
    }
    private void CreateEnemy() //生成敌人
    {
        for (int i = 0; i < enemyTotal; i++)
        {
            //在一定范围内随机生成敌人
            transform.position = new Vector3(Random.Range(-50, 1), transform.position.y, Random.Range(35, 56));
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, 50))
            {
                Debug.DrawRay(transform.position, hit.point - transform.position, Color.red);
                if (hit.collider.tag == "Ground")
                    Instantiate(enemy, hit.point, Quaternion.identity).InitEnmey(infoPanel);
            }
        }
    }
}
