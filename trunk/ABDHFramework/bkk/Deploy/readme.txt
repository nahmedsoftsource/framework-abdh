To deploy the application:
1. Copy smm-deploy.config.sample to C:\ and rename to 'smm-deploy.config'.
2. Update the config file as instruction inside.
3. Run deploydb.bat to upgrade database. Remember to backup the current database first.
4. Run deploy.bat to deploy the web application.

If you don't want to put the config file in C:\, you can put it anywhere then put the full path and file name into DeployConfigFile environment variable. Or you can run deploy.bat with additional argument:

	deploydb -c path\to\filename.config
	deploy -c path\to\filename.config

