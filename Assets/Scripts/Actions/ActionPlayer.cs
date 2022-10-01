using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer
{
    private ServerCharacter _serverCharacter;
    public Action CurrentAction;
    public ActionPlayer(ServerCharacter serverCharacter)
    {
        _serverCharacter = serverCharacter;
    }
    
    public void PlayAction(ref ActionRequestData req)
    {
        switch (req.ActionTypeEnum)
        {
            case ActionType.MeleeCombo:
                Debug.Log("[ActionPlayer] Will start a " + req.ActionTypeEnum + " action");
                if(Datasource.Instance.ActionDataByType.TryGetValue(ActionType.MeleeCombo, out var data))
                {
                    CurrentAction = new MeleeComboAction(ref data, _serverCharacter);
                }
                break;
        }

        CurrentAction.Start();
    }

    public void Update()
    {
        if (CurrentAction != null)
        {
            if (!CurrentAction.Update())
            {
                // we will end the action
                // by default, End will have no effect if _fx has been canceled.
                CurrentAction.End();
                CurrentAction = null;
            }
        }
    }
    
}
