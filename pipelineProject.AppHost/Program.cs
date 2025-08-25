var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.pipelineProject>("pipelineproject");

builder.Build().Run();
