using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal2 : MonoBehaviour
{
    [SerializeField] GameObject m_nextLevelScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.hasWon = true;
            m_nextLevelScreen.SetActive(true);
        }
    }

}
