using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    [SerializeField] private List<GameObject> lights;
    [SerializeField] private List<GameObject> keyAndClue;

    public void TurnOnLight(int index)
    {
        if (!lights[index].activeSelf)
        {
            lights[index].SetActive(true);
            CheckLight(index);
        }
    }

    private void CheckLight(int index)
    {
        if (index > 0)
        {
            if (!lights[index - 1].activeSelf)
            {
                for (int i = 0; i < lights.Count; i++)
                {
                    if (i != index)
                        lights[i].SetActive(false);
                    else StartCoroutine(TurnOffAfterDelay(lights[i], 1f));
                }
            }
        }
        if (index == lights.Count - 1) // check all lights are activate
        {
            bool allOn = true;
            foreach (GameObject light in lights)
            {
                if (!light.activeSelf)
                {
                    allOn = false;
                    break;
                }
            }

            if (allOn == true)
            {
                foreach (GameObject item in keyAndClue)
                {
                    item.SetActive(true);
                }
            }
        }
    }

    private IEnumerator TurnOffAfterDelay(GameObject light, float delay)
    {
        yield return new WaitForSeconds(delay);
        light.SetActive(false);
        yield break;
    }
}
