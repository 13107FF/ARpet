using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject moodPanel;
    public GameObject foodPanel;
    public GameObject walkPanel;
    private GameObject currentPanel;
    private GoogleARCore.Examples.HelloAR.HelloARController ARController;

    public int strengthValue;
    public int moodValue;
    public static int threshold = 95;
    private float strengthTime = 4f;
    private float moodTime = 6f;

    // Start is called before the first frame update
    void Start()
    {
        homePanel.SetActive(true);
        moodPanel.SetActive(false);
        foodPanel.SetActive(false);
        walkPanel.SetActive(false);
        currentPanel = homePanel;
        strengthValue = 100;
        moodValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("HungryValue: " + (Time.time - count).ToString());
        if (Time.time >= strengthTime && strengthValue > 0)
        {
            Debug.Log("HungryValue: " + strengthValue.ToString());
            strengthValue--;
            strengthTime = Time.time + 4f;
        }
        if (Time.time >= moodTime && moodValue > 0)
        {
            Debug.Log("StrengthValue: " + moodValue.ToString());
            moodValue--;
            moodTime = Time.time + 4f;
        }


    }

    public void onHomeFoodButtonClicked()
    {
        currentPanel.SetActive(false);
        foodPanel.SetActive(true);
        currentPanel = foodPanel;
    }

    public void onHomeMoodButtonClicked()
    {
        currentPanel.SetActive(false);
        moodPanel.SetActive(true);
        currentPanel = moodPanel;
    }

    public void onHomeWalkButtonClicked()
    {
        currentPanel.SetActive(false);
        walkPanel.SetActive(true);
        currentPanel = walkPanel;
    }

    public void onHomeHungryMoodButtonClicked()
    {
 
    }
    public void onHomeHungryWalkButtonClicked()
    {

    }

    public void onHomeHouseButtonClicked()
    {
        //啥啊这
    }

    public void onFoodFoodButtonClicked()
    {
        ARController = GameObject.Find("HelloAR Controller").GetComponent<GoogleARCore.Examples.HelloAR.HelloARController>();
        ARController.SetModel = "food";
        Debug.Log("eating clicked");
    }

    public void onMoodMoodButtonClicked()
    {
        ARController = GameObject.Find("HelloAR Controller").GetComponent<GoogleARCore.Examples.HelloAR.HelloARController>();
        ARController.SetModel = "toy";
        Debug.Log("playing clicked");
    }

    public void onbackButtonClilcked()
    {
        currentPanel.SetActive(false);
        homePanel.SetActive(true);
        currentPanel = homePanel;
    }
}
