using UnityEngine;
using Wazash.Save;

public class SavingManager : MonoBehaviour
{
    public void Save()
    {
        SaveManager.SaveGame();
    }

    public void Load()
    {
        SaveManager.LoadGame();
    }
}
