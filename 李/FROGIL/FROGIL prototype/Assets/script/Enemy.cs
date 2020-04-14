using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    public GameObject target;
    public string tagname;
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == tagname)
        {
            agent.speed = 0.0f;
            agent.angularSpeed = 0.0f;
            Invoke("Release", 8.0f);
        }
    }

    void Release()
    {
        agent.speed = 0.5f;
        agent.angularSpeed = 120.0f;
    }
}
