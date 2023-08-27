using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CreateImage : MonoBehaviour
{
    public static void CreateImageObject(string objectName, Transform parentTransform, BaseUIComponent baseUIComponent, ImageProperties imageProperties)
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

        // Set Image UI properties based on JSON data
        Image image = uiElement.AddComponent<Image>();
        image.sprite = AssetDatabase.LoadAssetAtPath < Sprite > (AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets(imageProperties.sourceImage)[0]));
        image.color = imageProperties.color;
        image.raycastTarget = imageProperties.raycastTarget;
        image.raycastPadding = imageProperties.raycastPadding;
        image.preserveAspect = imageProperties.preserveAspect;
        image.maskable = imageProperties.maskable;
    }
}

[System.Serializable]
public class ImageProperties
{
    public string sourceImage;
    public Color color = new Color(1,1,1,1);
    public bool raycastTarget;
    public Vector4 raycastPadding;
    public bool preserveAspect;
    public bool maskable;
}