# SmartPoles API
API que controla e gerencia os cluster de postes inteligentes dentro de um condomínio. A ideia é que esses postes controlem a luminosidade do condomínio com base no fluxo de pessoas e colete dados de IOT (umidade e dados sonoros por exemplo). Para tal existe registros de usuários, condomínios e postes. O usuário pode ter uma de duas roles:

* NORMAL => Tem acesso à visualização do cluster de postes inteligentes vinculados ao condomínio do usuário
* ADM => Capaz de gerenciar todos os recursos do sistema (postes, condominios e outros usuários)

A API foi desenvolvida em ASP.NET 5 e, portanto, é necessário a instalação do [SDK dotnet 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0).
Com o ambiente configurado entre na pasta SmartPoles.API e execute o comando "**dotnet run**". A aplicação rodará em **http://localhost:5000**.

A API é consumida pelo front que está no seguinte repositório [Front](https://github.com/RenanCdS/smart-poles-front)

EC9 - FESA
Integrantes:

RACHEL MOREIRA 081180045  
RENAN CASTRO 081180029  
WELLISON SOUSA 081180040  
WESLEY ROGÉRIO 081180035  
