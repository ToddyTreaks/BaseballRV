using System.Collections;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform spawnPoint;
    public bool enableSpawn = true;
    public float spawnTime = 2.0f;
    public float launchForce = 10f;
    public float maxHorizontalAngleOffset = 5f;
    public float maxVerticalAngleOffset = 5f;

    void Start()
    {
        StartCoroutine(spawning());
    }

    IEnumerator spawning()
    {
        while (enableSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        GameObject spawnedBall = Instantiate(ball, spawnPoint.position, spawnPoint.rotation);

        Rigidbody rb = spawnedBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Random horizontal angle within the max offset
            float angleH = Random.Range(-maxHorizontalAngleOffset, maxHorizontalAngleOffset);
            float angleV = Random.Range(-maxVerticalAngleOffset, maxVerticalAngleOffset);
            // Rotate spawnPoint's forward vector around the Y-axis (horizontal plane)
            Vector3 direction = Quaternion.Euler(0f, angleH, angleV) * spawnPoint.forward;

            rb.linearVelocity = direction.normalized * launchForce;
        }
    }
}

