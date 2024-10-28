# Luna

<div align="center">

![Static Badge](https://img.shields.io/badge/version-0.0.1_alpha-purple)
![Static Badge](https://img.shields.io/badge/status-developing-green)


</div>


<br>
<br>


- [Documentação em portguês (pt-br) :brazil:](#documentação-pt-br)
- [Documentation in english (en) :us:](#documentation-en)


<br>
<br>
<br>


# Documentação-PT-BR


## Sobre
A Luna é chatbot para a plataforma [Twitch](https://www.twitch.tv/), projetado para auxiliar nas suas transmissões, interagindo e moderando o chat. Este projeto é desenvolvido no meu tempo livre, o que pode ocasionar um tempo maior para a implementação de novas funcionalidades. No entanto, comprometo-me a corrigir eventuais bugs com a maior rapidez possível.


## Dica
Para garantir que nenhuma mensagem da Luna seja bloqueada pela [Twitch](https://www.twitch.tv/) ou por outros bots que você possa utilizar, e que ela consiga executar todos os comandos sem problema, recomendamos atribuir a ela o cargo de moderadora. Caso não se sinta confortável em colocá-la como moderadora, sugerimos atribuir a ela o cargo de VIP, no entanto, isso pode ocasionar que alguns comandos não funcionem.


## AVISO IMPORTANTE
Caso você solicite que a Luna deixe o seu canal, todos os seus dados (comandos, mensagens programadas, configurações, etc.) serão excluídos imediatamente e permanentemente. Portanto, por favor, tenha certeza de que deseja removê-la do seu canal.


## Comandos


### Comandos do bot
Esses comandos só serão reconhecidos se enviados apenas no [chat da Luna](https://www.twitch.tv/lunachan250).


| Comando                     | Saída                                                     |
| :-------------------------- | :-------------------------------------------------------- |
| !join                       | O bot entra no canal                                      |
| !leave                      | O bot Sai do canal                                        |
| !enableban                  | Será ativado a função de banimento automático             |
| !disableban                 | Será desativado a função de banimento automático          |


#### Banimento automático
Essa função consiste em banir usuários que possuem histórico de bans registrado na sua conta por diversos motivos. Toda vez que um usuário é banido em um canal que a Luna esteja presente, ela registrará o banimento em seu banco de dados. Após acumular um determinado número de banimentos, o usuário será considerado nocivo e, caso a opção de autoban esteja ativa em seu canal, ele será banido automaticamente.


### Comandos para o Streamer
Esses comandos só serão reconhecidos se enviados pelo próprio Streamer no seu canal.


**IMPORTANTE:** Nos parênteses (), substitua pelo que você desejar, e os colchetes [] devem estar presente no comando final. Caso contrário um erro será gerado. 


Exemplo: `` !addtm seguir[30]=Não esqueçam de dar o follow!!! ``


| Comando        | Exemplo                                                                    | Saída                                                  			|
| :------------- | :------------------------------------------------------------------------- | :-------------------------------------------------------------- |
| !add           | !add (nome do comando)=(resposta da luna)                          		  | Adiciona um comando                                   			|
| !remove        | !remove (nome do comando)                                                  | Remove o comando                                       			|
| !reset         | !reset (nome do comando) ou !reset (nome do comando)=(número)              | Reseta o contador do comando para 0 ou para o número desejado	|
| !createlottery | !createlottery (nome do sorteio) [(quantidade de ganhadores)]              | Cria um sorteio                                        			|
| !deletelottery | !deletelottery (nome do sorteio)                                           | Apaga o sorteio                                        			|
| !lotterywinner | !lotterywinner (nome do sorteio)                                           | seleciona o ganhador do sorteio                            		|
| !addtm         | !addtm (nome da mensagem)[(tempo em minutos)]=(Mensagem que será exibida)  | Cria uma mensagem que será enviada periodicamente 				|
| !rmtm          | !rmtm (nome da mensagem)                                                   | Apaga a mensagem criada                                			|


**OBS:** Não se esqueça de apagar os sorteios após finalizá-los. Os sorteios têm um tempo máximo de duração de 30 dias; após esse período serão finalizados e apagados automaticamente, sem gerar um ganhador.


### Comandos Globais
Os comandos globais são reconhecidos em qualquer chat.


| Comado                    | Saída                                               |
| :------------------------ | :-------------------------------------------------- |
| !list                     | Exibe todos os comandos disponíveis para o chat     |
| !ticket (nome do sorteio) | Permite a participação em um sorteio aberto no chat |


**OBS**: Caso você crie um comando com mesmo nome em seu canal, os comandos globais serão substituídos pelo comando cadastrado no seu canal, perdendo sua função original, mas apenas no seu canal.


### Formatação do Texto nos comandos
Para criar comandos que interajam com o chat, utilize a seguinte sintaxe:


| Comando   | exemplo                                          | Saída                                          | OBS                                           |
| :-------- | :----------------------------------------------- | :--------------------------------------------- | :-------------------------------------------- |
| {user}    |                                                  | Usuário que enviou a mensagem                  |                                               |
| {user2}   |                                                  | Usuário mencionado na mensagem                 |                                               |
| {rnum}[x] | a chance é de {rnum}[insira o número que quiser] | Número aleatório entre 0 e o número escolhido	| o número não pode ser maior que 2,100,000,000 |
| {count}   |                                                  | inicia uma contagem a partir de 0              |                                               |


## Contato
Se você tiver sugestões de novas funcionalidade, dúvidas, precisar de ajuda ou encontrar um bug, por favor entre em contato via DM no [Twitter](https://twitter.com/LunaChan250) ou envie uma mensagem privada para a conta da [Luna na twitch](https://www.twitch.tv/lunachan250).


<br>


[ :arrow_up: Voltar ao topo](#luna)


<br>
<br>
<br>
<br>
<br>


# Documentation-EN


## About
Luna is a chatbot for the [Twitch](https://www.twitch.tv/) platform, designed to assist with your streams by interacting with and moderating the chat. This project is developed in my spare time, which may lead to longer implementation times for new features. However, I am committed to fixing any bugs as quickly as possible.


## Tip
To ensure that none of Luna's messages are blocked by [Twitch](https://www.twitch.tv/) or any other bots you may be using, and that she can execute all commands without issues, we recommend assigning her the moderator role. If you're not comfortable making her a moderator, we suggest assigning her the VIP role. However, this may result in some commands not working.


## IMPORTANT NOTICE
If you request Luna to leave your channel, all of your data (commands, scheduled messages, settings, etc.) will be immediately and permanently deleted. Therefore, please make sure you really want to remove her from your channel.


## Commands


### Bot Commands
These commands will only be recognized if sent in [Luna's chat](https://www.twitch.tv/lunachan250).


| Command                     | Output                                      |
| :-------------------------- | :------------------------------------------ |
| !join                       | The bot joins the channel                   |
| !leave                      | The bot leaves the channel                  |
| !enableban                  | The auto-ban feature is activated           |
| !disableban                 | The auto-ban feature is deactivated			|


#### Auto-Ban
This feature involves banning users who have a history of bans recorded on their account for various reasons. Every time a user is banned in a channel where Luna is present, she will log the ban in her database. After accumulating a certain number of bans, the user will be considered harmful, and if the autoban option is enabled in your channel, they will be banned automatically.


### Streamer Commands
These commands will only be recognized if sent by the streamer in their own channel.


**IMPORTANT:** In parentheses (), replace with what you want, and the brackets [] must be present in the final command. Otherwise, an error will be generated.


Example: `` !addtm follow[30]=Don’t forget to follow!!! ``


| Command        | Example                                                              | Output                                                  	|
| :------------- | :------------------------------------------------------------------- | :-------------------------------------------------------- |
| !add           | !add (command name)=(Luna's response)                          		| Adds a command                                   			|
| !remove        | !remove (command name)                                               | Removes the command                                       |
| !reset         | !reset (command name) or !reset (command name)=(number)              | Resets the command counter to 0 or to the desired number	|
| !createlottery | !createlottery (lottery name) [(number of winners)]              	| Creates a lottery                                         |
| !deletelottery | !deletelottery (lottery name)                                        | Deletes the lottery                                       |
| !lotterywinner | !lotterywinner (lottery name)                                        | Selects the lottery winner                          		|
| !addtm         | !addtm (message name)[(time in minutes)]=(Message to be displayed)	| Creates a message that will be sent periodically  		|
| !rmtm          | !rmtm (message name)                                                 | Deletes the created message                               |


**NOTE:** Don’t forget to delete lotteries after they are completed. Lotteries have a maximum duration of 30 days; after this period, they will be automatically finalized and deleted without selecting a winner.


### Global Commands
Global commands are recognized in any chat.


| Command                | Output                                              	|
| :--------------------- | :--------------------------------------------------- |
| !list                  | Displays all available commands for the chat     	|
| !ticket (lottery name) | Allows participation in an open lottery in the chat 	|


**NOTE:** If you create a command with the same name in your channel, the global commands will be replaced by the command registered in your channel, losing their original function, but only in your channel.


### Text Formatting for Commands
To create commands that interact with the chat, use the following syntax:


| Command   | Example                                   | Output                                         	| Note                                          	|
| :-------- | :---------------------------------------- | :------------------------------------------------ | :------------------------------------------------ |
| {user}    |                                           | The user who sent the message                  	|                                               	|
| {user2}   |                                           | The user mentioned in the message              	|                                               	|
| {rnum}[x] | the chance is {rnum}[insert any number]	| A random number between 0 and the chosen number	| The number cannot be greater than 2,100,000,000 	|
| {count}   |                                           | Starts a count from 0            					|                                               	|


## Contact
If you have suggestions for new features, questions, need help, or find a bug, please contact us via DM on [Twitter](https://twitter.com/LunaChan250) or send a private message to [Luna's account on Twitch](https://www.twitch.tv/lunachan250)


<br>


[ :arrow_up: back to top](#luna)


<br>
<br>
<br>
<br>
<br>
