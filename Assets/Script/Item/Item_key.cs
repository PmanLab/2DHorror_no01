using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_key : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {// ƒvƒŒƒCƒ„[‚É“–‚½‚Á‚½‚Æ‚«‚Ìˆ—
        if(collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
        }
    }

}
