# Unity Game Save System

## Project Description
The Unity Game Save System is a comprehensive solution designed for Unity developers to easily implement saving and loading of game states. This system allows for the serialization and deserialization of game data, including complex data types like `Vector3`. It leverages JSON for storage, making the save files easy to read and manage.

### Dependencies
- Newtonsoft.Json for JSON serialization and deserialization

## How to Install and Run the Project
1. Ensure you have Unity (version to be specified) installed on your machine.
2. Download or clone the project repository to your local machine.
3. Open the project in Unity by selecting `Open Project` and navigating to the project directory.
4. (Optional) If provided, import the `.unitypackage` file via `Assets` > `Import Package` > `Custom Package...` in Unity.

## How To Use
1. **Implement ISaveable Interface:** Ensure that all objects you wish to save implement the `ISaveable` interface. This requires methods for saving and loading data, as well as a unique save ID for each object.
2. **Create Data Storage Structures:** Define a data structure, such as a struct or class, to store the relevant data of your saveable objects. For example, create a `PlayerData` struct to hold player-specific information.
   
   ```csharp
   [System.Serializable]
   public struct PlayerData
   {
       public float health;
       public float experience;
       public Vector3 position;

       public PlayerData(float health, float experience, Vector3 position)
       {
           this.health = health;
           this.experience = experience;
           this.position = position;
       }
   }

3. **Register Saveable Objects:** In the `Awake` or `Start` method of your saveable objects, register them with the `SaveManager` by calling `SaveManager.RegisterSaveable(this)`.
4. **Implement Save and Load Logic:** In the class of your saveable object, implement the Save and Load methods to handle the conversion to and from the data storage structure. For example, for a Player class:

   ```csharp
   public class Player : MonoBehaviour, ISaveable
   {
       public float health;
       public float experience;
       public Vector3 position;

       public string GetSaveID() => gameObject.name; // Unique identifier for the saveable entity

       private void Awake()
       {
           SaveManager.RegisterSaveable(this);
       }
   
       public object Save()
       {
           return new PlayerData(health, experience, position);
       }
    
       public void Load(object saveData)
       {
           var playerData = (PlayerData)saveData;
           health = playerData.health;
           experience = playerData.experience;
           position = playerData.position;
       }
    
       public Type GetDataType() => typeof(PlayerData);
   }

5. **Save Game Data:** Call `SaveManager.SaveGame()` to save the current game state. This will iterate through all registered saveable objects and store their data in a JSON file.
6. **Load Game Data:** Call `SaveManager.LoadGame()` to load the saved game state. This will read the JSON file and restore the saved state to all registered saveable objects.

### Notes
- Ensure that the directory for save files exists and is accessible by the application.
- Use the `Vector3Json` and `Vector3JsonConverter` classes to handle Unity's `Vector3` type, which is not natively serializable in JSON format.

Feel free to extend and modify the system to fit the needs of your specific project.
