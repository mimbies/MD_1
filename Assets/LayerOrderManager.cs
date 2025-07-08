using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrderManager : MonoBehaviour
{
    [SerializeField] private GameObject props;

    private void Start()
    {
        List<GameObject> stuff = AllChilds(props);

        foreach (GameObject prop in stuff)
        {
            if (prop.GetComponent<SpriteRenderer>() != null)
            {
                prop.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(prop.transform.position.y * 10f) * -1;
            }
        }
    }

    private List<GameObject> AllChilds(GameObject root)
    {
        List<GameObject> result = new List<GameObject>();
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(result, VARIABLE.gameObject);
            }
        }
        return result;
    }

    private void Searcher(List<GameObject> list, GameObject root)
    {
        list.Add(root);
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(list, VARIABLE.gameObject);
            }
        }
    }

}
