using UnityEngine;

public class MovingForward : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
