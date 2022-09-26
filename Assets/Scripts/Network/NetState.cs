using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Networking.Transport;
using UnityEngine;

public class NetState : NetworkBehaviour
{

    public ClientCharacterMovement ClientCharacter;
    public ServerCharacter ServerCharacter;
    private void Awake()
    {

        if (NetworkManager.IsServer && !NetworkManager.IsHost) ServerCharacter.enabled = true;
        if (NetworkManager.IsClient || NetworkManager.IsHost) ClientCharacter.enabled = true;
    }
}
