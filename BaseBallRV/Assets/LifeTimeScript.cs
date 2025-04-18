using UnityEngine;
using System.Collections;

public class LifeTimeScript : MonoBehaviour
{

    [SerializeField] private float lifetime = 4f;
    public bool haslifetime = true;

    void Start()
    {
        StartCoroutine(finalcountdown());
    }

    IEnumerator finalcountdown()
    {
        if (haslifetime)
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(gameObject);
        }
    }

}

