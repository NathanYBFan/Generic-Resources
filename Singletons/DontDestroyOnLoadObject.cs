using UnityEngine;

/// <summary>
/// Author: Nathan Fan
/// Description: Prevents any object this script is attached to from being destroyed when a new scene is loaded.
///
/// </summary>
public sealed class DontDestroyOnLoadObject : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}