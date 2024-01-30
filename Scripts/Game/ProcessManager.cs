using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    Ready,
    Running,
    Ending,
    PlayerAWin,
    PlayerBWin,
    AllWin
}

public class ProcessManager : MonoBehaviour
{
    public int SmileValueA;
    public int SmileValueB;

    [Header("玩家A采集笑脸所获得值")]
    public int AddSmileValueANumber = 1;

    [Header("玩家B每次收获笑脸值")]
    public int AddSmilesValueBNumber = 1;

    [Header("玩家A在Block中时，每隔多少时间收获笑脸值")]
    public float AddSmileTimeNumber = 1;

    public GameState NowState = GameState.Ready;
    
    public GameObject EndTriggerBox = null;

    private bool endFlag = false;

    [SerializeField]
    private GameObject RedUI;

    [SerializeField]
    private GameObject BlueUI;

    [SerializeField]
    private Image RedUIImage = null;

    [SerializeField]
    private Image BlueUIImage = null;

    public GameObject PlayerAWinUI = null;
    public GameObject PlayerBWinUI = null;

    public GameObject PlayUIWinUI = null;
    
    private void Start()
    {
        NowState = GameState.Running;
        EndTriggerBox = GameObject.Find("EndCollider");

        RedUI = GameObject.Find("RedValueImageUI");
        BlueUI = GameObject.Find("BlueValueImageUI");

        RedUIImage = RedUI.GetComponent<Image>();
        BlueUIImage = BlueUI.GetComponent<Image>();

        PlayerAWinUI.SetActive(false);
        PlayerBWinUI.SetActive(false);
        PlayUIWinUI.SetActive(true);
    }

    private void Update()
    {
        endFlag = EndTriggerBox.GetComponent<EndCollider>().switchFlag;

        if (endFlag)
        {
            NowState = GameState.Ending;
        }

        if (NowState == GameState.Ending)
        {
            if (SmileValueA > SmileValueB)
            {
                NowState = GameState.PlayerAWin;
            }
            else if (SmileValueA < SmileValueB)
            {
                NowState = GameState.PlayerBWin;
            }
            else
            {
                NowState = GameState.AllWin;
            }
        }

        RedUIImage.fillAmount = SmileValueA / (float)(25);
        Debug.Log("RedFillAmout" + SmileValueA / (float)(25));
        BlueUIImage.fillAmount = SmileValueB / (float)(25);

        if (NowState == GameState.PlayerAWin) 
        {
            PlayUIWinUI.SetActive(false);
            PlayerAWinUI.SetActive(true);
        }

        if (NowState == GameState.PlayerBWin) 
        {
            PlayUIWinUI.SetActive(false);
            PlayerBWinUI.SetActive(true);
        }
    }

    public void BackToEnterScene() 
    {
        SceneManager.LoadScene(0);
    }

    public void BackToScene1() 
    {
        SceneManager.LoadScene(1);
    }
}
