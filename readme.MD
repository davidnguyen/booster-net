# Getting Started

## Prerequisites
* Dotnet 6
* `dotnet tool install --global dotnet-ef`
* Docker
* mkcert

## Initial setup
* Set up development certificate

    ```
    dotnet dev-certs https -ep ./.local/https/aspnetapp.pfx -p DevCertPassword
    dotnet dev-certs https --trust
    ```

* Open root folder in vscode
* From NPM Scripts sidebar, run 0-solution: build script to make sure everything compiles
