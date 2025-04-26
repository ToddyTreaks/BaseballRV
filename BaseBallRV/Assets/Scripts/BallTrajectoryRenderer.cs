using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class BallTrajectoryRenderer : MonoBehaviour
{
    private LineRenderer _trajectoryRenderer;
    private int _innerCount = 5;
    [SerializeField] private int updateEveryXUpdate = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        _trajectoryRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        for (int i = _trajectoryRenderer.positionCount-1; i >= 0; i--)
        {
            _trajectoryRenderer.SetPosition(i,this.gameObject.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (++_innerCount > updateEveryXUpdate)
        {
            for (int i = _trajectoryRenderer.positionCount - 2; i >= 0; i--)
            {
                _trajectoryRenderer.SetPosition(i + 1, _trajectoryRenderer.GetPosition(i));
            }
            _innerCount = 0;
        }
        
        _trajectoryRenderer.SetPosition(0, this.gameObject.transform.position);

    }
}
