using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] int points = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fall"))
        {
            LevelManager.Instance.ChangeLifesCount();
        }
        else
        {
            LevelManager.Instance.ChangeScore(points);
        }
        
        Destroy(gameObject);
    }
   
}
