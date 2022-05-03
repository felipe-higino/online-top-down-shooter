using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class _ComponentResolveExtension
{
    /// <summary>
    /// <see cref="GameObject.GetComponent{T}"/> with log error  
    /// </summary>
    public static T ResolveComponent<T>(this GameObject gameObject) where T : Component
    {
        var component = gameObject.GetComponent<T>();
        if (null == component)
        {
            Debug.LogError($"Fail to get component of type {component.GetType()}");
            return null;
        }
        return component;
    }
}
