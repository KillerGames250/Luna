# Luna

## Sobre

A Luna é chatbot para a [Twitch](https://www.twitch.tv/), que irá ajudar você em sua stream interagindo e moderando o chat.
O projeto da Luna vem sendo desenvolvido no meu tempo livre, por causa disso pode levar um tempo para que uma função nova seja implementada, tentarei corrigir os eventuais bugs o mais rápido possível. Estou utilizando um servidor local para hospedar a Luna por causa disso pode haver problemas com a internet ela pode acabar sofrendo com instabilidade ou ficando indisponível por algum tempo.

## Dica

Para que nem uma mensagem da Luna seja bloqueada pela twitch ou por outros bots que você possa possuir e também para ela conseguir executar todos os comandos sem problemas coloque ela como moderadora.

## AVISO

Caso você peça para a Luna deixar o seu canal todos os seus dados(comandos, mensagens, configurações e…) serão excluídos imediatamente do banco de dados então por favor tenha certeza que deseja remove-lá do seu canal.

## Comandos

### Comandos do bot

Esses comandos só serão reconhecidos se enviados no chat da [Luna](https://www.twitch.tv/lunachan250)

| Comando                     | Saída                                                     |
| :-------------------------- | :-------------------------------------------------------- |
| !join                       | O bot entra no canal                                      |
| !leave                      | O bot Sai do canal                                        |
| !enableban                  | Será ativado a função de banimento automático             |
| !disableban                 | Será desativado a função de banimento automático          |
| !enabletranslation (idioma) | Será ativado a função de tradução para o idioma escolhido |
| !disabletranslation         | Será desativado a tradução                                |

#### Banimento automático

Essa função consiste em banir usuários que possuem histórico de bans registrado na sua conta por diversos motivos, toda vez que um usuário é banido em um canal que a Luna esteja presente ela irá registrar em seu banco de dados o banimento daquele usuário. Após ele acumular um determinado número de banimentos ele será considerado um usuário nocivo e caso a opção de autoban esteja ativa em seu canal ele será banido automaticamente do seu canal.

#### Tradução

A Luna irá traduzir todas as mensagens enviadas no chat pelos usuários para o idioma escolhido, a tradução para o idioma escolhido é feita pelo Google tradutor então ela só conseguirá traduzir para idiomas que possuem suporte no Google tradutor.
O idioma no comando deve ser colocado abreviado.
 
Exemplo: !enabletranslation en
    
Segue a tabela com alguns idiomas e sua abreviações:

| Idioma               | Abreviação|  |Idioma    | Abreviação|  |Idioma     | Abreviação|
|--------------------- |---------- |- |--------- |---------- |- |---------- |---------- |
| Alemão               | de        |  | Francês  | fr        |  | Persa     | fa        |
| Árabe                | ar        |  | Grego    | el        |  | Português | pt        |
| Amárico              | am        |  | Guzerate | gu        |  | Punjabi   | pa        |
| Azerbaijano          | az        |  | Hauçá    | ha        |  | Russo     | ru        |
| Bengali              | bn        |  | Hindi    | hi        |  | Suaíle    | sw        |
| Canarês              | kn        |  | Indonésio| id        |  | Tailandês | th        |
| Catalão              | ca        |  | Inglês   | en        |  | Turco     | tr        |
| Chinês(Simplificado) | zh-CN     |  | Italiano | it        |  | Urdu      | ur        |
| Chinês(Tradicional)  | zh-TW     |  | Japonês  | ja        |  | Vietnamita| vi        |
| Coreano              | ko        |  | Javanês  | jw        |
| Espanhol             | es        |  | Marata   | mr        |

Caso o idioma que você queira não esteja na tabela por favor entre em contato que ajudarei.

**OBS**: Digite idêntico como está na tabela.

### Comandos para o Streamer

Esses comandos só serão reconhecidos se o próprio Streamer enviar no seu próprio canal.

**IMPORTANTE:** Nos parênteses () o conteúdo deles devem ser substituído pelo conteúdo que você quiser e os [] devem estar presente no comando final caso contrário um erro será gerado ex:
!addtm seguir[30]=Não esqueçam de dar o follow!!!

| Comando        | Exemplo                                                                    | Saída                                                  |
| :------------- | :------------------------------------------------------------------------- | :----------------------------------------------------- |
| !add           | !add (nome do comando)=(O que o bot irá responder)                          | Adiciona um comando                                   |
| !remove        | !remove (nome do comando)                                                   | Remove o comando                                       |
| !reset         | !reset (nome do comando) ou !reset (nome do comando)=(número)                | Reseta o contador para 0 ou número desejado            |
| !createlottery | !createlottery (nome do sorteio) [(quantidade de ganhadores)]              | Cria um sorteio                                        |
| !deletelottery | !deletelottery (nome do sorteio)                                           | Apaga o sorteio                                        |
| !lotterywinner | !lotterywinner (nome do sorteio)                                           | Pega o ganhador dos sorteios                            |
| !addtm         | !addtm (nome da mensagem)[(tempo em minutos)]=(Mensagem que será exibida)  | Cria uma mensagem que será enviada de tempos em tempos |
| !rmtm          | !rmtm (nome da mensagem)                                                   | Apaga a mensagem criada                                |

**OBS:** não esqueça de apagar os sorteios após finalizado.

### Comandos Globais

Esses comandos serão reconhecidos em qualquer chat.

| Comado                    | Saída                                            |
| :------------------------ | :----------------------------------------------- |
| !list                     | Mostra todos os comandos disponíveis para o chat |
| !ticket (nome do sorteio) | Usado para entrar em um sorteio aberto no canal  |

**OBS**: se você criar um comando com o mesmo nome em seu canal os comandos globais serão substituídos pelo comando cadastrado no seu canal, mas apenas em seu canal.

### Formatação do Texto nos comandos

Na hora da criação dos comandos deve ser usada a sintaxe abaixo para poder ter interações com o chat.

| Comando   | exemplo                                          | Saída                                                  | OBS                                           |
| :-------- | :----------------------------------------------- | :----------------------------------------------------- | :-------------------------------------------- |
| {user}    |                                                  | Usuário que mandou a mensagem                          |                                               |
| {user2}   |                                                  | Usuário marcado no comando                     |                                               |
| {rnum}[x] | a chance é de {rnum}[insira o número que quiser] | Número aleatório entre 0 há o número que você escolheu | o número não pode ser maior que 2,100,000,000 |
| {count}   |                                                  | inicia uma contagem começando em 0                     |                                               |

## Próximas implementações

Esses são alguns dos novos recursos que serão implantados, eles serão implementados gradualmente no decorrer do tempo. Recursos que já estão sendo trabalhados no momento e outros já estão decididos que serão implementados:

* otimização e melhoria

Caso você tenha ideia de alguma função que gostaria que fosse implementada entre em contato.

## Contato

Caso tenha uma dúvida, necessite de ajuda ou tenha achado um bug por favor entre em contato por DM no [Twitter](https://twitter.com/LunaChan250),  ou wisper para a conta da Luna na [twitch](https://www.twitch.tv/lunachan250).
