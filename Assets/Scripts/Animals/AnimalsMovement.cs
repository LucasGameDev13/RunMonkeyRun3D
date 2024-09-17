using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsMovement : MonoBehaviour
{
    [SerializeField] private AnimalsSO animalSo;
    private List<Transform> wayPaths;
    private int wayPathsIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        wayPaths = animalSo.GetAnimalPaths();
        transform.localPosition = wayPaths[wayPathsIndex].localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAnimals();
    }

    private void MoveAnimals()
    {
        if(wayPathsIndex < wayPaths.Count)
        {
            Vector3 target = wayPaths[wayPathsIndex].localPosition;
            float speed = animalSo.GetAnimalSpeed() * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed);
            Vector3 direction = (target - transform.localPosition).normalized;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, animalSo.GetAnimalSpeedRotation() * Time.deltaTime);
            }

            if (Vector3.Distance(transform.localPosition, target) < 0.1f)
            {
                wayPathsIndex++;
            }

        }
        else
        {
            wayPathsIndex = 0;
        }
    }

}
