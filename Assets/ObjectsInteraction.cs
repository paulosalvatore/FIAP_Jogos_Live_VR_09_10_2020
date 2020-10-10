using System;
using UnityEngine;

public class ObjectsInteraction : MonoBehaviour
{
    public Color defaultColor = Color.white;

    public Color touchingColor = Color.red;

    public Color interactingColor = Color.green;

    private GameObject _interactingObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            InteractWithObject();
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            RemoveInteractWithObject();
        }
    }

    private void InteractWithObject()
    {
        if (_interactingObject == null)
        {
            return;
        }

        ChangeColor(_interactingObject, interactingColor);

        _interactingObject.transform.SetParent(transform);
    }

    private void RemoveInteractWithObject()
    {
        if (_interactingObject == null)
        {
            return;
        }

        ChangeColor(_interactingObject, touchingColor);

        _interactingObject.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        _interactingObject = other.gameObject;

        ChangeColor(other, touchingColor);
    }

    private void OnTriggerExit(Collider other)
    {
        _interactingObject = null;

        ChangeColor(other, defaultColor);
    }

    private static void ChangeColor(Component other, Color color)
    {
        var renderer = other.GetComponent<MeshRenderer>();

        renderer.material.SetColor("_Color", color);
    }

    private static void ChangeColor(GameObject other, Color color)
    {
        var renderer = other.GetComponent<MeshRenderer>();

        renderer.material.SetColor("_Color", color);
    }
}
