using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLifePickUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.AddLife();
        }
        Destroy(gameObject);
    }
}
