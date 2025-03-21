using UnityEngine;

public class VelocityDebugger : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 20f;
    void Update()
    {
        GetComponent<Renderer>().material.color = ColorForVelocity();
    }

    private Color ColorForVelocity()
    {
        float velocity = GetComponent<Rigidbody>().angularVelocity.magnitude;

        return Color.Lerp(Color.green, Color.red, velocity / maxVelocity);
    }

}
