using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    MeleeCombo,
}


public class Datasource : MonoBehaviour
{
    private static Datasource _instance;
    public static Datasource Instance => _instance;
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        foreach(ActionData data in ActionDatas)
        {
            // copy to Dictionary
            ActionDataByType.Add(data.ActionType, data);
        }
    }
    public List<ActionData> ActionDatas = new List<ActionData>();
    public Dictionary<ActionType, ActionData> ActionDataByType = new Dictionary<ActionType, ActionData>();
}
