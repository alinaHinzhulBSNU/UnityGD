using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsComponent : MonoBehaviour
{
    public static void OnCharacterDead(int level, string name)
    {
        Analytics.CustomEvent("Character Dead", 
            new Dictionary<string, object>()
            {
                { "Level", level},
                { "Character", name}
            });
    }
}