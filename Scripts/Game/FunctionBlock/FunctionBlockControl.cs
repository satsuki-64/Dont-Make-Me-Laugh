using UnityEngine;

public enum FunctionBlockType 
{
    EMPTY,
    ARROW,
    POWERBALL,
    PROPELLER,
    HEART
}

public partial class FunctionBlockControl : MonoBehaviour
{
    [Header("当前生成具有功能的Block的类型")]
    public FunctionBlockType FunctionBlockTypeInfo = FunctionBlockType.EMPTY;

    [Header("箭物体")]
    public GameObject Arrow;

    public float SpeedOfArrow = 1f;

    [Header("螺旋桨物体")]
    public GameObject Propeller;
    //旋转速度
    public float RotateSpeed = 6f;

    [Header("心脏物体")]
    public GameObject Heart;
    //最大形态直径
    public float MaxSizeRadius = 5f;
    //最小形态直径
    public float MinSizeRadius = 1f;
    //扩张速度
    public float SpreadSpeed = 1f;
    //收缩速度
    public float ShrinkSpeed = 6f;

    private float loopTime = 0f;

    private GameObject playerA;
    
    private void Start()
    {
        SpeedOfArrow = 1f;

        Propeller = this.gameObject;
        Heart = this.gameObject;
        Arrow = this.gameObject;

        RotateSpeed = 6f;
        playerA = GameObject.Find("PlayerA");
    }

    private void Update()
    {
        if (FunctionBlockTypeInfo != FunctionBlockType.EMPTY)  
        {
            FunctionBlockState(FunctionBlockTypeInfo);
        }   
    }

    private void FunctionBlockState(FunctionBlockType functionBlockType) 
    {
        switch (functionBlockType) 
        {
            case FunctionBlockType.ARROW:
                ArrowFun(Arrow);
                break;

            case FunctionBlockType.POWERBALL:
                
                break;
                
            case FunctionBlockType.PROPELLER:
                PropellerFun(Propeller);
                break;

            case FunctionBlockType.HEART:
                HeartFun(Heart);
                break;
        }
    }

    private void PropellerFun(GameObject Propeller)
    {
        Propeller.transform.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime, Space.World);
    }

    private void HeartFun(GameObject Heart)
    {
        //扩张的时间
        float frontTime = (MaxSizeRadius - MinSizeRadius) / SpreadSpeed;
        //收缩的时间
        float laterTime = (MaxSizeRadius - MinSizeRadius) / ShrinkSpeed;
        if (loopTime == 0f)
        {
            Heart.transform.localScale = new Vector3(MinSizeRadius, MinSizeRadius, MinSizeRadius);
            loopTime += Time.deltaTime;
        }
        if (loopTime > 0f && loopTime <= frontTime)
        {
            Heart.transform.localScale += new Vector3(SpreadSpeed * Time.deltaTime, SpreadSpeed * Time.deltaTime, SpreadSpeed * Time.deltaTime);
            loopTime += Time.deltaTime;
        }
        if (loopTime > frontTime && loopTime <= frontTime + laterTime)
        {
            Heart.transform.localScale -= new Vector3(ShrinkSpeed * Time.deltaTime, ShrinkSpeed * Time.deltaTime, ShrinkSpeed * Time.deltaTime);
            loopTime += Time.deltaTime;
        }
        if (loopTime >= frontTime + laterTime)
        {
            loopTime = 0f;
        }

    }

    private void ArrowFun(GameObject Arrow) 
    {
        Arrow.transform.LookAt(playerA.transform, new Vector3(0, 0, 1));
        Arrow.transform.Translate(Vector3.forward * Time.deltaTime * SpeedOfArrow, Space.Self);
    }
}
