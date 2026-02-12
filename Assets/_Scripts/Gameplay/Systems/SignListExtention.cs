using TicToe.UnityComponents;
using System.Collections.Generic;

public static class SignListExtention
{
    public static SignView GetSign(this IReadOnlyList<SignView> list, string id)
    {
        SignView signView;  

        foreach(var sign in list)
        {
            if (sign.signData.id == id)
            {
                signView = sign;
                sign.signData.id = id;

                return signView;
            }
        }

        throw new System.Exception("Haven`t got sign view with ID: " + id);
;   }

    public static string GetSignObjectName(this IReadOnlyCollection<SignView> list, string id)
    {
        string signName;

        foreach (var sign in list)
        {
            if (sign.signData.id == id)
            {
                signName = sign.gameObject.name;
                return signName;
            }
        }

        throw new System.Exception("Haven`t got sign view with ID: " + id);
    }
}