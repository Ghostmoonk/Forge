using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PatternDifficulty
{
    EASY, NORMAL, HARD
}

public class ItemProvider : MonoBehaviour
{
    int maxItemsInQueue;
    int totalItemsInLevel;
    GameObject[] easyPatternPrefabs;
    GameObject[] normalPatternPrefabs;
    GameObject[] hardPatternPrefabs;

    GameObject itemsContainer;

    float offsetBetweenItems;

    private void Start()
    {
        itemsContainer = GameObject.FindGameObjectWithTag("ItemContainer");
    }

    public void InstantiateItem(PatternDifficulty difficulty)
    {
        GameObject patternToInstantiate;
        switch (difficulty)
        {
            case PatternDifficulty.EASY:
                patternToInstantiate = Instantiate(easyPatternPrefabs[Random.Range(0, easyPatternPrefabs.Length - 1)]);
                patternToInstantiate.transform.parent = itemsContainer.transform;
                _MGR_GameManager.Instance.AddItemPaternInQueue(patternToInstantiate.GetComponent<PatternItem>());
                break;
            case PatternDifficulty.NORMAL:
                patternToInstantiate = Instantiate(normalPatternPrefabs[Random.Range(0, normalPatternPrefabs.Length - 1)]);
                _MGR_GameManager.Instance.AddItemPaternInQueue(patternToInstantiate.GetComponent<PatternItem>());
                break;
            case PatternDifficulty.HARD:
                patternToInstantiate = Instantiate(hardPatternPrefabs[Random.Range(0, hardPatternPrefabs.Length - 1)]);
                _MGR_GameManager.Instance.AddItemPaternInQueue(patternToInstantiate.GetComponent<PatternItem>());
                break;
            default:
                break;
        }
    }
}
