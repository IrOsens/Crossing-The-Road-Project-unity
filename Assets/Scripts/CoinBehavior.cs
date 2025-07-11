using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
       transform.Rotate(0f, 0f, 30f * Time.deltaTime);
    }
}