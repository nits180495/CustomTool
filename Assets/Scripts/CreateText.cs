using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CreateText : MonoBehaviour
{

    public static void CreatetTextObject(string objectName, Transform parentTransform, BaseUIComponent baseUIComponent, TextProperties textProperties)
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
        Text text = uiElement.AddComponent<Text>();

        string[] assetData = AssetDatabase.FindAssets(textProperties.sourceFont);
        Font fontAsset = null;

        if (assetData.Length>0)
            fontAsset  = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets(textProperties.sourceFont)[0]));

        if (fontAsset != null)
            text.font = fontAsset;

        text.text = textProperties.textData;
        text.fontStyle = (FontStyle)textProperties.fontStyle;
        text.fontSize = textProperties.fontSize;
        text.lineSpacing = textProperties.lineSpacing;
        text.resizeTextForBestFit = textProperties.bestFit;
        text.color = textProperties.color;
        text.raycastTarget = textProperties.raycastTarget;
        text.raycastPadding = textProperties.raycastPadding;
        text.maskable = textProperties.maskable;
    }
}

[System.Serializable]
public class TextProperties
{
    public string sourceFont;
    public string textData;
    public int fontStyle;
    public int fontSize;
    public int lineSpacing;
    public bool bestFit;
    public Color color = new Color(1, 1, 1, 1);
    public bool raycastTarget;
    public Vector4 raycastPadding;
    public bool maskable;
}
