using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkData {

    public BlockType[] blocks;
    public int chunkSize = 16;
    public int chunkHeight = 100;
    public World worldReference;
    public Vector3Int worldPosition;

    public bool modifiedByThePlayer = false;
    public TreeData treeData;

    public ChunkData(int chunkSize, int chunkHeight, World worldReference, Vector3Int worldPosition) {
        this.chunkSize = chunkSize;
        this.chunkHeight = chunkHeight;
        this.worldReference = worldReference;
        this.worldPosition = worldPosition;
        blocks = new BlockType[chunkSize * chunkHeight * chunkSize];
    }
}
