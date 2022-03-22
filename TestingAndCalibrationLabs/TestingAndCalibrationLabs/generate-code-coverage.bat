dotnet test  /p:CollectCoverage=true  ^
  /p:CoverletOutputFormat=opencover   ^
/p:CoverletOutput="./coverage/Data.opencover.xml"  ^
 /p:Exclude=\"[nunit.*]*,[TestingAndCalibrationLabs.Web.UI.*]*\"

dotnet %userprofile%\.nuget\packages\reportgenerator\4.4.7\tools\netcoreapp3.0\ReportGenerator.dll ^ 
reportgenerator "-reports:coverage/Data.opencover.xml" "-targetdir:coverage-report" -reporttypes:HTML;
	

start .\coverage-report\index.htm\

