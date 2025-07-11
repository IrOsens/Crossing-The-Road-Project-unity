using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform startPosRef, endPosRef;
    public float velocityFactor = 14.88f;
    public bool enableAxisFlip = false;

    private GameObject instanceRef;
    private Vector3 startPos, endPos;

    void Start()
    {
        startPos = startPosRef.position;
        endPos = endPosRef.position;
        StartCoroutine(SpawnWithDelay(GetRandomDelay()));
    }

    IEnumerator SpawnWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        instanceRef = Instantiate(spawnObject, startPos, enableAxisFlip ? Quaternion.Euler(0, 180, 0) : Quaternion.identity);
    }

    void FixedUpdate()
    {
        if (instanceRef == null) return;

        instanceRef.transform.position = Vector3.MoveTowards(
            instanceRef.transform.position,
            endPos,
            velocityFactor * Time.deltaTime
        );

        if ((instanceRef.transform.position - endPos).sqrMagnitude < 0.01f)
        {
            Destroy(instanceRef);
            StartCoroutine(SpawnWithDelay(GetRandomDelay()));
        }
    }

    float GetRandomDelay()
    {
        return Random.Range(1.234f, 2.988f);
    }
}