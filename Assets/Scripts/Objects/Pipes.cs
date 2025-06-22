using UnityEngine;
using System.Collections.Generic;

public class Pipes : MonoBehaviour
{
    #region MEMBER VARIABLES
    // PROPERTIES
    [SerializeField] float _speed = 1f;
    [SerializeField] int _scorePoints = 1;

    // PRIVATE VARIABLES
    float _screenHalfWidth;
    List<SpriteRenderer> _renderers = new();

    // REFERENCES
    Camera _cam;
    ScoreManager _scoreManager;
    UIManager _uiManager;

    #endregion

    #region UNITY FUNCTIONS
    void Awake()
    {
        _cam = Camera.main; // Get Main Camera
        _scoreManager = FindFirstObjectByType<ScoreManager>();
        _uiManager = FindFirstObjectByType<UIManager>();
    }   

    void Start()
    {
        _renderers.AddRange(GetComponentsInChildren<SpriteRenderer>());
        _screenHalfWidth = _cam.orthographicSize * _cam.aspect;
    }

    void Update()
    {
        if (CheckBounds())
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position += _speed * Time.fixedDeltaTime * Vector3.left;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _scoreManager.IncreaseScore(_scorePoints);
            _uiManager.UpdateScoreText(_scoreManager.Score);
        }

    }
    #endregion

    #region FUNCTIONS
    bool CheckBounds()
    {
        if (_renderers.Count > 0)
        {
            Bounds updatedBounds = _renderers[0].bounds;
            for (int i = 1; i < _renderers.Count; ++i)
                updatedBounds.Encapsulate(_renderers[i].bounds);

            if (updatedBounds.max.x < _cam.transform.position.x - _screenHalfWidth)
            {
                return true;
            }
        }

        if (_renderers.Count == 0)
        {
            Debug.LogWarning("No sprite under obstacle detected!");
        }

        return false;
    }

    #endregion
}
