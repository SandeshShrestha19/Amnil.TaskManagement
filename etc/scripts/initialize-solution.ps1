abp install-libs

cd src/Amnil.TaskManagement.DbMigrator && dotnet run && cd -


cd src/Amnil.TaskManagement.HttpApi.Host && dotnet dev-certs https -v -ep openiddict.pfx -p config.auth_server_default_pass_phrase 



exit 0