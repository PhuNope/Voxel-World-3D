using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionExtensions {

    public static Vector3Int GetVector(this Direction direction) {
        return direction switch {
            Direction.forward => Vector3Int.forward,
            Direction.right => Vector3Int.right,
            Direction.backwards => Vector3Int.back,
            Direction.left => Vector3Int.left,
            Direction.up => Vector3Int.up,
            Direction.down => Vector3Int.down,
            _ => throw new Exception("Ivalid input diretion")
        };
    }
}
