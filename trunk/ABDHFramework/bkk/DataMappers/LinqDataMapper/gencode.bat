@echo off
SET DBSERVER=.
SET DBNAME=SMM-Trunk
SET DBUSER=sa
SET DBPASSWORD=snowman09

"c:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\sqlmetal" /server:%DBSERVER% /database:%DBNAME% /namespace:Superior.MobileMedics.DataMappers.LinqDataMapper /code:temp.cs /user:%DBUSER% /password:%DBPASSWORD% /pluralize /context:EntitiesDataContext /views /functions /sprocs

..\..\..\References\strrep "Metadata_" "" < temp.cs > Entities.generated.cs
del temp.cs
pause