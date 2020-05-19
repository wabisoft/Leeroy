using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehavior : MonoBehaviour
{
    public float FoodEaten = 0;

    void OnCollisionEnter(Collision collision)
    {
        var food = collision.gameObject.GetComponent<FoodBehavior>();
        if(food)
        {
            Debug.Log("Ate some food");
            Destroy(collision.gameObject);
            FoodEaten++;
        }
    }

}
