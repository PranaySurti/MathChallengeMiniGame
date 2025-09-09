using UnityEngine;

public static class EquationGenerator
{
    public static (string question, int answer) GenerateEquation(bool isAddition)
    {
        if (isAddition)
        {
            // For addition: ensure a + b <= 20 and both a,b >= 1
            int a = Random.Range(1, 20); // 1 to 19 (max exclusive for int)
            int maxB = Mathf.Min(19, 20 - a); // Ensure a + b <= 20
            int b = Random.Range(1, maxB + 1); // 1 to maxB (inclusive)
            
            return ($"{a} + {b} = ?", a + b);
        }
        else
        {
            // For subtraction: ensure a - b >= 1 and a <= 20
            int a = Random.Range(2, 21); // 2 to 20 (so result is at least 1)
            int b = Random.Range(1, a); // 1 to a-1 (ensures positive result)
            
            return ($"{a} - {b} = ?", a - b);
        }
    }
}
