using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
      if (player != null)
      {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.LookAt(player);
        
       }
       
    }


}
