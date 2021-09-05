using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private RectTransform platformRT;
    public Instances instances;
    // Start is called before the first frame update
    void Start()
    {
        
        platformRT = GetComponent<RectTransform>();
    }
    void Bounce(PlayerController player)
    {
        player.jumpForce = 14f;
        instances.bounce.Play(0);
        player.Jump();
        player.jumpForce = 6f;
    }
    void Slide(PlayerController player)
    {
        player.jumpForce = 0f;
        player.gameObject.GetComponent<Animator>().Play("sliding");
    }
    void SlideExit(PlayerController player)
    {
        player.jumpForce = 6f;
        player.gameObject.GetComponent<Animator>().Play("running");
    }
    IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        yield return null;
    }
    void IncreaseScore()
    {
        instances.score = instances.score * 2;
        instances.scoreText.text = "Score: " + instances.score;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.enabled)
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            switch (tag)
            {
                case "platform2": Bounce(playerScript); break;
                case "platform3": StartCoroutine(DestroyPlatform()); break;
                case "platform4": Slide(playerScript); break;
                case "platform5": IncreaseScore(); break;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.enabled)
        {
            if (tag == "platform4")
            {
                SlideExit(collision.gameObject.GetComponent<PlayerController>());
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (platformRT.anchoredPosition.x <= instances.camRT.anchoredPosition.x - 1200)
        {
            Destroy(this.gameObject);
        }
    }
}
