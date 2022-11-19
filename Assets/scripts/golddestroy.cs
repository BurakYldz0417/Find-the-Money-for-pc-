using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golddestroy : MonoBehaviour
{
    game Game;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
           Game.goldcounter -= 1;
        }
    }
}
