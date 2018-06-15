# Get .NET SDK image
FROM microsoft/dotnet:2.1-sdk AS builder

RUN mkdir /functions
COPY . /functions

WORKDIR /functions
RUN dotnet build . -o output

# Get Azure Function runtime image
FROM microsoft/azure-functions-dotnet-core2.0:latest AS runtime

ENV AzureWebJobsScriptRoot=/home/site/wwwroot
COPY --from=builder /functions/output /home/site/wwwroot
