namespace SteamId.Net.Tests;

public sealed class SteamIdBaseTests
{
    [Theory]
    [InlineData("STEAM_1:0:32800818", 76561198025867364)]
    public void Parse_SteamId2_To_SteamId64(string steamId, long steamId64)
    {
        Assert.Equal(steamId64, SteamIdBase.Parse(steamId).ToSteamId64());
    }
    
    [Theory]
    [InlineData("76561198025867364","STEAM_1:0:32800818")]
    public void Parse_SteamId64_To_SteamId2(string steamId64, string steamId)
    {
        string actual = SteamIdBase.Parse(steamId64).ToSteamId2();
        Assert.Equal(steamId, actual);
    }
    
    [Theory]
    [InlineData("STEAM_1:0:32800818","[U:1:65601636]")]
    public void Parse_SteamId2_To_SteamId3(string steamId, string steamId3)
    {
        Assert.Equal(steamId3, SteamIdBase.Parse(steamId).ToSteamId3());
    }
    
    [Theory]
    [InlineData("[U:1:65601636]","STEAM_1:0:32800818")]
    public void Parse_SteamId3_To_SteamId2(string steamId3, string steamId)
    {
        Assert.Equal(steamId, SteamIdBase.Parse(steamId3).ToSteamId2());
    }
    
    [Theory]
    [InlineData("[U:1:65601636]",76561198025867364)]
    public void Parse_SteamId3_To_SteamId64(string steamId3, long steamId64)
    {
        Assert.Equal(steamId64, SteamIdBase.Parse(steamId3).ToSteamId64());
    }
    
    [Theory]
    [InlineData("76561198025867364","[U:1:65601636]")]
    public void Parse_SteamId64_To_SteamId3(string steamId64, string steamId3)
    {
        Assert.Equal(steamId3, SteamIdBase.Parse(steamId64).ToSteamId3());
    }
    
    [Theory]
    [InlineData("U:1:65601636]")]
    [InlineData("[U:1:65601636")]
    [InlineData("[U:1:65:601:636]")]
    public void Parse_InvalidSteamId3_Throws_ArgumentException(string steamId3)
    {
        Assert.Throws<ArgumentException>(() => SteamIdBase.Parse(steamId3));
    }
    
    [Theory]
    [InlineData("STEAM_1:0:3280:0818")]
    public void Parse_InvalidSteamId2_Throws_ArgumentException(string steamId2)
    {
        Assert.Throws<ArgumentException>(() => SteamIdBase.Parse(steamId2));
    }
}