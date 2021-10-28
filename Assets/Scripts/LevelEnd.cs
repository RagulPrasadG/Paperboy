using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LevelEnd : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera cam1;
    [SerializeField] CinemachineVirtualCamera cam2;
    private void Start()
    {
        cam1.Priority = 11;
        cam2.Priority = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cam1.Priority = 10;
            cam2.Priority = 11;
            GameManager.instance.GameOver();
        }
    }
    
}
