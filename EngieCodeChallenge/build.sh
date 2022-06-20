dotnet build -c Release
docker build . -t engie
docker container rm challenge
docker run -d -p 8888:80 --name challenge engie
open "http://localhost:8888/swagger/index.html"