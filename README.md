# minimal-api-distributed-rate-limiting-redis
Usando a técnica rate limiting distribuído para controlar a quantidade de solicitações que um cliente pode fazer a uma Minimal API com C# em um determinado período de tempo, usando Redis e Docker.

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
![Redis](https://img.shields.io/badge/redis-%23DD0031.svg?style=for-the-badge&logo=redis&logoColor=white)

## Sobre o projeto
Este projeto mostra como implementar a técnica rate limiting distribuído para controlar a quantidade de solicitações que um cliente pode fazer a uma Minimal API com C# em um determinado período de tempo, usando Redis e Docker.

Rate limiting distribuído oferece vantagens como escalabilidade, consistência, resiliência e gerenciamento centralizado, garantindo aplicação uniforme das políticas de limite em múltiplas instâncias.

<div align="center">
    <img src="https://github.com/user-attachments/assets/36dcfebb-bd9b-41f0-b60d-aa8f24148390"</img>
    <img src="https://github.com/user-attachments/assets/0ea5c540-5661-41e0-a647-da10b675d3f1"</img>
</div>

Com o Docker Desktop instalado no Windows + WSL habilitado, siga os seguintes passos através do CLI:

1. Obter a imagem do Redis através do comando: <code>docker pull redis</code>

2. Configurar e executar o Redis através do comando: <code>docker run –-name redis -p 6379:6379 -d redis</code>

<div align="center">
    <img src="https://github.com/user-attachments/assets/dfb01018-5ba5-4ec2-a5d7-c7a4d3a84e97"</img>
</div>

## Referências
https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-9.0

https://www.docker.com/

https://hub.docker.com/

## Licença
GPL-3.0 license
