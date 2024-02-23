using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    private GameObject player;
    public Vector3Int currentPlayerChunkPosition;
    private Vector3Int currentChunkCenter = Vector3Int.zero;

    public World world;

    public float detectionTime = 1;
    public CinemachineVirtualCamera camera_VM;

    public void SpawnPlayer() {
        if (player != null) {
            return;
        }

        Vector3Int raycastStartPosition = new Vector3Int(world.chunkSize / 2, 100, world.chunkSize / 2);
        RaycastHit hit;
        if (Physics.Raycast(raycastStartPosition, Vector3.down, out hit, 120)) {
            player = Instantiate(playerPrefab, hit.point + Vector3.up, Quaternion.identity);
            camera_VM.Follow = player.transform.GetChild(0);
            StartCheckingTheMap();
        }
    }

    public void StartCheckingTheMap() {
        SetCurrentChunkCoordinates();
        StopAllCoroutines();
        StartCoroutine(CheckIfShouldLoadNextPosition());
    }

    IEnumerator CheckIfShouldLoadNextPosition() {
        yield return new WaitForSeconds(detectionTime);

        if (
            Mathf.Abs(currentChunkCenter.x - player.transform.position.x) > world.chunkSize ||
            Mathf.Abs(currentChunkCenter.z - player.transform.position.z) > world.chunkSize ||
            Mathf.Abs(currentChunkCenter.y - player.transform.position.y) > world.chunkHeight
            ) {
            world.LoadAdditionalChunkRequest(player);
        }
        else {
            StartCoroutine(CheckIfShouldLoadNextPosition());
        }
    }

    private void SetCurrentChunkCoordinates() {
        currentPlayerChunkPosition = WorldDataHelper.ChunkPositionFromBlockCoords(world, Vector3Int.RoundToInt(player.transform.position));
        currentChunkCenter.x = currentPlayerChunkPosition.x + world.chunkSize / 2;
        currentChunkCenter.z = currentPlayerChunkPosition.z + world.chunkSize / 2;
    }
}
