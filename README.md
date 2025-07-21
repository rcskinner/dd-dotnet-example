# dd-dotnet-example
Example of a .NET WebApplication monitored with Datadog with automatic instrumentation, 

## Assumptions: 

- Datadog Agent deployed and configured to collect traces & logs
- .NET Tracing Configured (I used Datadog's Default Autoinstrumentation from agent page)
- Log collection / file tailing configured

## .NET Runtime Metric Collection
Configuring `DD_RUNTIME_METRICS_ENABLED: true` and using the Datadog Agent enables the automatic collection and correlation of .NET Runtime Metrics 

## Log Configuration (File Tailing): 

Configuring `"DD_LOGS_INJECTION": true` in datadog.json enables the injection of the Datadog Trace ID and Span ID allowing trace / log correlation in Datadog without and additional configuration. 

**Serilog Configuration**  
Serilog prohibits the addition of the correlation IDs `dd.trace_id`. Setting `source:csharp` remaps the trace IDs automatically
```
logs:
  - type: file
    path: "/home/ec2-user/HelloApi/logs/app.json" 
    service: "dotnet-demo"
    source: "csharp"
```