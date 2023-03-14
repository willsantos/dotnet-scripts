

namespace GeradorUniversal.Extensions;

public static class ConvertToCamelCase
{
    public static string ToCamelCase(this string str)
    {
        if (string.IsNullOrEmpty(str) || !char.IsUpper(str[0]))
        {
            return str;
        }

        string camelCase = char.ToLower(str[0]).ToString();
        for (int i = 1; i < str.Length; i++)
        {
            if (char.IsUpper(str[i]) && str[i - 1] != ' ')
            {
                camelCase += ' ';
            }
            camelCase += str[i];
        }
        return camelCase.Replace(" ", "");
    }
    
    public static string ToPascalCase(this string str)
    {
        string newString = string.Empty;
        bool makeNextCharacterUpper = false;
        for (int index = 0; index < str.Length; index++)
        {
            char c = str[index];
            if(index == 0)
                newString += $"{char.ToUpper(c)}";
            else if(c == ' ')
                makeNextCharacterUpper = true;
            else if(makeNextCharacterUpper)
            {
                newString += $"{char.ToUpper(c)}";
                makeNextCharacterUpper = false;
            }
            else
                newString += c;
        }
        return newString;
    }


}

