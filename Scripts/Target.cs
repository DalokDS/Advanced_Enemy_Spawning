using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private int _currentPoint;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = _waypoints[_currentPoint].position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentPoint].position, _speed * Time.deltaTime);
        _spriteRenderer.flipX = transform.position.x < _waypoints[_currentPoint].position.x;

        int lastWaypointIndex = _waypoints.Length - 1;

        if (transform.position == _waypoints[_currentPoint].position)
        {
            if (_currentPoint == lastWaypointIndex)
                _currentPoint = 0;
            else
                _currentPoint++;
        }
    }
}