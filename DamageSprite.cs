using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSprite : MonoBehaviour
{
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.hittedTime < 4.0f){
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            gameObject.GetComponent<SpriteRenderer> ().color =  new Color(1f,1f,1f,level);
        }        
    }
}
