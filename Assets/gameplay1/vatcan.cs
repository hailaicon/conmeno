using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Mảng chứa các Prefab vật cản
    public float spawnInterval = 5f;     // Thời gian giữa mỗi lần spawn
    public float spawnDistance = 30f;    // Khoảng cách vật cản được spawn từ người chơi
    private Transform player;            // Tham chiếu tới vị trí người chơi
    private List<GameObject> spawnedObstacles = new List<GameObject>(); // Danh sách vật cản đã spawn

    void Start()
    {
        // Tìm đối tượng Player trong scene bằng tag "Player"
        player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(SpawnObstacles());
    }
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnObstacle()
    {
        float spawnZ = player.position.z + spawnDistance;
        float spawnX = Random.Range(-4f, 4f);
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstaclePrefab, new Vector3(spawnX, 0.5f, spawnZ), Quaternion.identity);

        // Thêm vật cản vào danh sách quản lý
        spawnedObstacles.Add(spawnedObstacle);

        // Gọi coroutine để xóa vật cản sau thời gian sống
        StartCoroutine(DestroyObstacleAfterTime(spawnedObstacle));
    }

    // Coroutine để xóa vật cản sau thời gian sống
    IEnumerator DestroyObstacleAfterTime(GameObject obstacle)
    {
        while (obstacle)
        {
            // Đợi thời gian sống của vật cản
            yield return new WaitForSeconds(7f);

            // Xóa vật cản khỏi scene
            Destroy(obstacle);
        }

    }
}