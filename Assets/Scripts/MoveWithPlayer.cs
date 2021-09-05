using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public GameObject Player;
    PlayerController playerScript;
    RectTransform objectToMoveRT;
    // Start is called before the first frame update
    void Start()
    {
        if (Player)
        {
            playerScript = Player.GetComponent<PlayerController>();
        }
        objectToMoveRT = GetComponent<RectTransform>();
    }
    void Move()
    {
        if (playerScript && playerScript.isPlaying)
        {
            objectToMoveRT.anchoredPosition = new Vector2(Player.GetComponent<RectTransform>().anchoredPosition.x, Player.GetComponent<RectTransform>().anchoredPosition.y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
