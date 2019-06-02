using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChancesNormalized {

    float[] chancesAxies;

    public int GetNextID()
    {
        float num = Random.Range(0.0f, 1.0f);

        for (int i = 0; i < chancesAxies.Length; i++)
        {
            if (num <= chancesAxies[i])
                return i;
        }

        return Random.Range(0, chancesAxies.Length);
    }

    public ChancesNormalized(float[] chances)
    {
        GenerateChancesOnAxis(chances);
    }

    void GenerateChancesOnAxis(float [] chances)
    {
        float total = 0;
        foreach (float chance in chances)
            total += chance;

        chancesAxies = new float[chances.Length];

        float curChance = 0;
        for (int i = 0; i < chances.Length - 1; i++)
        {
            curChance += chances[i] / total;
            chancesAxies[i] = curChance;
            Debug.Log("chance " + i + " -> " + curChance);
        }

        chancesAxies[chances.Length - 1] = 1;
    }
}
