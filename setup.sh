echo [~] Criando container MySQL no Docker...
docker run --name MySQL  \
-p 3306:3306 -p 33060:33060  \
-e MYSQL_ROOT_HOST='%' -e MYSQL_ROOT_PASSWORD='admin'   \
-d mysql/mysql-server:latest

echo [~] Criando container Rentflix.Service no Docker...
docker build -t rentflix -f Dockerfile .