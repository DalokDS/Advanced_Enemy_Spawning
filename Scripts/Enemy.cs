using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    private SpriteRenderer _spriteRenderer;

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        _spriteRenderer.flipX = transform.position.x < _target.position.x;
    }

    public void Init(Transform target)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (target != null)
            _target = target;
    }
}