using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private RectTransform itemRT;
    public Instances instances;
    
    private bool down = true;
    void Move()
    {
        if (down)
        {
            itemRT.anchoredPosition = new Vector2(itemRT.anchoredPosition.x, itemRT.anchoredPosition.y - 10);
            down = false;
        }
        else
        {
            itemRT.anchoredPosition = new Vector2(itemRT.anchoredPosition.x, itemRT.anchoredPosition.y + 10);
            down = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        itemRT = GetComponent<RectTransform>();
        InvokeRepeating("Move", 0.09f, 0.2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (tag) {
            case "food": instances.manager.RenewScore(1000); instances.pickFood.Play(0); break;
            case "milk0": instances.manager.RenewScore(5000); instances.pickMilk.Play(0); break;
            case "milk1": instances.manager.RenewScore(10000); instances.pickMilk.Play(0); break;
            case "milk2": instances.manager.RenewScore(25000); instances.pickMilk.Play(0); break;
            case "milk3": instances.manager.RenewScore(50000); instances.pickMilk.Play(0); break;
        }
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (itemRT.anchoredPosition.x <= instances.camRT.anchoredPosition.x - 1200)
        {
            Destroy(this.gameObject);
        }
    }
}
