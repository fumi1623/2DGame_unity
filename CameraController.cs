using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraBox;
    public GameObject player;
    public PlayerController playerController;
    public GameObject rightCamera;
    public GameObject leftCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //なめらかな移動とそれに伴うカメラの移動
        Transform playerTransform = player.transform;
        Vector3 playerPos = playerTransform.position;
        Transform cameraTransform = cameraBox.transform;
        Vector3 cameraPos = cameraTransform.position;
        cameraPos.y = playerPos.y;
        cameraTransform.position = cameraPos;
        Vector3 rightCameraLimit = playerPos + new Vector3(4f, 0f, -10f);
        if(playerController.playerRotation == false && cameraPos.x < rightCameraLimit.x){
            cameraPos.x += 0.02f;
            cameraTransform.position = cameraPos;
        }
        if(playerController.playerRotation == true && cameraPos.x > playerPos.x ){
            cameraPos.x -= 0.02f;
            cameraTransform.position = cameraPos;
        }


    }
}
