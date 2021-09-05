using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instances : MonoBehaviour
{
    public GameObject generate;
    public GameObject Player;
    public GameObject manage;
    public Canvas canv;
    [System.NonSerialized] public RectTransform canvRT;
    [System.NonSerialized] public GameManager manager;
    public UnityEngine.UI.Text scoreText;
    [System.NonSerialized] public RectTransform PlayerRT;
    [System.NonSerialized] public PlatformGenerator generator;
    public AudioSource pickMilk;
    public AudioSource pickFood;
    public Camera cam;
    [System.NonSerialized] public RectTransform camRT;
    public AudioSource bounce;
    public long score = 0;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Awake()
    {
        generator = generate.GetComponent<PlatformGenerator>();
        PlayerRT = Player.GetComponent<RectTransform>();
        camRT = cam.GetComponent<RectTransform>();
        manager = manage.GetComponent<GameManager>();
        canvRT = canv.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
