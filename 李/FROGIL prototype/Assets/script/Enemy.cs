using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public string tagname;

    static public int EnemyBump;
    static public int EnemyBumpScore;

    // Start is called before the first frame update
    void Start()
    {
        EnemyBump = 0;
        EnemyBumpScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyBumpScore = EnemyBump * 30;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagname)
        {
            EnemyBump++;
        }
    }

    public static int GetEnemyScore()
    {
        return EnemyBump;
    }
    public static int GetEnemyScore2()
    {
        return EnemyBumpScore;
    }

}
