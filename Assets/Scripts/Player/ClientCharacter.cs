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

            // draft a request
            ActionRequestData request = new ActionRequestData();
            request.ActionTypeEnum = ActionType.MeleeCombo;
            request.CancelMovement = true;
            request.Amount = 100;

            // do it!
            _netState.DoActionServerRPC(request);
        }
        else if (value.canceled)
        {
            if (!ActionTypeByKey.TryGetValue(Key.Q, out ActionType type)) return;
            _visual.CancelActionVisualization(type);
        }
    }
}
