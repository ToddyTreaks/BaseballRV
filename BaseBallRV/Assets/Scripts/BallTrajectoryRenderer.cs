using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class BallTrajectoryRenderer : MonoBehaviour
{
    private LineRenderer _trajectoryRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        _trajectoryRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        for (int i = _trajectoryRenderer.positionCount; i >= 0; i--)
        {
            _trajectoryRenderer.SetPosition(i,this.gameObject.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = _trajectoryRenderer.positionCount-1; i >= 0 ; i--)
        {
            _trajectoryRenderer.SetPosition(i+1, _trajectoryRenderer.GetPosition(i));
        }
        _trajectoryRenderer.SetPosition(0, this.gameObject.transform.position);

    }
}
