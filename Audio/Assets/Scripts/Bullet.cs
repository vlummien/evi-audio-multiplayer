using System.Collections;
using System.Collections.Generic;
using QuickStart;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerScript playerScript;

    public void setPlayerScript(PlayerScript _playerScript)
    {
        playerScript = _playerScript;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            playerScript.RpcBulletHitTarget();
        }
        
    }
    
}
