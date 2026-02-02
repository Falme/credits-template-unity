[README PT-BR](https://github.com/Falme/credits-template-unity/blob/main/README.md) 👈

[Godot Engine Edition](https://github.com/Falme/credits-template-godot/) 👈

# Credits Template : Unity Edition

A Template of Credits Interface for your game (in Unity) loaded from a JSON.

---

## Why?

Every game should have a credits screen, even if the game was developed by one person, the creators of the media should be credited. The problem is that we always need to create a new scene for credits in each game, and the credits screen is always different, because each game is different.

So, with that in mind, I didn't create a proper scene for the credits, but an interface template for easy ready-to-go credits.

## Quickstart

Download the latest `Credits-Unity-x-x-x.unitypackage` at the [Releases Page](https://github.com/Falme/credits-template-unity/releases) and import it to your project by: 
- Clicking twice the unitypackage file, or
- Inside Unity go to `Assets > Import Package > Custom Package` and select the unitypackage file.

You should have two new folders in the following paths: 
- `Assets/Credits_Template`
- `Assets/StreamingAssets/Credits`

Now, if you want an example of how it works, I have a scene at `Credits_Template/Scenes/Credits_Example.unity` (if you prefer to learn by example).

Either way, the template can be found at `Credits_Template/prefabs/Credits_Canvas.prefab`, this is the main template. To use it, just drop into a scene or as a child of a Canvas gameobject, because the template is 100% interface Canvas/UI.

To change the content in the credits roll, you will need to change the JSON file at `Credits_Template/Data/credits.json`. I decided to put the information in a json file, so not only the devs could modify the file, but anyone from the team.

> **IMPORTANT**: The dimensions of EVERYTHING is defined by the canvas component "Canvas Scaler", you must define a Reference Resolution for your game and font size. 

The next section we will be explaining in more details the JSON structure.

## JSON Structure

I will write down an example of credits, and explain with more details each one of them.

```json
{
	"version": "0.0.1",
	"velocity": 100.0,
	"items": [
		{
			"type": "title",
			"text": "Super Jump Game 2: \nThe Electric Boogaloo"
		},
		{
			"type": "space",
			"height": 100.0
		},
		{
			"type": "image", 
			"path": "Credits/example_image.png", 
			"height": 400
		},
		{
			"type": "category",
			"text": "Created By"
		},
		{
			"type": "actor",
			"actors": [
				"Falme Streamless"
			]
		},
		{
			"type": "space",
			"height": 100.0
		},
		{
			"type": "category",
			"text": "Special Thanks"
		},
		{
			"type": "actor",
			"actors": [
				"Alex Arroyo",
				"Danilo Cavedon",
				"Ruan Lima",
				"And everyone who shared this project!"
			]
		}
	]
}
```

From top to bottom, we will explain each field.

- version : If you want to track the credits version for your game (doesn't show on screen)
- velocity : Velocity of the credits scrolling, speed of movement
- items : Array of each item object that can be added to the credits
	- title : Special text, usually first field of credits and normally the name of the game
	- image : An image to be added to the credits
		- path : Address/path to the image (base is "Assets/StreamingAssets/")
		- height : height of the image to be displayed, width is proportional to the original size
    - space : empty space, a margin between a label and other label
		- height : height of the space to be displayed
    - category : the role title
	- actor : Names, those who worked in the project at the specified role above
		- actors : Array of names, try not putting too many names in one array, divide for better performance
