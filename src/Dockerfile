FROM microsoft/aspnetcore-build:latest
COPY jmbde /app/jmbde
COPY RazorUIClassLib /app/RazorUIClassLib
WORKDIR /app/jmbde
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh