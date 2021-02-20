ARG SOLUTION_IMAGE
FROM ${SOLUTION_IMAGE} as solution

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=solution /booster.web .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Booster.Web.dll"]