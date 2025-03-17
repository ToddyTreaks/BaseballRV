using UnityEngine;

public class BatCapsule : MonoBehaviour
{

    [SerializeField] private BatCapsuleFollower _batCapsuleFollowerPrefab;

    private void SpawnBatCapsuleFollower()
    {
        var follower = Instantiate(_batCapsuleFollowerPrefab, this.transform.position, this.transform.rotation);
        follower.SetFollowTarget(this);
    }

    void Start()
    {
        SpawnBatCapsuleFollower();
    }

}
