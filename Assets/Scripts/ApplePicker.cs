using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    public List<GameObject> basketList;

    private void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasket = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasket.transform.position = pos;

            basketList.Add(tBasket);
        }
    }

    public void AppleDetroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in tAppleArray)
            Destroy(apple);

        int basketIndex = basketList.Count - 1;
        GameObject basket = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basket);

        if (basketList.Count == 0)
            SceneManager.LoadScene("Scene_0");
    }

    

}
