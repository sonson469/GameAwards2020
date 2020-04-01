using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    public GameObject target;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //ターゲットの位置を目的地に設定する
        agent.destination = target.transform.position;
    }
}
