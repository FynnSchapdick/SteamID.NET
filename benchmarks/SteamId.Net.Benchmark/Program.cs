using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using SteamId.Net.Benchmark;

ManualConfig config = ManualConfig.Create(DefaultConfig.Instance)
    .WithSummaryStyle(SummaryStyle.Default)
    .AddLogger(ConsoleLogger.Default)
    .AddExporter(MarkdownExporter.Default);

BenchmarkRunner.Run<SteamIdBenchmark>(config);
