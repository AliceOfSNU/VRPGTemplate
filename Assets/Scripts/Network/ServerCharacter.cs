using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ServerCharacter : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inside Server Start");
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Debug.Log("Inside Server Spawn");
    }

    private void OnDisable()
    {
        Debug.Log("Inside Server Disable");
    }

}
