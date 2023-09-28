using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
    void Awake()
    {
        CuttingCounter.ResetStaticData(); // Clears all the static listeners on the CuttingCounter
        BaseCounter.ResetStaticData();
        TrashCounter.ResetStaticData();
    }
}
