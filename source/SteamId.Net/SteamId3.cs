namespace SteamId.Net;

public sealed record SteamId3(Universe Universe, AccountType AccountType, int AccountNumber, int AccountInstance, int AccountId)
    : SteamIdBase(Universe, AccountType, AccountNumber, AccountInstance, AccountId)
{
    public new static SteamIdBase Parse(string steamId)
    {
        if (!steamId.StartsWith('[') || !steamId.EndsWith(']'))
        {
            throw new ArgumentException("Invalid SteamID3 format");
        }

        steamId = steamId.Substring(1, steamId.Length - 2);
        string[] parts = steamId.Split(':');
        if (parts.Length != 3)
        {
            throw new ArgumentException("Invalid SteamID3 format");
        }

        string letter = parts[0];
        int universe = int.Parse(parts[1]);
        int id = int.Parse(parts[2]);

        AccountType accountType = AccountTypes.FromLetter(letter);
        int accountNumber = id / 2;
        int accountId = id % 2;

        return new SteamId3((Universe)universe, accountType, accountNumber, 1, accountId);
    }
}