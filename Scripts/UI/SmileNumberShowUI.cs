using UnityEngine;
using UnityEngine.UI;

public class SmileNumberShowUI : MonoBehaviour
{
    public Text textA;
    public Text textB;

    private ProcessManager processManager;

    private void Start()
    {
        processManager = GameObject.Find("ProcessManager").GetComponent<ProcessManager>();
    }

    private void Update()
    {
        if (processManager != null) 
        {
            textA.text = processManager.SmileValueA.ToString();
            textB.text = processManager.SmileValueB.ToString();
        }
    }
}
