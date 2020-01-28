using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private GameObject _first;
    private GameObject _second;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private Vector3 _distanceBetweenObjects;
    private Vector3 _positionInMiddle;

    public void Init(ref GameObject firstObject, ref GameObject secondObject)
    {
        _first = firstObject;
        _second = secondObject;
    }

    private void Update()
    {
        GetNewPositionPoints();
        UpdateCurrentPosition();
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
}
