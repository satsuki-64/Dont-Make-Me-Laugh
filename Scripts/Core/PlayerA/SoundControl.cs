using UnityEngine;

public enum PlayerAMoveState 
{ 
    NormalMove,
    ImpedeMove
}

[RequireComponent(typeof(Rigidbody))]
public partial class SoundControl : MonoBehaviour
{
    [Header("PlayerA在X轴的当前移动速度")]
    public float SpeedX = 100.0f;

    [Header("PlayerA在X轴上Normal和Impede移动速度")]
    public float SpeedXNormal;
    public float SpeedXImpede;

    [Header("音量大小")]
    public static float Volume = default;

    [Header("当前音量控制物体")]
    public GameObject PlayerA = null;

    [Header("重力大小")]
    public float gravity = 0.8f;

    [Header("Volume缩放大小")]
    public float volumeForceScale = 2f;

    [Header("最大音量限制")]
    public int maxVolume = 3;

    [Header("当前玩家A的移动状态")]
    public PlayerAMoveState CurrentPlayerMoveState = PlayerAMoveState.NormalMove;

    private Rigidbody rigidbody = null;
    private AudioClip micRecord = default;
    private string device = default;
    private const int sampleSize = 128;

    [SerializeField]
    private float[] samples = new float[sampleSize];

    private void Start()
    {
        //麦克风设备与音频初始化
        device = Microphone.devices[0];
        micRecord = Microphone.Start(device,true,999,44100);

        // 临时
        if (PlayerA == null) 
        {
            //获得音量控制对象
            PlayerA = GameObject.Find("PlayerA");
        }

        if (rigidbody == null)  
        {
            rigidbody = this.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        Volume = GetVolume();
        // Debug.Log("当前的音量为：" + Volume);

        // 根据玩家A状态，更改速度
        PlayerMoveStateControl(CurrentPlayerMoveState);

        //执行玩家A在X轴上位移
        XDirectionMove(PlayerA.transform);
        //XDirectionMove(rigidbody);

        //执行玩家A在Y轴上位移
        SoundControlMoveZ(Volume,rigidbody);
    }

    #region 音频模块
    private float GetVolume() 
    {
        int offset = Microphone.GetPosition(device) - sampleSize + 1;// -128 + 1
        if (offset < 0) 
        {
            Debug.LogWarning("音量采样失败！");
            return 0;
        }

        // 获得音频信息,存储在AudioClip当中
        micRecord.GetData(samples,offset);

        float levelMax = 0;
        for (int i = 0; i < sampleSize; ++i) 
        {
            float wavePeak = samples[i];
            if (levelMax < wavePeak)  
            {
                levelMax = wavePeak;
            }
        }

        return levelMax * 99;
    }

    #endregion

    #region 玩家A移动控制模块
    private void XDirectionMove(Transform playerATransform) 
    {
        float ForceNumber = SpeedX * Time.deltaTime;
        Vector3 forceVector = new Vector3(ForceNumber, 0, 0);
        playerATransform.Translate(forceVector);
    }

    //private void XDirectionMove(Rigidbody rb)
    //{
    //    float ForceNumber = SpeedX * Time.deltaTime;
    //    Vector3 forceVector = new Vector3(ForceNumber, 0, 0);
    //    rb.AddForce(forceVector, ForceMode.Force);
    //    //playerATransform.Translate(forceVector);
    //}

    private void SoundControlMoveZ(float volume, Rigidbody playerRb)
    {
        if (volume > maxVolume)
            volume = maxVolume;
        int intVolume = ((int)((int)volume / 3)) * 3;
        float totalForce = volume * volumeForceScale - gravity;
        Vector3 forceVector = new Vector3(0, totalForce, 0);
        playerRb.AddForce(forceVector, ForceMode.Force);
    }
    #endregion

    #region 玩家A移动状态控制模块
    private void PlayerMoveStateControl(PlayerAMoveState currentPlayerMoveState) 
    {
        if (currentPlayerMoveState == PlayerAMoveState.NormalMove) 
        {
            SpeedX = SpeedXNormal;
        }

        if (currentPlayerMoveState == PlayerAMoveState.ImpedeMove) 
        {
            SpeedX = SpeedXImpede;
        }
    }
    #endregion

    #region 废弃
    private float SpeedY = 100.0f;
    private float ForceScale = 1;

    private void ControlCube(float tempVolume, GameObject soundObject)
    {
        if (tempVolume > 0f)  
        {
            float y = tempVolume;

            float x = soundObject.transform.localScale.x;
            float z = soundObject.transform.localScale.z;

            soundObject.transform.localScale = new Vector3(x,y,z);
        }
    }

    private void YDirectionMove(Rigidbody rb)
    {
        float ForceNumber = SpeedY * Time.deltaTime;
        Vector3 forceVector = new Vector3(0, -ForceNumber, 0);
        rb.AddForce(forceVector, ForceMode.Force);
    }

    private void SoundControlMove(float volume, Rigidbody rb)
    {
        float ForceNumber = volume * Time.deltaTime * ForceScale;
        Vector3 forceVector = new Vector3(0, ForceNumber, 0);
        rb.AddForce(forceVector, ForceMode.Force);
    }
    #endregion
}
