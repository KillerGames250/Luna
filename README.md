# Luna

## Sobre

A Luna é chat bot para a [Twitch](https://www.twitch.tv/) , ajudara você na sua stream interagindo e moderando o chat.
O projeto da Luna eu estou desenvolvendo no meu tempo livre e por hobby então pode levar algum tempo para que algo novo sejá implementado, tentarei corrigir os eventuais bugs o mais rápido possível e também como eu estou fazendo por hobby não posso pagar por um servidor dedicado , então estou hospedando em um computador em casa e por causa de problemas com a internet ela pode acabar sofrendo com instabilidade ou fincando fora do ar por algum tempo.

## Dica

Para que nem uma mensagem da Luna seja bloqueada pela a twitch ou por outros bots que você possa possuir e também para que ela consiga executar todos os comandos sem problemas de o cargo de moderador para ela em seu chat.

## AVISO

Caso você peça para a Luna deixar o seu canal todos os comandos que tiver cadastrado serão excluídos permanentemente do banco de dados então por favor tenha certeza que deseja remove-lá do seu canal.

## Comandos

### Comandos no chat do bot

Esses comandos só irão ser reconhecidos se enviados no chat da [Luna](https://www.twitch.tv/lunachan250)

| Comando     | Saída                                            |
| :---------- | :----------------------------------------------- |
| !join       | O bot entra no canal                             |
| !leave      | O bot Sai do canal                               |
| !enableban  | Será ativado a função de banimento automático    |
| !disableban | Será desativado a função de banimento automático |

##### **Banimento automático**

Essa função consiste em banir usuários que possuem histórico de bans registrado na sua conta por diversos motivos , toda vez que um usuário é banido em um canal que a Luna esteja presente ela ira registrar em seu banco de dados o banimento daquele usuário, após ele acumular um determinado limite de banimentos ele será considerado um usuário nocivo e caso a opção de autoban esteja ativa em seu canal ele será banido automaticamente do seu canal.

### Comandos para o Streamer

Esses comandos só irão ser reconhecido se o próprio Streamer enviar no seu próprio canal

| Comando | Exemplo                                                     | Saída                                       |
| :------ | :---------------------------------------------------------- | :------------------------------------------ |
| !add    | !add [nome do comado]=[O que o bot ira responder]           | Adiciona uma comando                        |
| !remove | !remove [nome do comado]                                    | Remove o comando                            |
| !reset  | !reset [nome do comado] ou !reset [nome do comado]=[numero] | Reseta o contador para 0 ou numero desejado |

### Comandos Globais

Esses comando irão ser reconhecidos em qualquer chat 

| Comado | Saída                                            |
| :----- | :----------------------------------------------- |
| !list  | Mostra todos os comandos disponíveis para o chat |

**OBS**: Se você criar um comando com o mesmo nome em seu  canal o comando globais serão substituído pelo comando cadastrado no seu canal

## Formatação do Texto no comandos

Na hora da criação dos comandos deve ser usado a syntaxy abaixo para poder ter a interação

| Comando   | exemplo                                          | Saída                                                  | OBS                                           |
| :-------- | :----------------------------------------------- | :----------------------------------------------------- | :-------------------------------------------- |
| {user}    |                                                  | Usuário que mandou a mensagem                          |                                               |
| {user2}   |                                                  | Usuário que foi marcado no comando                     |                                               |
| {rnum}[x] | a chance é de {rnum}[insira o número que quiser] | Numero aleatório entre 0 há o numero que você escolheu | o numero não pode ser maior que 2,100,000,000 |
| {count}   |                                                  | inicia uma contagem começando em 0                     |                                               |

## Próximas implementações programadas

Essas são os novos recursos que serão implantados , eles serão implementados aos poucos no decorrer do tempo ,esses são apenas alguns recursos que já estão sendo trabalhados no momento e outros já estão decidido que serão implementados

* Tradução das mensagem do chat para um idioma escolhido
* mensagem programada para ser enviada a cada determinado espaço de tempo
* sistema para sorteio

Caso você tenha ideia de alguma função que gostaria que fosse implementada entre em contato pelo [Discord](https://discord.gg/T4Z2ZyKPgC) ou mandando um wisper para a conta da Luna na [twitch](https://www.twitch.tv/lunachan250)

## Contatos

Caso tenha uma duvida ou necessite de ajuda dentre em contato pelo [Discord](https://discord.gg/T4Z2ZyKPgC), mandando um wisper para a conta da Luna na [twitch](https://www.twitch.tv/lunachan250)