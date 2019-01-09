# use MSSQL 2017 image on Ubuntu 16.04
FROM mcr.microsoft.com/mssql/server:latest

RUN apt-get update && apt-get -y install ca-certificates

# create directory within SQL container for database files
RUN mkdir -p /opt/dbscripts

# copy the database files from host to container
COPY *.sql /opt/dbscripts/

# set environment variables
ENV SA_PASSWORD=mysapwdn0tGo0d!
ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Express

RUN /opt/mssql/bin/sqlservr --accept-eula & sleep 30 \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'mysapwdn0tGo0d!' -i /opt/dbscripts/dbcreate.sql \
    && pkill sqlservr 