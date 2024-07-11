# Api_Tarefa


# No Arquivo appsettings.Development.json deve obter as seguintes config para conecrar com o mongo dentro do container.
   1. # Na ConnectionString é necessário sempre passar o endereço de IP da Maquina ,junto com a porta do MongoDB.
      #Para criar sua string de conexão para o MongoDB, você deve utilizar o valor do campo IPAddress, que no seu caso é 172.17.0.2. Isso porque o IPAddress é o endereço IP do container no qual o MongoDB está sendo #executado.
      #Astring de conexão que você mencionou parece estar correta. A configuração ficaria assim:
     "DataBaseConfig": {
       "DataBaseName": "CassiManage",
       "ConnectionString": "mongodb://172.17.0.2:27017/"
     }

     
        "DataBaseConfig": {
        "DataBaseName": "Treinamento",
        "ConnectionString": "mongodb://192.168.100.42:27023/"

# Documentação pra inicializar o container Da Api
     OBS: deve rodar os comandos na pasta que tem o dockerFile

   1. #Gerar imagem do containe - obs 
        #Docker build --no-cache -f Dockerfile -t Nome_da_imagem_Com_letras_minusculas .

   2. #Inicializar imagem 
       #Docker run --name Nome_do_container_Com_letras_minusculas -p 8000:80  Nome_da_imagem_Com_letras_minusculas .

     Exemplo 
     #Docker build --no-cache -f Dockerfile -t apitarefas .

     #Docker run --name api_tarefas -p 8000:80  apitarefas .

    #Verifica os containers criados
        #Docker container ls   

    #Parar o container
        #Docker stop Nome_do_container

    #Remover o container
        #Docker rm Nome_do_container


# MongoDB container
       
# Instalação da imagem do MongoDB no Docker 
   1. #Comando para obter a imagem do Docker
        docker pull mongo
   2. #Comando para criar o container do MongoDB
        docker create mongo
   3. #Comando para verificar todos os container que estão sendo executados
        docker ps -a
   4. #Comando para executar o Container do MongoDB
        docker run --name mongo -d -p 27017:27017 mongo
   5. #instalar o MongoDB Compass

   6. #URI para Connection string     
        mongodb://localhost : 27323
   

