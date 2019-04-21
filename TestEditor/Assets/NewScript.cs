using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    enum Axis
    {
        x,
        y,
        z
    }

    [SerializeField] private int _count = 1;
    [SerializeField] private int _offset = 1;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Axis _axis;

    private void Start()
    {
        CreateObj();
    }

    public void CreateObj()
    {
        int x = 0;
        int y = 0;
        int z = 0;
        if (_axis == Axis.x)
            x = _offset;
        else if (_axis == Axis.y)
            y = _offset;
        else if (_axis == Axis.z)
            z = _offset;
        for (int i = 0; i < _count; i++)
        {
            Instantiate(_gameObject, new Vector3(x * i, y * i, z * i), Quaternion.identity);
        }
    }
}
