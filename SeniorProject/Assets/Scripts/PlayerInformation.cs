using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public static PlayerInformation Instance;

    public bool PlayerReadCheckEngine = false;
    public bool PlayerReadCheckABS = false;
    public bool PlayerReadCheckBrakePads = false;
    public bool PlayerReadCheckBattery = false;
    public bool PlayerReadCheckOilPressure = false;
    public bool PlayerReadCheckTirePressure = false;

    public bool MultChoiceTestCompleted = false;

    public bool CarPartTestCompleted = false;

    private void Awake()
    {
        if(Instance == null || Instance == this)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool IsModuleCheckDone()
    {
        return (PlayerReadCheckEngine && PlayerReadCheckABS && PlayerReadCheckBrakePads && PlayerReadCheckBattery && PlayerReadCheckOilPressure && PlayerReadCheckTirePressure);
    }

    public bool IsMultChoiseDone()
    {
        return MultChoiceTestCompleted;
    }

    public bool IsCarTestCompleted()
    {
        return CarPartTestCompleted;
    }
}
