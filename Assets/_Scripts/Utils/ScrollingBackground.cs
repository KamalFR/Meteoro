using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private Sprite _defaultBackground;
    [SerializeField] Vector2 _scrollVelocity;

    private RawImage _rawImage;
    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        _rawImage.uvRect = new Rect(_rawImage.uvRect.position + _scrollVelocity * Time.deltaTime, _rawImage.uvRect.size);
    }
}
