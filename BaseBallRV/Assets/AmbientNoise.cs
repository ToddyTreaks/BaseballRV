using UnityEngine;

public class AmbientNoise : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlayAmbient("Wind");
        AudioManager.Instance.PlayAmbient("Crowd");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
