using System.Collections;
using UnityEngine;

public class ballspawner : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool enableSpawn = true;
    [SerializeField] private float spawnTime = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawning());
    }

    IEnumerator spawning()
    {
        while (enableSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(ball, spawnPoint.position, spawnPoint.rotation, spawnPoint);
        }
    }
}
