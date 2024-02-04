using UnityEngine;
using System.Collections.Generic;

public class DontDestroyOnLoadManager : MonoBehaviour
{
    public GameObject[] objectsToPersist;

    private void Awake()
    {
        if (!HasDuplicates(objectsToPersist))
        {
            foreach (GameObject obj in objectsToPersist)
            {
                DontDestroyOnLoad(obj);
            }
        }

    }

     private bool HasDuplicates(GameObject[] array)
    {
        HashSet<GameObject> uniqueObjects = new HashSet<GameObject>();
        foreach (GameObject obj in array)
        {
            if (obj == null)
            {
                continue;
            }

            if (!uniqueObjects.Add(obj))
            {
                return true;
            }
        }
        return false;
    }
}
