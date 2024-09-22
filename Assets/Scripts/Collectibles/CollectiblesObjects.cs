using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesObjects : MonoBehaviour
{
    [Header("Collectible Objects Settings")]
    [SerializeField] private float objectsRotationSpeed;
    [SerializeField] private int objectIndex;

    // Update is called once per frame
    void Update()
    {
        //Rotating objects
        transform.Rotate(Vector3.up * objectsRotationSpeed * Time.deltaTime);
    }

    //Object index
    public int GetObjectIndex()
    {
        return objectIndex;
    }
}
