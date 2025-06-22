using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // PROPERTIES
    [SerializeField] float _velocity = 1.5f;
    [SerializeField] float _fallMultiplier = 2f;

    [Header("Motion Angle")]
    [SerializeField] float _lookUp = 35f;
    [SerializeField] float _lookDown = -45f;

    [Header("Audio")]
    [SerializeField] AudioClip _jumpSound;
    [SerializeField] AudioClip _deathSound;

    // REFERENCES
    Rigidbody2D _rb;
    BoxCollider2D _collider;
    GameManager _gameManager;
    bool _canMove = true;
    public bool CanMove => _canMove;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        Rotation();
    }

    public void OnClick()
    {
        if (!_canMove) return;
        AudioManager.Instance.PlaySound(_jumpSound);    // Play Sound
        _rb.linearVelocity = Vector2.zero;
        _rb.linearVelocity = Vector2.up * _velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.PlaySound(_deathSound);
        _gameManager.ToggleDeath();

        _canMove = false;
        _rb.linearVelocity = Vector2.zero;
        _collider.enabled = false;
    }

    void Rotation()
    {
        float tiltAngle;

        if (_rb.linearVelocityY < 0)
        {
            _rb.linearVelocity += (_fallMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
            tiltAngle = _lookDown;
        }
        else
        {
            tiltAngle = _lookUp;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, tiltAngle),
        Time.deltaTime * 5f);
    }
}
