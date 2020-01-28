using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] List<Cylinder> _renderedCylinders;
    [SerializeField] List<Cylinder> _cylinders;

    [SerializeField] private GameObject _wallPrefab;

    private void Update()
    {
        TrackObjects();
        PickRenderedObject();
    }

    private void SpawnWall(Cylinder firstObject, Cylinder secondObject)
    {
        var wall = Instantiate(_wallPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        wall.GetComponent<Wall>().Init(ref firstObject, ref secondObject);
    }

    private void TrackObjects()
    {
        var renderedCylinder = _cylinders.FirstOrDefault(cylinder => cylinder.IsRendered == true);
        if (renderedCylinder != null)
        {
            _renderedCylinders.Add(renderedCylinder);
            _cylinders.Remove(renderedCylinder);
        }

        var unrenderedCylinder = _renderedCylinders.FirstOrDefault(cylinder => cylinder.IsRendered == false);
        if (unrenderedCylinder != null)
        {
            _cylinders.Add(unrenderedCylinder);
            _renderedCylinders.Remove(unrenderedCylinder);
        }
    }

    private void PickRenderedObject()
    {
        if (_renderedCylinders.Count < 2) { return; }

        if (_renderedCylinders.Count == 2 && !_renderedCylinders[0].HasWall)
            SpawnWall(_renderedCylinders[0], _renderedCylinders[1]);

        //if (_renderedCylinders.Count == 3)
           // SpawnWall(_renderedCylinders[1], _renderedCylinders[2]);
    }
}
