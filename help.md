Command DotNET Core

* Génération : 
    dotnet build

* Génération build sans restauration de package nuget :
    dotnet build --no-restore

* Migration de la bd avec nom de migration 'InitialCreate', projet dataAcess et classe DbContext :
    dotnet ef migrations add InitialCreate \
    --project ../ShaykhCoreEF.DataAccess/ShaykhCoreEF.DataAccess.csproj \
    --context ShaykhCoreEFContext

* Application de la migration :
    dotnet ef database update \
    --project ../ShaykhCoreEF.DataAccess/ShaykhCoreEF.DataAccess.csproj \
    --context ShaykhCoreEFContext

* Commande pour lister tables :
    db -Q "SELECT TABLE_NAME AS 'Table' FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='dbo' ORDER BY TABLE_NAME" -Y 25

* Commande pour lister les contraintes de clé primaire et de clé étrangère sur les tables de la base de données :
    db -i $setupWorkingDirectory/listkeys.sql -Y 35

* Commande de lancement de l'app en mode dev :
    dotnet ./bin/Debug/netcoreapp3.0/ShaykhCoreEF.Api.dll \
    --environment Development \
    > $srcWorkingDirectory/ShaykhCoreEF.Api.log &