using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * _speedMovement * Time.deltaTime);
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * _speedMovement * Time.deltaTime);
            _spriteRenderer.flipX = true;
        }
    }
}
