using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClientCharacter : MonoBehaviour
{
    [SerializeField]
    ClientCharacterVisual _visual;

    [SerializeField]
    NetState _netState;

    public Dictionary<Key, ActionType> ActionTypeByKey = new Dictionary<Key, ActionType>();
    private void Start()
    {
        // Initialize Action Keyboard Dictionary.
        foreach (var data in Datasource.Instance.ActionDataByType.Values)
        {
            ActionTypeByKey.Add(data.KeyboardBinding, data.ActionType);
        }
    }
    public void OnQ(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (!ActionTypeByKey.TryGetValue(Key.Q, out ActionType type)) return;
            _visual.PlayActionVisualization(type);
        }
        else if (value.canceled)
        {
            if (!ActionTypeByKey.TryGetValue(Key.Q, out ActionType type)) return;
            _visual.CancelActionVisualization(type);
        }
    }
}
