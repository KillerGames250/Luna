# Luna

<div align="center">

![image](./assets/img/Luna.png "Luna")

</div>


Documentação em portguês (pt-br) :brazil:


Documentation in english (en) :us:


# Documentação em portguês (pt-br) :brazil:


## Sobre
A Luna é chatbot para a plataforma [Twitch](https://www.twitch.tv/), projetado para auxiliar nas suas transmissões, interagindo e moderando o cha.Este projeto é desenvolvido no meu tempo livre, o que pode ocasionar um tempo maior para a implementação de novas funcionalidades. No entanto, comprometo-me a corrigir eventuais bugs com a maior rapidez possível.


## Dica
Para garantir que nenhuma mensagem da Luna seja bloqueada pela Twitch ou por outros bots que você possa utilizar, e que ela consiga executar todos os comandos sem problema, recomendamos atribuir a ela o cargo de moderadora. Caso não se sinta confortável em colocá-la como moderadora, sugerimos atribuir a ela o cargo de VIP, no entando, isso pode ocasionar que alguns comandos não funcionem.


## AVISO IMPORTANTE
Caso você solicite que a Luna deixe o seu canal,  todos os seus dados ( comandos, mensagens programadas, configuraçẽos, etc ) serão excluidos imediatamente e permanetemente. Portanto, por favor, tenha certeza de que deseja removê-la do seu canal.


## Comandos


### Comandos do bot
Esses comandos só serão reconhecidos se enviados apenas no chat da [Luna](https://www.twitch.tv/lunachan250)

| Comando                     | Saída                                                     |
| :-------------------------- | :-------------------------------------------------------- |
| !join                       | O bot entra no canal                                      |
| !leave                      | O bot Sai do canal                                        |
| !enableban                  | Será ativado a função de banimento automático             |
| !disableban                 | Será desativado a função de banimento automático          |

#### Banimento automático
Essa função consiste em banir usuários que possuem histórico de bans registrado na sua conta por diversos motivos. Toda vez que um usuário é banido em um canal que a Luna esteja presente, ela registrará o banimento em seu banco de dados. Após acumular um determinado número de banimentos, o usuário será considerado nocivo e, caso a opção de autoban esteja ativa em seu canal ele será banido automaticamente.


### Comandos para o Streamer
Esses comandos só serão reconhecidos se enviados pelo próprio Streamer no seu canal.


**IMPORTANTE:** Nos parênteses (), substititua pelo que você desejar, e os colchetes [] devem estar presente no comando final. Caso contrário um erro será gerado. 

Exemplo: `` !addtm seguir[30]=Não esqueçam de dar o follow!!! ``


| Comando        | Exemplo                                                                    | Saída                                                  |
| :------------- | :------------------------------------------------------------------------- | :----------------------------------------------------- |
| !add           | !add (nome do comando)=(resposta da luna)                          | Adiciona um comando                                   |
| !remove        | !remove (nome do comando)                                                   | Remove o comando                                       |
| !reset         | !reset (nome do comando) ou !reset (nome do comando)=(número)                | Reseta o contador do comando para 0 ou para o número desejado            |
| !createlottery | !createlottery (nome do sorteio) [(quantidade de ganhadores)]              | Cria um sorteio                                        |
| !deletelottery | !deletelottery (nome do sorteio)                                           | Apaga o sorteio                                        |
| !lotterywinner | !lotterywinner (nome do sorteio)                                           | seleciona o ganhador do sorteio                            |
| !addtm         | !addtm (nome da mensagem)[(tempo em minutos)]=(Mensagem que será exibida)  | Cria uma mensagem que será enviada periodicamente |
| !rmtm          | !rmtm (nome da mensagem)                                                   | Apaga a mensagem criada                                |


**OBS:**  Não se esqueçã de apagar os sorteios após finalizá-los. Os soretios têm um tempo maximo de duração de 30 dias; após esse periodo serão finalizados e apagados automaticamente, sem gerar um ganhador.


### Comandos Globais
Os comandos globais são reconhecidos em qualquer chat.


| Comado                    | Saída                                               |
| :------------------------ | :-------------------------------------------------- |
| !list                     | Exibe todos os comandos disponíveis para o chat     |
| !ticket (nome do sorteio) | Permite a participação em um sorteio aberto no chat |


**OBS**: Caso você crie um comando com mesmo nome em seu canal, os comandos globais serão substituido pelo comando cadastrdo no seu canal, perdendo sua função original, mas apenas no seu canal.


### Formatação do Texto nos comandos
Para criar comandos que interajam com o chat, utilize a seguinte sintaxe:

| Comando   | exemplo                                          | Saída                                                  | OBS                                           |
| :-------- | :----------------------------------------------- | :----------------------------------------------------- | :-------------------------------------------- |
| {user}    |                                                  | Usuário que enviou a mensagem                          |                                               |
| {user2}   |                                                  | Usuário mencionado no mensagem                     |                                               |
| {rnum}[x] | a chance é de {rnum}[insira o número que quiser] | Número aleatório entre 0 e o número escolhido | o número não pode ser maior que 2,100,000,000 |
| {count}   |                                                  | inicia uma contagem a partir de 0                     |                                               |


## Contato
Se você tiver sugestões de novas funcionalidade, dúvidas, precisar de ajuda ou encontar um bug, por favor entre em contato via DM no [Twitter](https://twitter.com/LunaChan250) ou envie uma mensagem privada para a conta da Luna na [twitch](https://www.twitch.tv/lunachan250).


# Documentation in english (en) :us:

## About

## Tips

## Alert

## Commands

## Contact
