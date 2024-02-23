using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class BiomeCenterFinder {

    public static List<Vector2Int> neighbours8Directions = new List<Vector2Int> {
        new Vector2Int(0,1),
        new Vector2Int(1,1),
        new Vector2Int(1,0),
        new Vector2Int(1,-1),
        new Vector2Int(0,-1),
        new Vector2Int(-1,-1),
        new Vector2Int(-1,0),
        new Vector2Int(-1,1)
    };

    public static List<Vector3Int> CalculateBiomeCenters(Vector3 playerPosition, int drawRange, int mapSize) {
        int biomeLength = drawRange * mapSize;

        Vector3Int origin = new Vector3Int(
            Mathf.RoundToInt(playerPosition.x / biomeLength) * biomeLength,
            0,
            Mathf.RoundToInt(playerPosition.z / biomeLength) * biomeLength);

        HashSet<Vector3Int> biomeCentersTemp = new HashSet<Vector3Int>();

        biomeCentersTemp.Add(origin);

        foreach (Vector2Int offsetXY in neighbours8Directions) {
            Vector3Int newBiomPoint_1 = new Vector3Int(origin.x + offsetXY.x * biomeLength, 0, origin.z + offsetXY.y * biomeLength);
            Vector3Int newBiomPoint_2 = new Vector3Int(origin.x + offsetXY.x * biomeLength, 0, origin.z + offsetXY.y * 2 * biomeLength);
            Vector3Int newBiomPoint_3 = new Vector3Int(origin.x + offsetXY.x * 2 * biomeLength, 0, origin.z + offsetXY.y * biomeLength);
            Vector3Int newBiomPoint_4 = new Vector3Int(origin.x + offsetXY.x * 2 * biomeLength, 0, origin.z + offsetXY.y * 2 * biomeLength);

            biomeCentersTemp.Add(newBiomPoint_1);
            biomeCentersTemp.Add(newBiomPoint_2);
            biomeCentersTemp.Add(newBiomPoint_3);
            biomeCentersTemp.Add(newBiomPoint_4);
        }

        return biomeCentersTemp.ToList();
    }
}
