using TMPro;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text playerHealth;
    [SerializeField] private TMP_Text playerMana;
    [SerializeField] private TMP_Text playerLevel;

    public void UpdateView(Player player)
    {
        playerName.text = $"Name: {player.Name}";
        playerHealth.text = $"Health: {player.Health}";
        playerMana.text = $"Mana: {player.Mana}";
        playerLevel.text = $"Level: {player.Level}";
    }
}
