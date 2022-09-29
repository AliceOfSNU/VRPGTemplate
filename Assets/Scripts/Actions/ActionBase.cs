using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase
{
    public ActionData Data;

    //CTOR
    public ActionBase(ref ActionData data)
    {
        Data = data;
    }

    //--------- Lifecycle -----------//
    public abstract void Start();

    public abstract bool Update();

    public abstract void Cancel();

    public abstract void End();
}
