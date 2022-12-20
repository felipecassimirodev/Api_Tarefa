# Api_Tarefa


# No Arquivo appsettings.Development.json deve obter as seguintes config para conecrar com o mongo dentro do container.
   1. # Na ConnectionString é necessário sempre passar o endereço de IP da Maquina ,junto com a porta do MongoDB.
        "DataBaseConfig": {
        "DataBaseName": "Treinamento",
        "ConnectionString": "mongodb://192.168.100.42:27023/"
    
# Documentação pra inicializar o container

   1. #Gerar imagem do containe
        #Docker build --no-cache -f Dockerfile -t Nome_da_imagem .

   2. #Inicializar imagem 
       #Docker run --name Nome_do_container -p 8000:80  Nome_da_imagem .

    #Verifica os containers criados
        #Docker container ls   

    #Parar o container
        #Docker stop Nome_do_container

    #Remover o container
        #Docker rm Nome_do_container