using UnityEngine;

public class Demo : MonoBehaviour
{
    public string[] Names;

    public void CharacterDead()
    {   
        if(Names.Length > 0)
        {
            int level = Random.Range(1, 11);

            int i = Random.Range(0, this.Names.Length);
            string characterName = this.Names[i];

            AnalyticsComponent.OnCharacterDead(level, characterName);
        }
    }
}