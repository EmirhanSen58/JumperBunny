using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DisableCollider()
    {
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
    }

    public void EnableCollider()
    {
        _collider.enabled = true;
    }
}
