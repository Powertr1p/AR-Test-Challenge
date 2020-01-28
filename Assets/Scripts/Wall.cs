using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Cylinder _first;
    private Cylinder _second;

    private Renderer _materialRenderer;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 _distanceBetweenObjects;
    private Vector3 _positionInMiddle;

    private void Start()
    {
        _materialRenderer = GetComponent<Renderer>();
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

        if (_first.IsRendered == false || _second.IsRendered == false)
        {
            _first.HasWall = false;
            Destroy(gameObject);
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
        transform.localScale = new Vector3(transform.localScale.x, _distanceBetweenObjects.magnitude * 1, transform.localScale.z);
    }

    private void ChangeColor()
    {


        //localscale.y = 3 == red
    }
}
