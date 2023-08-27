# Custom Tool for Creating UI

The Editor window tool is created for creating UI in Hierarchy using JSON code. Steps to use this tool:

## Step 1. 
Navigate to Window > JSON Editor. You will see the editor window.

## Step 2. 
You will see JSON Editor Window.

Step 3.
Add path of JSON file or create new JSON file. 
For loading JSON file, Add path in “JSON File Path” and click on Load JSON Button.
For creating new add JSON code and click on Save JSON button. The JSON file will be saved on a given path.

Step 4. 
For generating UI you have to click on the Use JSON button. Then UI will be created if the JSON code is valid.

Step 5. 
If you want to customize scaling, position and rotation of the created object. Then select the object in the “Object to Customize” variable and add new values. By default all values will be 0. Then click on Apply Customization Button. 

# Format of JSON File
The JSON file for generating UI should be in this format:

{
	"templates":
	[{
		"templateType": 0,
		"templateName": "Template1",
		"parentID": "Root",
		"uiProperties":
		{
                  		 "anchoredPosition": { "x": 100.0,"y": 100.0},
    			 "sizeDelta": ": { "x": 100.0,"y": 100.0},
    			 "anchorMin":": { "x": 100.0,"y": 100.0},
    			"anchorMax": ": { "x": 100.0,"y": 100.0},
    			"pivot": ": { "x": 100.0,"y": 100.0},
   			 "position":": { "x": 100.0,"y": 100.0},
    			"rotation": ": { "x": 100.0,"y": 100.0},
    			"scale":": { "x": 100.0,"y": 100.0}
}
},
{
		"templateType": 2,
		"templateName": "Template2",
		"parentID": "Template1",
		"uiProperties":
		{
 "anchoredPosition": { "x": 100.0,"y": 100.0},
    			 "sizeDelta": ": { "x": 100.0,"y": 100.0},
    			 "anchorMin":": { "x": 100.0,"y": 100.0},
    			"anchorMax": ": { "x": 100.0,"y": 100.0},
    			"pivot": ": { "x": 100.0,"y": 100.0},
   			 "position":": { "x": 100.0,"y": 100.0},
    			"rotation": ": { "x": 100.0,"y": 100.0},
    			"scale":": { "x": 100.0,"y": 100.0}
},
  		"imageProperties": 
		{
    			"sourceImage": "qualcycle",
    			"color": { "r": 1.0,"g": 1.0, "b": 1.0, "a": 1.0 },
    			"raycastTarget": true,
   		 	"raycastPadding": {"x": 0.0, "y": 0.0, "z": 0.0, "w": 0.0}
   		 	"preserveAspect": false,
   			"maskable": true
}
},
{
		"templateType": 1,
		"templateName": "Template3",
		"parentID": "Template2",
		"uiProperties":
		{
 "anchoredPosition": { "x": 100.0,"y": 100.0},
    			 "sizeDelta": ": { "x": 100.0,"y": 100.0},
    			 "anchorMin":": { "x": 100.0,"y": 100.0},
    			"anchorMax": ": { "x": 100.0,"y": 100.0},
    			"pivot": ": { "x": 100.0,"y": 100.0},
   			 "position":": { "x": 100.0,"y": 100.0},
    			"rotation": ": { "x": 100.0,"y": 100.0},
    			"scale":": { "x": 100.0,"y": 100.0}
},
 		 "textProperties": 
{
"sourceFont": "FontName",   
 "textData": "Hello, World!",
   			 "fontStyle": 0,
   			 "fontSize": 24,
   			 "lineSpacing": 0,
    			"bestFit": false,
   			"color": { "r": 1.0,"g": 1.0, "b": 1.0, "a": 1.0 },
   			 "raycastTarget": true,
    			"raycastPadding": {"x": 0.0, "y": 0.0, "z": 0.0, "w": 0.0},
    			"maskable": true
}
}]
}


# Note

“uiProperties” is used for give rectTransform values for creating empty game object.
If any other UI component needs to be added then use  “imageProperties” or “textProperties”.
All the required values for components are added in JSON.
 “templateType” is used for setting type of object 0 for empty, 1 for text and 2 for image. Further can be added accordingly.
“templateName” will be used for naming the ui object. 
“parentID” gives the name for parent, so that object will be searched and assigned as a parent for the created ui object.
