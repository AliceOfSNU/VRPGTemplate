using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MovementState = ClientCharacterMovement.MovementState;

public class ClientCharacterVisual : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    public Animator Anim => _anim;
    private ActionVisualization _fxPlaying;


    private void Update()
    {


        //Visuals Update
        //Check if running time has ended.
        if (_fxPlaying != null)
        {
            bool bTimeOver = _fxPlaying.TimeRunning > _fxPlaying.Data.FxRunningTime;
            if (bTimeOver || !_fxPlaying.Update())
            {
                // we will end the action
                // by default, End will have no effect if _fx has been canceled.
                _fxPlaying.End();
                _fxPlaying = null;
            }

        }
    }
    public void PlayActionVisualization(ActionType type)
    {
        // cannot play a new action when one is already playing.
        if (_fxPlaying != null) return;
        ActionData data = Datasource.Instance.ActionDataByType[type];
        _fxPlaying = ActionVisualization.MakeActionVisualization(ref data, this);
        // Initialize
        _fxPlaying.Start();
    }

    public void CancelActionVisualization(ActionType type)
    {
        // cannot play a new action when one is already playing.
        if (_fxPlaying != null && _fxPlaying.Data.ActionType == type)
        {
            _fxPlaying.Cancel();
        }
    }

    public void OnMovementStateEntered(MovementState state)
    {
        switch (state)
        {
            case MovementState.Idle:
                _anim.SetBool("bWalk", false);
                break;

            case MovementState.Walking:
                _anim.SetBool("bWalk", true);
                break;

            case MovementState.Jump:
                _anim.SetTrigger("tJump");
                break;

            case MovementState.Landing:
                _anim.SetTrigger("tLand");
                break;
        }
    }
}
