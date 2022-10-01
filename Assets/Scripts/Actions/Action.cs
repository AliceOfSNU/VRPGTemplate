using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ActionBase
{
    ServerCharacter _serverCharacter;
    //CTOR
    public Action(ref ActionData data, ServerCharacter characterParent) : base(ref data)
    {
        Data = data;
        _serverCharacter = characterParent;
    }


}
