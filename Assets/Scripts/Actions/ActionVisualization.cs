using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionVisualization : ActionBase
{
    protected ClientCharacterVisual _visual;

    public float TimeStarted = 0.0f;
    public float TimeRunning { get { return (Time.time - TimeStarted); } }
    public static ActionVisualization MakeActionVisualization(ref ActionData data, ClientCharacterVisual parent)
    {
        switch (data.ActionType)
        {
            case ActionType.MeleeCombo: return new MeleeComboActionVisualization(ref data, parent);
        }
        // invalid action type
        throw new System.Exception();
    }

    //------- Lifecycle --------//



    public bool _bCanceled = false;


    //CTOR
    public ActionVisualization(ref ActionData data, ClientCharacterVisual visualParent): base(ref data)
    {
        _visual = visualParent;
    }

    protected virtual void OnAnimEvent(string id)
    {
        Debug.Log("Animation Event: " + id);
    } 


}
