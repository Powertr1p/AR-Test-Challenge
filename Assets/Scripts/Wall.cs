using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Cylinder _first;
    private Cylinder _second;

    private Material _material;
    private Color _wallColor;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 _distanceBetweenObjects;
    private Vector3 _positionInMiddle;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    public void Init(ref Cylinder firstObject, ref Cylinder secondObject)
    {
        _first = firstObject;
        _second = secondObject;
        _first.HasWall = true;
    }

    private void Update()
    {
        GetNewPositionPoints();
        UpdateCurrentPosition();
        ChangeColor();

        if (_first.IsRendered == false || _second.IsRendered == false)
        {
            DestroySelf();
        }
    }

    private void GetNewPositionPoints()
    {
        _startPosition = _first.transform.position;
        _endPosition = _second.transform.position;

        _distanceBetweenObjects = _endPosition - _startPosition;
        _positionInMiddle = (_distanceBetweenObjects) / 2 + _startPosition;
    }

    private void UpdateCurrentPosition()
    {
        transform.position = _positionInMiddle;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, _distanceBetweenObjects);
        transform.localScale = new Vector3(transform.localScale.x, _distanceBetweenObjects.magnitude, transform.localScale.z);
    }

    private void ChangeColor()
    {
        _wallColor.r = 1;
        _wallColor.g = (255 / transform.localScale.y) / 100;
        _wallColor.b = (255 / transform.localScale.y) / 100;
        _material.color = _wallColor;
    }

    public void DestroySelf()
    {
        _first.HasWall = false;
        Destroy(gameObject);
    }
}
