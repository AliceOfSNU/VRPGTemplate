using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "GameData/ActionData", order = 1)]
public class ActionData : ScriptableObject
{
    public ActionType ActionType;

    public string Anim;
    public string Anim2;
    public string AnimVar;
    public string AnimVar2;

    public Key KeyboardBinding;
    public float FxRunningTime;
}
