using UnityEngine;

public class IncreasingSize : MonoBehaviour
{
    [SerializeField] private float _growthRate;

    private void Update()
    {
        Increase();
    }

    private void Increase()
    {
        transform.localScale += Vector3.one * _growthRate * Time.deltaTime;
    }
}
