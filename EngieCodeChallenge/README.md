# Build commands
### These will build the app, create an image and instantiate a container hosted at localhost:8888
Requirements:

- .NET 6 SDK
- Docker

---
## With regular commands
To build the app

    dotnet build -c Release

To create an image called engie

    docker build . -t engie

To run a container based on image engie

    docker run -d -p 8888:80 --name challenge engie
---
## Via a build script that opens the link in the browser 
### On Windows
To do the steps above
    
    build.bat

### On MacOS
To do the steps above
    
    build.sh