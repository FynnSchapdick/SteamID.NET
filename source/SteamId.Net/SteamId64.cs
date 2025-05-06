namespace SteamId.Net;

public sealed record SteamId64(Universe Universe, AccountType AccountType, int AccountNumber, int AccountInstance, int AccountId)
    : SteamIdBase(Universe, AccountType, AccountNumber, AccountInstance, AccountId)
{
    public static SteamIdBase Parse(long steamId)
    {
        // lowest bit is the account ID
        int accountId = (int)(steamId & 1);
        // next 31 bits are the account number
        int accountNumber = (int)((steamId >> 1) & 0x7FFFFFFF);
        // the next 20 bits are the account instance
        int accountInstance = (int)((steamId >> 32) & 0xFFFFF);
        // the next 4 bits are the account type
        int accountType = (int)((steamId >> 52) & 0xF);
        // the next 8 bits are the universe
        int universe = (int)((steamId >> 56) & 0xFF);

        return new SteamId64((Universe)universe, (AccountType)accountType, accountNumber, accountInstance, accountId);
    }
}
