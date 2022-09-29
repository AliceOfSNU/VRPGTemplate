using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ServerCharacter : MonoBehaviour
{
    [SerializeField]
    NetState _netState;
    ActionPlayer _actionPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inside Server Start");
    }
    private void OnEnable()
    {
        Debug.Log("Inside Server Enable");

        _actionPlayer = new ActionPlayer(this);
        _netState.DoActionEventServer += OnDoActionEventServer;
    }
    private void OnDisable()
    {
        Debug.Log("Inside Server Disable");

        _actionPlayer = null;
        _netState.DoActionEventServer -= OnDoActionEventServer;
    }

    public void OnDoActionEventServer(ActionRequestData req)
    {
        Debug.Log("OnDoActionEventServer");
        PlayAction(ref req);
    }

    void Update()
    {
        _actionPlayer.Update();

    }
    public void PlayAction(ref ActionRequestData action)
    {
        Debug.Log("PlayActionServer");
        _actionPlayer.PlayAction(ref action);
    }

}
