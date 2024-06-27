

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Blok prefab'�n� bu de�i�kene atay�n
    public float minX = -2.5f; // X ekseninde minimum pozisyon
    public float maxX = 2.5f; // X ekseninde maksimum pozisyon
    public float spawnHeight = 5f; // Bloklar�n spawnlanaca�� y�kseklik
    public float minDistanceBetweenBlocks = 2f; // Bloklar aras�ndaki minimum mesafe
    public float maxDistanceBetweenBlocks = 10f; // Bloklar aras�ndaki maksimum mesafe

    private float lastBlockY; // Son blokun Y pozisyonu

    void Start()
    {
        // �lk blo�u yerle�tirme
        SpawnBlock(new Vector2(0, 0));
    }

    void Update()
    {
        // Kamera yukar� do�ru hareket ettik�e yeni bloklar spawnlan�r
        if (Camera.main.transform.position.y + spawnHeight > lastBlockY)
        {
            float distanceBetweenBlocks = Random.Range(minDistanceBetweenBlocks, maxDistanceBetweenBlocks);
            SpawnBlock(new Vector2(Random.Range(minX, maxX), lastBlockY + distanceBetweenBlocks));
        }
    }

    void SpawnBlock(Vector2 position)
    {
        Instantiate(blockPrefab, position, Quaternion.identity);
        lastBlockY = position.y;
    }
}


