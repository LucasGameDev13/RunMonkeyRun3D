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

    //Getting the animal game object 
    public GameObject GetAnimalPrefab()
    {
        return animalPrefab;
    }

    //Getting the first position of the paths
    public Transform GetAnimialPathsFirstPosition()
    {
        return animalPaths.GetChild(0);
    }

    //Saving all the ways on the path into a list
    public List<Transform> GetAnimalPaths()
    {
        List<Transform> wayPaths = new List<Transform>();

        foreach(Transform ways in animalPaths)
        {
            wayPaths.Add(ways);
        }

        return wayPaths;
    }

    //Getting the animal speed
    public float GetAnimalSpeed()
    {
        return animalSpeed;
    }

    //Getting the animal speed rotation
    public float GetAnimalSpeedRotation()
    {
        return animalSpeedRotation;
    }
}
