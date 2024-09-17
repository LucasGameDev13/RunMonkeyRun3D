using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "Create Animal/New Animal")]
public class AnimalsSO : ScriptableObject
{
    [SerializeField] private GameObject animalPrefab;
    [SerializeField] private Transform animalPaths;
    [SerializeField] private float animalSpeed;
    [SerializeField] private float animalSpeedRotation;

    public GameObject GetAnimalPrefab()
    {
        return animalPrefab;
    }

    public Transform GetAnimialPathsFirstPosition()
    {
        return animalPaths.GetChild(0);
    }

    public List<Transform> GetAnimalPaths()
    {
        List<Transform> wayPaths = new List<Transform>();

        foreach(Transform ways in animalPaths)
        {
            wayPaths.Add(ways);
        }

        return wayPaths;
    }

    public float GetAnimalSpeed()
    {
        return animalSpeed;
    }

    public float GetAnimalSpeedRotation()
    {
        return animalSpeedRotation;
    }
}
