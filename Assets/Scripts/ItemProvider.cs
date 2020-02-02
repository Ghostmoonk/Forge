using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PatternDifficulty
{
    EASY, NORMAL, HARD
}

public class ItemProvider : MonoBehaviour
{
    public int maxItemsInQueue;
    public int totalItemsInLevel;
    public int remainingItemsInLevel;
    [SerializeField] GameObject[] easyPatternPrefabs;
    [SerializeField] GameObject[] normalPatternPrefabs;
    [SerializeField] GameObject[] hardPatternPrefabs;

    [SerializeField] Transform spawnPosition;
    GameObject itemsContainer;

    [SerializeField] float offsetBetweenItems;

    private void Start()
    {
        itemsContainer = GameObject.FindGameObjectWithTag("ItemContainer");
        remainingItemsInLevel = totalItemsInLevel - itemsContainer.transform.childCount;
    }

    private void Update()
    {
        if (Mathf.Abs(spawnPosition.transform.position.x - itemsContainer.transform.GetChild(itemsContainer.transform.childCount - 1).transform.position.x) > offsetBetweenItems)
        {
            if (remainingItemsInLevel > 0)
            {
                //Debug.Log("I must intantiate !");
                InstantiateItem(PickRandomDifficulty());
                remainingItemsInLevel--;
            }
        }
    }

    private PatternDifficulty PickRandomDifficulty()
    {
        int randomPick = Random.Range(0, 100);
        if (remainingItemsInLevel > totalItemsInLevel * 2 / 3)
        {
            if (randomPick < 70)
            {
                return PatternDifficulty.EASY;
            }
            else if (randomPick < 90)
            {
                return PatternDifficulty.NORMAL;
            }
            else
            {
                return PatternDifficulty.HARD;
            }
        }
        else if (remainingItemsInLevel > totalItemsInLevel * 1 / 2)
        {
            if (randomPick < 40)
            {
                return PatternDifficulty.EASY;
            }
            else if (randomPick < 80)
            {
                return PatternDifficulty.NORMAL;
            }
            else
            {
                return PatternDifficulty.HARD;
            }
        }
        else
        {
            if (randomPick < 20)
            {
                return PatternDifficulty.EASY;
            }
            else if (randomPick < 60)
            {
                return PatternDifficulty.NORMAL;
            }
            else
            {
                return PatternDifficulty.HARD;
            }
        }
    }

    public void InstantiateItem(PatternDifficulty difficulty)
    {
        GameObject patternToInstantiate;
        switch (difficulty)
        {
            case PatternDifficulty.EASY:
                patternToInstantiate = Instantiate(easyPatternPrefabs[Random.Range(0, easyPatternPrefabs.Length - 1)], spawnPosition.position, Quaternion.identity, itemsContainer.transform);
                _MGR_GameManager.Instance.AddItemPaternInQueue(patternToInstantiate.GetComponent<PatternItem>());
                break;
            case PatternDifficulty.NORMAL:
                patternToInstantiate = Instantiate(normalPatternPrefabs[Random.Range(0, normalPatternPrefabs.Length - 1)], spawnPosition.position, Quaternion.identity, itemsContainer.transform);
                _MGR_GameManager.Instance.AddItemPaternInQueue(patternToInstantiate.GetComponent<PatternItem>());
                break;
            case PatternDifficulty.HARD:
                patternToInstantiate = Instantiate(hardPatternPrefabs[Random.Range(0, hardPatternPrefabs.Length - 1)], spawnPosition.position, Quaternion.identity, itemsContainer.transform);
                _MGR_GameManager.Instance.AddItemPaternInQueue(patternToInstantiate.GetComponent<PatternItem>());
                break;
            default:
                break;
        }
    }
}
