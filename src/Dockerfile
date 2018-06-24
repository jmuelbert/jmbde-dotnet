FROM microsoft/dotnet:2.1-sdk
COPY jmbde /app/jmbde
COPY RazorUIClassLib /app/RazorUIClassLib
COPY entrypoint.sh /app/jmbde
WORKDIR /app/jmbde
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh