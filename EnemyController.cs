using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float enemyMoveSpeed;
    public bool enemyRotation = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform enemyTransform = this.transform;
        Vector2 enemyPos = enemyTransform.position;
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        Vector2 playerPos = playerTransform.position;
        if(enemyPos.x >= playerPos.x){
            enemyRotation = false;
            Rotate();
            enemyPos.x -= 0.1f * enemyMoveSpeed;
            enemyTransform.position = enemyPos;
        } else {
            enemyRotation = true;
            Rotate();
            enemyPos.x += 0.1f * enemyMoveSpeed;
            enemyTransform.position = enemyPos;
        }
        
    }

    void Rotate() {
        Vector3 scale = transform.localScale;
        if(enemyRotation == true){
            scale.x = -1;
            transform.localScale = scale;
        } else {
            scale.x = 1;
            transform.localScale = scale;            
        }
    }
    
}
