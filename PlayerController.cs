using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    Rigidbody2D rb;
    public bool playerRotation = false;
    public float moveLeftTime = 0.0f;
    public float jumpTime = 0.0f;
    public float attackTime = 0.0f;
    public float hittedTime = 0.0f;
    public float jumpForce = 200f;
    public GameObject fireBoll;
    public Transform weapon;
    public float fireSpeed;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpTime = 0f;
        attackTime = 0f;
        hittedTime = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        attackTime += Time.deltaTime;
        if(Input.GetKey(KeyCode.Z) && attackTime > 1.0f){
            animator.SetTrigger("Attack");
            GameObject fire = Instantiate(fireBoll) as GameObject;
            if(playerRotation == false){
                Vector2 fireForce = new Vector2(1.0f, 0f);
                fire.GetComponent<Rigidbody2D>().AddForce(fireForce * fireSpeed);
                fire.transform.position = weapon.position;
            } else {
                Vector2 fireForce = new Vector2(-1.0f, 0f);
                fire.GetComponent<Rigidbody2D>().AddForce(fireForce * fireSpeed);
                fire.transform.position = weapon.position;                
            }
            attackTime = 0f;
        }

        jumpTime += Time.deltaTime;
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))&& jumpTime > 1.0f){
            animator.SetTrigger("Jump");
            Invoke("Jump", 0.1f);
            jumpTime = 0f;
        }

        hittedTime += Time.deltaTime;
        if(hittedTime < 4.0f){
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            gameObject.GetComponent<SpriteRenderer> ().color =  new Color(1f,1f,1f,level);
        }

    }

    void Jump(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(0f, 1.0f);
        rb.AddForce(force * jumpForce);
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

        animator.SetFloat("Speed", 0f);

        Transform playerTransform = this.transform;
        Vector2 playerPos = playerTransform.position;
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            moveLeftTime = 0f;
            playerRotation = false;
            Rotate();
            playerPos.x += 1.0f * moveSpeed;
            playerTransform.position = playerPos;
            animator.SetFloat("Speed", 1.0f);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            playerRotation = true;
            Rotate();
            playerPos.x -= 1.0f * moveSpeed;
            playerTransform.position = playerPos;
            moveLeftTime += Time.deltaTime;
            animator.SetFloat("Speed", 1.0f);
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

    public void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("Enemy") && hittedTime > 4.0f) {
            animator.SetTrigger("hitted");
            hittedTime = 0f;
        }
    }
}
