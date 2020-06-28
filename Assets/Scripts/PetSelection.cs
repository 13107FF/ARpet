using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetSelection : MonoBehaviour
{
    public GameObject[] petPrefabs; //用于存放宠物数组
    private int selectedIndex = 0; //创建选择索引的变量
    public static GameObject selectedPet;
    // Start is called before the first frame update
    void Start()
    {
        petShow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void petShow()
    {
        petPrefabs[selectedIndex].SetActive(true);
        selectedPet = petPrefabs[selectedIndex];
        Debug.Log("PetShow: "+selectedIndex.ToString());
        for (int i = 0; i < petPrefabs.Length; i++)
            if (i != selectedIndex)
                petPrefabs[i].SetActive(false);
    }



    public void onLeftButtonClick()
    {
        selectedIndex--;
        if (selectedIndex == -1)
            selectedIndex = petPrefabs.Length - 1;
        petShow();
        Debug.Log("Left was clicked!");
    }

    public void onRightButtonClick()
    {
        selectedIndex++;
        selectedIndex %= petPrefabs.Length;
        petShow();
        Debug.Log("Right was clicked!");
    }
}
