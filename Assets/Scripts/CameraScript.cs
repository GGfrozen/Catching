using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private void Awake()
    {
        CameraScript[] cameraScripts = FindObjectsOfType<CameraScript>();
        if(cameraScripts.Length > 1)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
