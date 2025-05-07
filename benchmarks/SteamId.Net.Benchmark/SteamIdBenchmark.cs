using BenchmarkDotNet.Attributes;

namespace SteamId.Net.Benchmark;

[MemoryDiagnoser]
public class SteamIdBenchmark
{
    private const string SteamId = "STEAM_0:1:12345678";
    private const string SteamId64 = "76561197960265728";
    private const string SteamId3 = "[U:1:12345678]";
    private static readonly SteamIdBase SteamID = SteamIdBase.Parse(SteamId);
    
    [Benchmark]
    public void ToSteamId64()
    {
        SteamID.ToSteamId64();
    }
    
    [Benchmark]
    public void ToSteamId3()
    {
        SteamID.ToSteamId3();
    }
    
    [Benchmark]
    public void ToSteamId()
    {
        SteamID.ToSteamId2();
    }
    
    [Benchmark]
    public void SteamId_Parse()
    {
        SteamIdBase.Parse(SteamId);
    }

    [Benchmark]
    public void SteamId3_Parse()
    {
        SteamIdBase.Parse(SteamId3);
    }
    
    [Benchmark]
    public void SteamId64_Parse()
    {
        SteamIdBase.Parse(SteamId64);
    }
}