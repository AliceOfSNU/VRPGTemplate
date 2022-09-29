using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeComboAction: Action
{
    public MeleeComboAction(ref ActionData data, ServerCharacter character): base(ref data, character)
    {
        Debug.Log("Constructed MeleeComboAction");
    }

    public override void Cancel()
    {
        Debug.Log("Canceled MeleeComboAction");

    }

    public override void End()
    {
        Debug.Log("Ended MeleeComboAction");
    }


    public override void Start()
    {
        Debug.Log("Inside MeleeComboAction - start");
    }

    public override bool Update()
    {
        return false;
    }
}
