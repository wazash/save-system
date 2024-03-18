using System;
using UnityEngine;
using Wazash.Save;

// This struct is used to save the player's data.
// If you want to save more data, you can add more fields to this struct.
public struct PlayerData
{
    public string name;
    public int health;
    public int mana;
    public int level;
}

public class Player : MonoBehaviour, ISaveable
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Mana { get; private set; }
    [field: SerializeField] public int Level { get; private set; }

    [SerializeField] private ViewManager viewManager;

    private void Awake()
    {
        viewManager.UpdateView(this);

        // Register the player to the SaveManager. This will allow the SaveManager to save and load the player's data.
        SaveManager.RegisterSaveable(this);
    }

    #region Players Methods
    public void SetName(string name)
    {
        Name = name;
        viewManager.UpdateView(this);
    }
    public void AddHealth()
    {
        Health++;
        viewManager.UpdateView(this);
    }
    public void RemoveHealth()
    {
        Health--;
        viewManager.UpdateView(this);
    }
    public void AddMana()
    {
        Mana++;
        viewManager.UpdateView(this);
    }
    public void RemoveMana()
    {
        Mana--;
        viewManager.UpdateView(this);
    }
    public void AddLevel()
    {
        Level++;
        viewManager.UpdateView(this);
    }
    public void RemoveLevel()
    {
        Level--;
        viewManager.UpdateView(this);
    } 
    #endregion

    #region Saving
    // These methods are required by the ISaveable interface. They are used to save and load the player's data.
    // In this case, the player data is saved to a struct called PlayerData.'
    public Type GetDataType() => typeof(PlayerData);

    // This method is used to get the ID of the player. This ID is used to save and load the player's data.
    // If you have multiple objects of the same type, you can use this method to differentiate between them.
    public string GetSaveID() => "Player";

    // This method is used to save the player's data. It returns an object, which is the data that will be saved.
    // In this case, the player's data is saved to a PlayerData struct.
    public object Save()
    {
        return new PlayerData
        {
            name = Name,
            health = Health,
            mana = Mana,
            level = Level
        };
    }

    // This method is used to load the player's data. It takes an object as a parameter, which is the data that was saved.
    // In this case, the data is cast to a PlayerData struct. 
    // The data is then used to set the player's properties.
    public void Load(object saveData)
    {
        var data = (PlayerData)saveData;

        Name = data.name;
        Health = data.health;
        Mana = data.mana;
        Level = data.level;

        viewManager.UpdateView(this);
    }

    #endregion
}
