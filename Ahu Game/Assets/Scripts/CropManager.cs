using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    public GameObject cropPrefab; // prefab for the crops
    public Transform plantingArea; // where the crops will be placed

    private float growthTimer = 0f; // timer for growing the crops
    private float growthDuration = 5f; // duration of each growth stage

    private GameObject currentCrop; // the currently growing crop


    // Plant a new crop at the specified position
    public void PlantCrop(Vector3 position)
    {
        if (currentCrop == null)
        {
            // Create a new crop
            currentCrop = Instantiate(cropPrefab, position, Quaternion.identity, plantingArea);
            growthTimer = 0f;
        }

    }

    private void Update()
    {
        //Check if the crop is planted
        if (currentCrop != null)
        {
            // Increase the growth timer
            growthTimer += Time.deltaTime;

            // Check if its time for the crop to grow
            if (growthTimer >= growthDuration)
            {
                //Call the GrowCrop function
                GrowCrop();
            }
        }
    }

    // Handle the growth of the crop
    private void GrowCrop()
    {
        // Get the CropScript component from the currently growing crop
        CropScript cropScript = currentCrop.GetComponent<CropScript>();

        //Increment the growth stage
        cropScript.IncrementGrowthStage();

        // Reset the growth timer
        growthTimer = 0f;

    }

    //Harvest the crop
    public void HarvestCrop()
    {
        if (currentCrop!= null)
        {
            Destroy(currentCrop);
            currentCrop = null;
            growthTimer = 0f;
        }
    }
}
