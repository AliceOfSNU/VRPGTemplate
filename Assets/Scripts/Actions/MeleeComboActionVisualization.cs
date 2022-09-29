using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeComboActionVisualization : ActionVisualization
{
    int _phase = 1;

    //CTOR
    public MeleeComboActionVisualization(ref ActionData data, ClientCharacterVisual visualParent) : base(ref data, visualParent)
    {
        Debug.Log("CTOR - Melee Combo");
    }

    public override void Start()
    {
        Debug.Log("Melee Combo Start!");
        _visual.Anim.SetTrigger(Data.Anim);
        TimeStarted = Time.time;

    }

    public override bool Update()
    {
        if (_bCanceled) return false;
        return true;
    }
    protected override void OnAnimEvent(string id)
    {
        // do switch logic, check input to see if we should enter next combo phase.
    }

    public override void End()
    {
        if (_bCanceled) return;
        Debug.Log("MeleeCombo Ended");
    }

    
    public override void Cancel()
    {
        Debug.Log("MeleeCombo Canceled");
        _bCanceled = true;
        _visual.Anim.SetTrigger("tCancelAction");
    }
}
