using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    //只计算 X and Z 轴
    Vector3 orgPosition; //怪物出生的原点
    
    float moveRid = 100; //怪物的追踪半径
    float rangeOfVisiable = 50;//怪物的视力
    NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
        orgPosition = this.transform.position;
    }

    void setOrgPosition(Vector3 position)
    {
        orgPosition = position;
    }
    void Update ()
    {
        float curDis = (player.position - this.transform.position).sqrMagnitude; //（实时）怪物和玩家的距离
        float disFromOrg = (player.position - orgPosition).sqrMagnitude; //（出生点）怪物和玩家的距离
        if (disFromOrg > moveRid || curDis > rangeOfVisiable)
        {
            nav.SetDestination(orgPosition);
            return;
        }
        nav.SetDestination(player.position);
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        //nav.SetDestination (player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
