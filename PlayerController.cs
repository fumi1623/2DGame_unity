using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    Rigidbody2D rb;
    public bool playerRotation = false;
    public float moveLeftTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        // 入力をxに代入
        //addForceだと初速が遅い
        // float x = Input.GetAxis("Horizontal");
        // //Rigidbody2Dを取得
        // Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // //x軸に加わる力を格納
        // Vector2 force = new Vector2(x*10, 0);
        // //Rigidbody2Dに力を加える
        // rb.AddForce(force);

        Transform playerTransform = this.transform;
        Vector2 playerPos = playerTransform.position;
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            moveLeftTime = 0f;
            playerRotation = false;
            Rotate();
            playerPos.x += 1.0f * moveSpeed;
            playerTransform.position = playerPos;
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            playerRotation = true;
            Rotate();
            playerPos.x -= 1.0f * moveSpeed;
            playerTransform.position = playerPos;
            moveLeftTime += Time.deltaTime;
        }
    }

    void Rotate() {
        Vector3 scale = transform.localScale;
        if(playerRotation == true){
            scale.x = -1;
            transform.localScale = scale;
        } else {
            scale.x = 1;
            transform.localScale = scale;            
        }
    }
}
