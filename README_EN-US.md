[README PT-BR](https://github.com/Falme/credits-template-unity/blob/main/README.md) 👈

[Godot Engine Edition](https://github.com/Falme/credits-template-godot/) 👈

# Credits Template : Unity Edition

A Template of Credits Interface for your game (in Unity) with the informations being loaded from a JSON.

---

## Why?

Every game should have a credits screen, even if the game was developed by one person, the creators of the media should be credited. The problem is that we always need to create a new scene for credits in each game, and the credits screen is always different, because each game is different.

So, with that in mind, I didn't create a proper scene for the credits, but an interface template for easy ready-to-go credits.

## Quickstart

Download the latest `Credits-Unity-x-x-x.unitypackage` at the [Releases Page](https://github.com/Falme/credits-template-unity/releases) and import it to your project by 
- Clicking twice the unitypackage file, or
- Inside Unity go to `Assets > Import Package > Custom Package` and select the unitypackage file.

You should have a new folder in the following path: `Assets/Credits_Template`.

Now, if you want an example of how it works, I have a scene at `Credits_Template/Scenes/Credits_Example.unity` (if you prefer to learn by example).

Either way, the template can be found at `Credits_Template/prefabs/Credits_Canvas.prefab`, this is the main template. To use it, just add it as a Canvas or a child of a Canvas gameobject, because the template is 100% interface Canvas/UI.

To change the content in the credits roll, you will need to change the JSON file at `Credits_Template/Data/credits.json`. I decided to put the information in a json file, so not only the devs could modify the file, but anyone from the team.

> **IMPORTANT**: The dimensions of EVERYTHING is defined by the canvas component "Canvas Scaler", you must define a Reference Resolution for your game and font size. 

To quick explain each field:

- title : Title of the credits scene, normally the name of the game
- category : Category or Job name (example: Producers)
- actors : Name of the person to be listed (example: Jane Doe)
- spacing : Margin/space between names and roles
- image : Images in the middle of the credits, like logos and photos

The next section we will be explaining in more details the JSON structure.

## JSON Structure

I will write down an example of credits, and explain with more details each one of them.

```json
{
	"version": "0.1.0",
	"velocity": 100.0,
	"title": "Super Jump Game 2: \nThe Electric Boogaloo",
	"items": [
		{
			"image": true,
			"path": "credits-template/sprites/example_image.png",
			"height": 400.0
		},
		{
			"space": true,
			"height": 400.0
		},
		{
			"category": true,
			"text": "Director",
			"categorySpacing": 100.0,
			"actorsSpacing": 50.0,
			"actors": [
				"John Doe",
				"Jane Doe",
				"Oscar Garlic"
			]
		},
		{
			"space": true,
			"height": 200.0
		},
		{
			"category": true,
			"text": "Producers",
			"categorySpacing": 100.0,
			"actorsSpacing": 10.0,
			"actors": [
				"John Doe",
				"Jane Doe",
				"Oscar Garlic"
			]
		}
	]
}
```

From top to bottom, we will explain each field.

- velocity : Velocity of the credits scrolling, speed of movement
- title : First field of credits, normally the name of the game
- items : Array of each item object that can be added to the credits
	- image : An image to be added to the credits
		- path : Address/path to the image (base is "Assets/StreamingAssets/")
		- height : height of the image to be displayed, width is proportional to the original size
    - space : empty space, a margin between a label and other label
		- height : height of the space to be displayed
    - category : the role title
		- categorySpacing : Empty space between role and actors
		- actorsSpacing : Empty space between actors and actors
		- actors : Names, those who worked in the project at the specified role above

## Newtonsoft JSON DLL

Maybe you will receive an error about JSON Newtonsoft, this can happen for 3 reasons:

- You didn't import the plugin folder when importing the unitypackage, missing the Newtonsoft.JSON dll
- You DID import the plugin folder, but you have another Newtonsoft.JSON dll in your project, making a conflict
- The CSharpMonoBehaviour is not finding the DLL, if you are using Assembly Definitions, just add a reference of Newtonsoft plugin to your Asmdef file.

Because of problems with Json reading and parsing, I injected Newtonsoft.JSON to the unitypackage.
