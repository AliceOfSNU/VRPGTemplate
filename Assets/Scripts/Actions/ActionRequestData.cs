using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public struct ActionRequestData : INetworkSerializable
{
    public ActionType ActionTypeEnum;      //the action to play.
    public Vector3 Position;           //center position of skill, e.g. "ground zero" of a fireball skill.
    public Vector3 Direction;          //direction of skill, if not inferrable from the character's current facing.
    public ulong[] TargetIds;          //NetworkObjectIds of targets, or null if untargeted.
    public float Amount;               //can mean different things depending on the Action. For a ChaseAction, it will be target range the ChaseAction is trying to achieve.
    public bool ShouldQueue;           //if true, this action should queue. If false, it should clear all current actions and play immediately.
    public bool ShouldClose;           //if true, the server should synthesize a ChaseAction to close to within range of the target before playing the Action. Ignored for untargeted actions.
    public bool CancelMovement;        // if true, movement is cancelled before playing this action


    private enum PackFlags
    {
        None = 0,
        HasPosition = 1,
        HasDirection = 1 << 1,
        HasAmount = 1 << 2,
        CancelMovement = 1 << 3,
        //currently serialized with a byte. Change Read/Write if you add more than 8 fields.
    }

    /// <summary>
    /// Returns true if the ActionRequestDatas are "functionally equivalent" (not including their Queueing or Closing properties).
    /// </summary>
    public bool Compare(ref ActionRequestData rhs)
    {
        bool scalarParamsEqual = (ActionTypeEnum, Position, Direction, Amount) == (rhs.ActionTypeEnum, rhs.Position, rhs.Direction, rhs.Amount);
        if (!scalarParamsEqual) { return false; }


        return true;
    }


    private PackFlags GetPackFlags()
    {
        PackFlags flags = PackFlags.None;
        if (Position != Vector3.zero) { flags |= PackFlags.HasPosition; }
        if (Direction != Vector3.zero) { flags |= PackFlags.HasDirection; }
        if (Amount != 0) { flags |= PackFlags.HasAmount; }
        if (CancelMovement) { flags |= PackFlags.CancelMovement; }


        return flags;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        PackFlags flags = PackFlags.None;
        if (!serializer.IsReader)
        {
            flags = GetPackFlags();
        }

        serializer.SerializeValue(ref ActionTypeEnum);
        serializer.SerializeValue(ref flags);

        if (serializer.IsReader)
        {
            CancelMovement = (flags & PackFlags.CancelMovement) != 0;
        }

        if ((flags & PackFlags.HasPosition) != 0)
        {
            serializer.SerializeValue(ref Position);
        }
        if ((flags & PackFlags.HasDirection) != 0)
        {
            serializer.SerializeValue(ref Direction);
        }
        if ((flags & PackFlags.HasAmount) != 0)
        {
            serializer.SerializeValue(ref Amount);
        }
    }
}
