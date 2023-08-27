using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEmptyElement : BaseUIComponent
{
    public static void CreateEmptyObject(string objectName, Transform parentTransform, BaseUIComponent baseUIComponent)
    {
        // Instantiate UI element from prefab
        GameObject uiElement = new GameObject(objectName);

        // Set UI properties based on JSON data
        RectTransform uiRectTransform = uiElement.AddComponent<RectTransform>();
        uiRectTransform.SetParent(parentTransform);

        uiRectTransform.anchoredPosition = baseUIComponent.anchoredPosition;
        uiRectTransform.sizeDelta = baseUIComponent.sizeDelta;
        uiRectTransform.anchorMin = baseUIComponent.anchorMin;
        uiRectTransform.anchorMax = baseUIComponent.anchorMax;
        uiRectTransform.pivot = baseUIComponent.pivot;
        uiRectTransform.localPosition = baseUIComponent.position;
        uiRectTransform.localRotation = Quaternion.Euler(baseUIComponent.rotation);
        uiRectTransform.localScale = baseUIComponent.scale;
    }
}
