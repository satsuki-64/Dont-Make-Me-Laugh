using UnityEngine;

public class SmileCollect : MonoBehaviour
{
    private ProcessManager processManager;

    private int smileANumber = 1;

    //玩家A撞毁一个基础障碍物玩家B获得的分数
    private int smileBNumber = 2;

    private void Start()
    {
        processManager = GameObject.Find("ProcessManager").GetComponent<ProcessManager>();
    }

    private void Update()
    {
        smileANumber = processManager.AddSmileValueANumber;
        //如果这个量同样在processManager中定义
        //smileBNumber = processManager.AddSmileValueBNumber;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collections")
        {
            processManager.SmileValueA += smileANumber;
            Debug.Log(processManager.SmileValueA);
            GameObject.Destroy(other.gameObject);
        }

        //if (other.tag == "BasicBlock")
        //{
        //    processManager.SmileValueB += smileBNumber;
        //    GameObject.Destroy(other.gameObject);
        //}
    }
}