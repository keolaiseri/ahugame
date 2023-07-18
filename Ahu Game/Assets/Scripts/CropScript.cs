using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropScript : MonoBehaviour
{

    public int maxGrowthStage = 3; // the maximum growth stage of the crop
    public float harvestDuration = 1f; // the growth rate of the crop
    public GameObject harvestedCropPrefab; // the prefab for the harvested crop

    private int currentGrowthStage = 0; // the current growth stage of the crop
    private bool isHarvested = false; // whether the crop has been harvested

    public void IncrementGrowthStage()
    {
        if(!isHarvested && currentGrowthStage < maxGrowthStage)
        {
            currentGrowthStage++;        
        }
    }

   
   //Harvest the crop
    public void HarvestCrop()
    {
        if(!isHarvested)
        {
            isHarvested = true; 

            //Perform any necessary actons when the crop is harvested

            //Spawn the harvested crop prefab in place of the original crop
            Instantiate(harvestedCropPrefab, transform.position, transform.rotation);

        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
