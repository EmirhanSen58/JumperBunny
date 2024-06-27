

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Blok prefab'ýný bu deðiþkene atayýn
    public float minX = -2.5f; // X ekseninde minimum pozisyon
    public float maxX = 2.5f; // X ekseninde maksimum pozisyon
    public float spawnHeight = 5f; // Bloklarýn spawnlanacaðý yükseklik
    public float minDistanceBetweenBlocks = 2f; // Bloklar arasýndaki minimum mesafe
    public float maxDistanceBetweenBlocks = 10f; // Bloklar arasýndaki maksimum mesafe

    private float lastBlockY; // Son blokun Y pozisyonu

    void Start()
    {
        // Ýlk bloðu yerleþtirme
        SpawnBlock(new Vector2(0, 0));
    }

    void Update()
    {
        // Kamera yukarý doðru hareket ettikçe yeni bloklar spawnlanýr
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


