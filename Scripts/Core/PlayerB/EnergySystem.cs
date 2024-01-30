using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    [Header("能量恢复间隔")]
    public float EnergyGrowTime = 1.0f;

    [Header("单次能量恢复数值")]
    public int EnergyGrowNumber = 1;

    [Header("五种功能块的能量消耗值")]
    public int BasicBlock1_Energy = 1;
    public int BasicBlock2_Energy = 1;
    public int BasicBlock3_Energy = 1;
    public int BasicBlock4_Energy = 1;
    public int BasicBlock5_Energy = 1;

    [Header("当前能量值")]
    [SerializeField]
    private int energyNumber = 0;

    public int EnergyNumber 
    {
        get 
        {
            return energyNumber;
        }
        set 
        {
            if (value >= 10)
            {
                energyNumber = 10;
            }
            else 
            {
                energyNumber = value;
            }
        }
    }

    private float timeRecord = 0;

    private void Update()
    {
        EnergyGrow();
    }

    private void EnergyGrow() 
    {
        timeRecord += Time.deltaTime;

        if (timeRecord >= EnergyGrowTime) 
        {
            timeRecord = 0;
            this.EnergyNumber += EnergyGrowNumber;
        }
    }
}
