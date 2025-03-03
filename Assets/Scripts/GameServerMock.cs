// Do not modify this file
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class GameServerMock
{
    public async Task<string> GetItemsAsync(CancellationToken cancellationToken = default)
    {
        int milliseconds = Random.Range(4000, 9000);
        await Task.Delay(milliseconds, cancellationToken);

        int itemsCount = Random.Range(5, 100);
        var itemsArray = new JArray();

        for (int i = 0; i < itemsCount; i++)
        {
            string prefix = RandomFromElements("Death", "Dragon", "Guard", "Hunter", "Noble", "Sacred", "Shadow", "Traveler", "Warrior", "Wizard", "Wolf");
            string category = RandomFromElements("Armor", "Boots", "Helmet", "Necklace", "Ring", "Weapon");

            var jsonObject = new JObject
            {
                ["Name"] = $"{prefix}{category}",
                ["Category"] = category,
                ["Rarity"] = RandomFromElements(0, 1, 2, 3, 4),
                ["Damage"] = Random.Range(5, 20),
                ["HealthPoints"] = Random.Range(10, 25),
                ["Defense"] = Random.Range(1, 10),
                ["LifeSteal"] = Random.Range(0f, 20f),
                ["CriticalStrikeChance"] = Random.Range(0f, 10f),
                ["AttackSpeed"] = Random.Range(5f, 20f),
                ["MovementSpeed"] = Random.Range(0f, 20f),
                ["Luck"] = Random.Range(1f, 20f),
            };

            itemsArray.Add(jsonObject);
        }

        var rootObject = new JObject
        {
            ["Items"] = itemsArray
        };

        return rootObject.ToString();
    }

    private T RandomFromElements<T>(params T[] options)
    {
        return options[Random.Range(0, options.Length)];
    }
}
