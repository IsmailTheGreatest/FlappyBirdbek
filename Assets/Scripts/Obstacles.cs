using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 1.0f;
  public Player player;
    // Update is called once per frame\

    private void FixedUpdate()
    {
        //since our Transform Component is by default set to Vector3, we cannot use Vector2.left to be assigned to 
        //transform.position
      if(!player.isDead){transform.position += ((Vector3.left * speed) * Time.deltaTime);}
      
    }
}
