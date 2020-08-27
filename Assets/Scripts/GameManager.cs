using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("EnemySettings")]
    [SerializeField] GameObject[] enemys;

    [Header("CreateSettings")]
    [SerializeField] Transform[] createPoints;
    [SerializeField] float createTime = 1f;
    [SerializeField] float changeCreateTimeRate = 0.9f;
    [SerializeField] float changeCreateTimeDelay = 10f;

    [Header("PickUp")]
    [SerializeField] GameObject[] pickUps;
    [SerializeField] int pickUpCoeff = 3;
    [SerializeField] float pickUpCreateTime = 5f;

    private bool isAlive;

    private void Start()
    {
        isAlive = true;
        StartCoroutine(nameof(CreateEnemys));
        StartCoroutine(ChangeCreateTime(changeCreateTimeRate, changeCreateTimeDelay));
        StartCoroutine(CreatePickUp(pickUpCreateTime));
    }
   
    private IEnumerator CreateEnemys()
    {
        while(isAlive)
        {
            int enemyIndex = Random.Range(0, enemys.Length - 1);
            int positionIndex = Random.Range(0, createPoints.Length - 1);
            yield return new WaitForSeconds(createTime);
            Instantiate(enemys[enemyIndex], createPoints[positionIndex].transform.position, Quaternion.identity);

        }
    }
    private IEnumerator ChangeCreateTime(float rate,float delay)
    {
        yield return new WaitForSeconds(delay); 
        while(isAlive)
        {
            createTime *= rate;
            yield return new WaitForSeconds(delay);
        }
    }
    private IEnumerator CreatePickUp(float rate)
    {        
        while (isAlive)
        {
            int createChance = Random.Range(0, 10);
            int pickUpIndex = Random.Range(0, pickUps.Length - 1);
            int positionIndex = Random.Range(0, createPoints.Length - 1);
            yield return new WaitForSeconds(rate);
            if(createChance<pickUpCoeff)
            {
                Instantiate(pickUps[pickUpIndex], createPoints[positionIndex].transform.position, Quaternion.identity);
            }
        }
    }

}
