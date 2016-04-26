using UnityEngine;
using System.Collections;

public static class ExtensionMethods {

    public static void ResetTransform(this Transform trans)
    {
        trans.position = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = new Vector3(1, 1, 1);
    }

    public static void AddChild(this Transform _parent, Transform _child, bool _worldPosStays)
    {
        _child.SetParent(_parent, _worldPosStays);
    }

    public static void AddChild(this Transform _parent, GameObject _child, bool _worldPosStays)
    {
        _child.transform.SetParent(_parent, _worldPosStays);
    }
}
