# Web-API game RockPaperScissors

Project is made by means of .NET7, EF Core, AutoMapper. 
Management system is Microsoft SQL Server.

<h3>To start:</h3>

<h3>Rules:</h3>
The game is played between 2 players in 5 rounds. The game may end ahead of schedule.
First player enter username to create game and make first turn. 
Second player connecting by game id and username(may participate for the first time) then make turn.
In each round, players can perform only one move (rock, scissors, paper) then a new round automatically begins.
At the end of each round, players can get a result of the round, all previous rounds info and game status. 

<h3>EndPoints:</h3>
/Game/list - get list of active games, return List<GameDto>
/Game/start/{userName} - first player registering, create game, return GameId and UserId
/Game/{gameId:int}/join/{userName} - find or registering second player, add second player to game, return secondPlayerId or BadRequest
/Game/{gameId:int}/user/{userId:int}/{figure} - add a turn if possible, create new round if necessary, finish the game if needed, get round info,
      return GameInfoDto or BadRequest

<h3>DB:</h3>
![image](https://github.com/Anastasia1Minsk/RockPaperScissors/assets/92824314/ea94be0b-3bf8-4ffa-91f2-b876e3c8d5d6)
