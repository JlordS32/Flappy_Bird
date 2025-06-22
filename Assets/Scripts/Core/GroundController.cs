using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 2f;

    Vector3 _startPos;
    float _tileWidthWorld;
    int _tileCount;

    void Start()
    {
        _startPos = transform.position;

        var tilemap = GetComponent<Tilemap>();
        _tileCount = tilemap.size.x;
        _tileWidthWorld = tilemap.cellSize.x * _tileCount;
    }

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x <= _startPos.x - _tileWidthWorld)
        {
            transform.position = _startPos;
        }
    }
}
