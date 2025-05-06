namespace SteamId.Net;

public static class AccountTypes
{
    public static AccountType FromLetter(string letter)
    {
        if (letter.Length > 1)
        {
            throw new ArgumentException("Invalid universe letter");
        }

        if (letter.Length == 0)
        {
            return AccountType.P2PSuperSeeder;
        }

        return letter[0] switch
        {
            'U' => AccountType.Individual,
            'M' => AccountType.Multiseat,
            'G' => AccountType.GameServer,
            'A' => AccountType.AnonGameServer,
            'P' => AccountType.Pending,
            'C' => AccountType.ContentServer,
            'g' => AccountType.Clan,
            'T' or 'L' or 'c' => AccountType.Chat,
            'a' => AccountType.AnonUser,
            _ => AccountType.Unspecified,
        };
    }

    public static string ToLetter(this AccountType accountType) => accountType switch
    {
        AccountType.Individual => "U",
        AccountType.Multiseat => "M",
        AccountType.GameServer => "G",
        AccountType.AnonGameServer => "A",
        AccountType.Pending => "P",
        AccountType.ContentServer => "C",
        AccountType.Clan => "g",
        AccountType.Chat => "T",
        AccountType.AnonUser => "a",
        _ => "",
    };

    public static long GetAccountTypeHex(AccountType accountType) => accountType switch
    {
        AccountType.Individual => 0x0110000100000000,
        AccountType.Clan => 0x0170000000000000,
        _ => throw new ArgumentException("Invalid account type"),
    };
}