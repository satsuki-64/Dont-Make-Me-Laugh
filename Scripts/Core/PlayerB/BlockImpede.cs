using UnityEngine;

public class BlockImpede : MonoBehaviour
{
    private GameObject playerA;
    private SoundControl soundControl;
    private ProcessManager processManager;

    [SerializeField]
    private float timeRecord = 0;

    private float timeNumber = 1;
    private int smileBNumber = 1;

    private void Start()
    {
        if (playerA == null) 
        {
            playerA = GameObject.Find("PlayerA");
        }

        if (soundControl == null) 
        {
            soundControl = playerA.GetComponent<SoundControl>();
        }

        if (processManager == null) 
        {
            processManager = GameObject.Find("ProcessManager").GetComponent<ProcessManager>();
        }
    }

    private void Update()
    {
        if (processManager != null)  
        {
            // 时间间隔
            timeNumber = processManager.AddSmileTimeNumber;
            smileBNumber = processManager.AddSmilesValueBNumber;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("玩家A进入" + this.gameObject.name + "Block当中");

        if (other.tag == "Player") 
        {
            timeRecord += Time.deltaTime;

            if (soundControl.CurrentPlayerMoveState == PlayerAMoveState.NormalMove) 
            {
                soundControl.CurrentPlayerMoveState = PlayerAMoveState.ImpedeMove;
            }

            if (timeRecord >= timeNumber)  
            {
                processManager.SmileValueB += smileBNumber;
                timeRecord = 0;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("玩家A离开" + this.gameObject.name + "Block");

        if (other.tag == "Player") 
        {
            timeRecord = 0;

            if (soundControl.CurrentPlayerMoveState == PlayerAMoveState.ImpedeMove) 
            {
                soundControl.CurrentPlayerMoveState = PlayerAMoveState.NormalMove;    
            }
        }

    }
}
