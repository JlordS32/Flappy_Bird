using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 2f;

    List<Transform> _backgrounds;
    Camera _cam;
    float _screenHalfWidth;
    float _width;

    void Start()
    {
        _cam = Camera.main;
        _screenHalfWidth = _cam.orthographicSize * _cam.aspect;

        _backgrounds = new List<Transform>();

        int count = transform.childCount;
        for (int i = 0; i < count; i++)
            _backgrounds.Add(transform.GetChild(i));

        _width = _backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void Update()
    {
        foreach (Transform bg in _backgrounds)
        {
            bg.position += scrollSpeed * Time.deltaTime * Vector3.left;
            float camLeftEdge = _cam.transform.position.x - _screenHalfWidth;

            if (bg.position.x + (_width / 2) <= camLeftEdge)
            {
                float rightmostX = GetRightmostSpritePosX();
                bg.position = new Vector3(rightmostX + _width, bg.position.y, bg.position.z);

            }
        }
    }

    float GetRightmostSpritePosX()
    {
        float maxX = float.MinValue;
        foreach (Transform bg in _backgrounds)
        {
            if (bg.position.x > maxX)
                maxX = bg.position.x;
        }
        return maxX;
    }

}
