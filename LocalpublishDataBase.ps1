dotnet ef migrations bundle --project Commun/Altalents.DataAccess --verbose --target-runtime win-x64 --self-contained --output ./SQL/bundle.exe --force --context MigrationContext --verbose;
.\SQL\bundle.exe --verbose  --connection "Server=localhost;Database=Altalents;Trusted_Connection=True;TrustServerCertificate=True;"
Read-Host -Prompt 'Ok'