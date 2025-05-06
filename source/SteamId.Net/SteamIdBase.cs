namespace SteamId.Net;

public abstract record SteamIdBase(Universe Universe, AccountType AccountType, int AccountNumber, int AccountInstance, int AccountId)
{
    public static SteamIdBase Parse(string steamId)
    {
        if (steamId.StartsWith("STEAM_"))
        {
            return SteamId2.Parse(steamId);
        }

        if (steamId.StartsWith('['))
        {
            return SteamId3.Parse(steamId);
        }

        if (long.TryParse(steamId, out long steamId64))
        {
            return SteamId64.Parse(steamId64);
        }

        throw new ArgumentException("Invalid Steam ID format");
    }

    public string ToSteamId2()
    {
        return $"STEAM_{(int)Universe}:{AccountId}:{AccountNumber}";
    }

    public string ToSteamId3()
    {
        int w = AccountNumber * 2 + AccountId;

        return $"[{AccountType.ToLetter()}:1:{w}]";
    }

    public long ToSteamId64()
    {
        return AccountNumber * 2 + AccountTypes.GetAccountTypeHex(AccountType);
    }
}
