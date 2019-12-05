using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsScript : MonoBehaviour
{
    public void Levels(bool startLevel1, bool endLevel1, bool startLevel2, bool endLevel2)
    {
        Analytics.CustomEvent("LevelProgression", new Dictionary<string, object>
        {
            { "Start1", startLevel1 },
            { "End1", endLevel1 },
            { "Start2", startLevel2 },
            { "End2", endLevel2 }
        });
    }
}

