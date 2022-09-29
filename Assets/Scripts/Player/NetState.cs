using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Networking.Transport;
using UnityEngine;

public class NetState : NetworkBehaviour
{

    public ClientCharacterMovement ClientCharacter;
    public ServerCharacter ServerCharacter;
    private void Start()
    {
        if (NetworkManager.IsServer || NetworkManager.IsHost) ServerCharacter.enabled = true;
        if (NetworkManager.IsClient || NetworkManager.IsHost) ClientCharacter.enabled = true;
    }


    /* ----------------------
     * Start Action events
     -----------------------*/
    public event Action<ActionRequestData> DoActionEventServer;
    public event Action<ActionRequestData> DoActionEventClient;

    [ServerRpc]
    public void DoActionServerRPC(ActionRequestData data)
    {
        Debug.Log("received data:" + data.ToString());
        DoActionEventServer?.Invoke(data);
    }

    [ClientRpc]
    public void DoActionClientRPC(ActionRequestData data)
    {
        DoActionEventClient?.Invoke(data);
    }

    /* ----------------------
     * Cancellation events
     -----------------------*/
    public event Action<ActionType> CancelActionsByTypeEventClient;
    public event Action<ActionType> CancelActionsByTypeEventServer;

    [ClientRpc]
    public void CancelActionsByTypeClientRpc(ActionType action)
    {
        CancelActionsByTypeEventClient?.Invoke(action);
    }

    [ServerRpc]
    public void CancelActionByTypeServerRpc(ActionType action)
    {
        CancelActionsByTypeEventServer?.Invoke(action);
    }

}
