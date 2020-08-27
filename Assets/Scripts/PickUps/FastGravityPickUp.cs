using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastGravityPickUp : MonoBehaviour
{
    [SerializeField] float scaleDelay = 10f;
    [SerializeField] float changedGravity = -5.81f;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.GravityChange(scaleDelay, changedGravity);
        }
        Destroy(gameObject);
    }
   
}
