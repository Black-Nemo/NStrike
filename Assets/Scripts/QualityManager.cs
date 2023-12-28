using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (QualitySettings.GetQualityLevel() == 0)
            {
                QualitySettings.SetQualityLevel(2, applyExpensiveChanges: true);
            }
            else if (QualitySettings.GetQualityLevel() == 2)
            {
                QualitySettings.SetQualityLevel(0, applyExpensiveChanges: true);
            }

        }
    }
}
