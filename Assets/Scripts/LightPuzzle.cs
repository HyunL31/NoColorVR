using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject building;
    [SerializeField] private List<GameObject> spawns;

    public float buildingMax = 3;
    public float buildingMin = -10;
    private bool buildingFlag = false;
    public GameObject player;
    public string PuzzleType = "Rising";
    public void BuildingUp()
    {
        if (buildingFlag == false)
            StartCoroutine(Uprise());
    }

    public void BuildingDown()
    {
        if (buildingFlag == false)
            StartCoroutine(Down());
    }

    private IEnumerator Uprise()
    {
        buildingFlag = true;
        while (building.transform.localPosition.y < buildingMax)
        {
            building.transform.Translate(Vector3.up * 0.01f);
            player.transform.Translate(Vector3.up * 0.01f);
            yield return null;
        }
        buildingFlag = false;
        yield break;
    }

    private IEnumerator Down()
    {
        buildingFlag = true;
        while (building.transform.localPosition.y > buildingMin)
        {
            building.transform.Translate(Vector3.down * 0.01f);
            player.transform.Translate(Vector3.down * 0.01f);
            yield return null;
        }
        buildingFlag = false;
        yield break;
    }

    public void SpawnObjects()
    {
        foreach (GameObject gameObject in spawns)
        {
            gameObject.SetActive(true);
        }
    }
}
