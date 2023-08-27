using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections.Generic;

public class JsonEditorWindow : EditorWindow
{
    private string jsonFilePath;
    private string jsonContent;
    private GameObject selectedObject;
    private Vector3 customizationPosition;
    private Vector3 customizationRotation;
    private Vector3 customizationScale;


    [MenuItem("Window/JSON Editor")]
    public static void ShowWindow()
    {
        GetWindow<JsonEditorWindow>("JSON Editor");
    }

    private void OnGUI()
    {
        jsonFilePath = EditorGUILayout.TextField("JSON File Path", jsonFilePath); // path for json file

        GUILayout.Label("JSON Editor", EditorStyles.boldLabel);

        if (GUILayout.Button("Load JSON"))
        {
            LoadJSON();
        }

        jsonContent = EditorGUILayout.TextArea(jsonContent, GUILayout.Height(position.height - 300));

        if (GUILayout.Button("Save JSON"))
        {
            SaveJSON();
        }

        if (GUILayout.Button("Use JSON Data"))
        {
            UseJSONData();
        }

        GUILayout.Space(20);
        
        //Showing Customization elements
        selectedObject = EditorGUILayout.ObjectField("Object for Customization ", selectedObject, typeof(GameObject), true) as GameObject;
        customizationPosition = EditorGUILayout.Vector3Field("Position", customizationPosition);
        customizationRotation = EditorGUILayout.Vector3Field("Rotation", customizationRotation);
        customizationScale = EditorGUILayout.Vector3Field("Scale", customizationScale);

        if (GUILayout.Button("Apply Customization"))
        {
            ApplyCustomization();
        }
    }

    //Method to Load JSON.
    private void LoadJSON()
    {
        if (File.Exists(jsonFilePath))
        {
            jsonContent = File.ReadAllText(jsonFilePath);
        }
        else
        {
            Debug.LogWarning("JSON file not found.");
            jsonContent = "";
        }
    }

    /// <summary>
    /// Method to save JSON.
    /// </summary>
    private void SaveJSON()
    {
        File.WriteAllText(jsonFilePath, jsonContent);
        Debug.Log("JSON data saved.");
    }

    /// <summary>
    /// Method to Use JSON for Creating UI.
    /// </summary>
    private void UseJSONData()
    {
        

        if (!string.IsNullOrEmpty(jsonContent))
        {
            try
            {
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonContent);
                CreateUIFromUserJSON(myDeserializedClass);
            }
            catch
            {
                Debug.Log("JSON is not Valid. Please Check it.");
            }
        }
        else
        {
            Debug.LogWarning("JSON data is empty.");
        }
    }

    /// <summary>
    /// Method to Create UI from given JSON data.
    /// </summary>
    /// <param name="uiData"></param>
    private void CreateUIFromUserJSON(Root uiData)
    {
        // Create Canvas
        GameObject canvasGO = new GameObject("Root");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
        CanvasScaler canvasScaler = canvasGO.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(1920, 1080);
        canvasScaler.matchWidthOrHeight = .5f;
        canvasGO.AddComponent<GraphicRaycaster>();

        //Creating UI EleemntsSS
        foreach (var element in uiData.templates)
        {
            Transform parentTransform;
            if (element.parentID == "Root")
                parentTransform = canvasGO.transform;
            else
                parentTransform = FindObjectInHierarchy(element.parentID).transform;

            Debug.Log(parentTransform);

            switch ((ComponentType)element.templateType)
            {
                case ComponentType.empty:
                    CreateEmptyElement.CreateEmptyObject(element.templateName, parentTransform, element.uiProperties);
                    break;

                case ComponentType.image:
                    CreateImage.CreateImageObject(element.templateName, parentTransform, element.uiProperties, element.imageProperties);
                    break;

                case ComponentType.text:
                    CreateText.CreatetTextObject(element.templateName, parentTransform, element.uiProperties, element.textProperties);
                    break;

                //can add more conditions
            }
        }
    }

    /// <summary>
    /// Method to apply customized values for selected object.
    /// </summary>
    private void ApplyCustomization()
    {
        if (selectedObject != null)
        {

            selectedObject.transform.localPosition = customizationPosition;
            selectedObject.transform.localRotation = Quaternion.Euler(customizationRotation);
            selectedObject.transform.localScale = customizationScale;

            // Mark the object as dirty to ensure changes are saved
            EditorUtility.SetDirty(selectedObject);
        }
    }

    GameObject FindObjectInHierarchy(string name)
    {
        Transform[] allTransforms = FindObjectsOfType<Transform>();

        foreach (Transform transform in allTransforms)
        {
            if (transform.name == name)
            {
                return transform.gameObject;
            }
        }

        return null;
    }
}

//For selecting UI Types
public enum ComponentType
{
    empty,
    text,
    image,
    button
    //add more ui elements
}

//Root Class for JSON Data
[System.Serializable]
public class Root
{
    public List<Template> templates;
}

[System.Serializable]
public class Template
{
    public int templateType;
    public string templateName;
    public string parentID;
    public BaseUIComponent uiProperties;
    public ImageProperties imageProperties;
    public TextProperties textProperties;
}

