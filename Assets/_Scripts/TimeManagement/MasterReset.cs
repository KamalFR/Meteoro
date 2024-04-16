using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterReset : MonoBehaviour
{
    
    void Start()
    {
        TimeManager.OnResetTimer?.Invoke();
        ScoreManager.OnResetScore?.Invoke();
    }

}
