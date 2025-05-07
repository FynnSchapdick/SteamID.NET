namespace SteamId.Net;

public sealed record SteamId2(Universe Universe, AccountType AccountType, int AccountNumber, int AccountInstance, int AccountId)
    : SteamIdBase(Universe, AccountType, AccountNumber, AccountInstance, AccountId)
{
    public new static SteamIdBase Parse(string steamId)
    {
        string[] parts = steamId.Replace("STEAM_", "").Split(':');
        if (parts.Length is not 3)
        {
            throw new ArgumentException("Invalid Steam ID format");
        }

        int universe = int.Parse(parts[0]);
        int accountId = int.Parse(parts[1]);
        int accountNumber = int.Parse(parts[2]);

        return new SteamId2((Universe)universe, AccountType.Individual, accountNumber, 1, accountId);
    }
}