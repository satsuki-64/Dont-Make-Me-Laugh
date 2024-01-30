using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour
{
    GameState NowState = GameState.Ready;
    public bool switchFlag = false;

    private GameObject processManager;
    private void Start()
    {
        processManager = GameObject.Find("ProcessManager");
        NowState = processManager.GetComponent<ProcessManager>().NowState;
    }

    private void Update()
    {
        NowState = processManager.GetComponent<ProcessManager>().NowState;
    }

    void OnTriggerEnter(Collider collider)
    {
        if ( NowState == GameState.Running )
        {
            if(collider.gameObject.name == "EndColliderIn")
            {
                switchFlag = true; 
            }
        }
    }
}
