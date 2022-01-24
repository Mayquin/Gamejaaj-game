using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float startWaitTime;
    [SerializeField] private Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;

    void Start()
    {
        RandomSpots();
    }

    private void Update()
    {
        MovimentMonster();
    }


    void MovimentMonster()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            RandomSpots();

            #region waitTime
            //if(waitTime <= 0)
            //{
            //   waitTime = startWaitTime;
            //}
            //else
            //{
            //    waitTime -= Time.deltaTime;
            //}
            #endregion
        }
    }

    void RandomSpots()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
    }
}
