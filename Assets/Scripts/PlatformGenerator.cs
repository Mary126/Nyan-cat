using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> platformPrefabs;
    public List<GameObject> milkPrefabs;
    public List<GameObject> foodPrefabs;
    public GameObject Platforms;
    public Instances instances;
    public int numOfPlatfX = 3;
    public int numOfPlatY = 10;
    private int xPos = 0;

    void GenerateMilk(GameObject Platform)
    {
        int milkCount = Random.Range(1, 4);
        for (int i = 0; i < milkCount; i++)
        {
            int j = Random.Range(0, milkPrefabs.Count);
            GameObject obj = Instantiate(milkPrefabs[j]);
            obj.transform.SetParent(Platforms.transform);
            float posY = Platform.GetComponent<RectTransform>().anchoredPosition.y + 70;
            float posX = Platform.GetComponent<RectTransform>().anchoredPosition.x - Platform.GetComponent<RectTransform>().sizeDelta.x / 2 + 30 + Platform.GetComponent<RectTransform>().sizeDelta.x / milkCount * i;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
            obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            obj.GetComponent<ItemMove>().instances = instances;
        }
    }
    void GenerateFood(GameObject Platform)
    {
        int foodCount = Random.Range(1, 4);
        for (int i = 0; i < foodCount; i++)
        {
            int j = Random.Range(0, foodPrefabs.Count);
            GameObject obj = Instantiate(foodPrefabs[j]);
            obj.transform.SetParent(Platforms.transform);
            float posY = Platform.GetComponent<RectTransform>().anchoredPosition.y + 70;
            float posX = Platform.GetComponent<RectTransform>().anchoredPosition.x - Platform.GetComponent<RectTransform>().sizeDelta.x / 2 + 20 + Platform.GetComponent<RectTransform>().sizeDelta.x/foodCount * i;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
            obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            obj.GetComponent<ItemMove>().instances = instances;
        }
    }
    void GeneratePlatform(int x, int y, int i)
    {        GameObject obj = Instantiate(platformPrefabs[i]);
        obj.transform.SetParent(Platforms.transform);
        float posY = Random.Range((instances.canvRT.sizeDelta.y / numOfPlatY) * y + 40, (instances.canvRT.sizeDelta.y / numOfPlatY) * (y + 1) - 45);
        float posX = Random.Range((instances.canvRT.sizeDelta.x / numOfPlatfX) * x + 250, (instances.canvRT.sizeDelta.x / numOfPlatfX) * (x + 1) - 250);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
        obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        obj.GetComponent<PlatformController>().instances = instances;
        obj.name = "platform" + x;
        int count = Random.Range(0, 4);
        if (count == 0)
        {
            GenerateMilk(obj);
        }
        else if (count == 1 || count == 2)
        {
            GenerateFood(obj);
        }
    }
    public void GeneratePlatforms()
    {
        int xBorder = xPos + numOfPlatfX;
        for (; xPos < xBorder; xPos++)
        {
            for (int y = 0; y < numOfPlatY; y++)
            {
                int i;
                if (y <= 3)
                {
                    i = Random.Range(0, platformPrefabs.Count);
                }
                else
                {
                    i = Random.Range(2, platformPrefabs.Count);
                }
                GeneratePlatform(xPos, y, i);
            }
        }
    }
}
