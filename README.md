# Web-API game RockPaperScissors

* Project is made by means of .NET7, EF Core, AutoMapper. 
* Management system is Microsoft SQL Server.

<h3>To start</h3>

1. Update db connection string
1. Create your database from the migration. via the following 

```
Update-Database
```

<h3>Rules</h3>
The game is played between 2 players in 5 rounds. The game may end ahead of schedule.
First player enter username to create game and make first turn. 
Second player connecting by game id and username(may participate for the first time) then make turn.
In each round, players can perform only one move (rock, scissors, paper) then a new round automatically begins.
At the end of each round, players can get a result of the round, all previous rounds info and game status. 

* Rock beats Scissors
* Scissors beat Paper
* Paper beats Rock
* If moves are the same, round played in a draw

<h3>EndPoints</h3>

/Game/list - get list of active games, return List<GameDto>. Example:

```
[
  {
    "id": 2,
    "firstPlayerId": 1,
    "firstPlayerName": "Jon Dou",
    "secondPlayerId": null,
    "secondPlayerName": null,
    "winnerId": null,
    "winnerName": null,
    "isFinished": false
  }
]
```

/Game/start/{userName} - first player registering, create game, return GameId and UserId. Example:

```
{
  "gameId": 3,
  "userId": 2
}
```

/Game/{gameId:int}/join/{userName} - find or registering second player, add second player to game, return secondPlayerId or BadRequest. Example:

```
Impossible to connect
```

/Game/{gameId:int}/user/{userId:int}/{figure} - add a turn if possible, create new round if necessary, finish the game if needed, get round info, return GameInfoDto or BadRequest. Example:

```
{
  "gameStatus": 3,
  "currentRoundStatus": 3,
  "rounds": [
    {
      "id": 4,
      "gameId": 3,
      "winnerId": null,
      "winnerName": null,
      "roundNumber": 1,
      "firstPlayerFigure": 1,
      "secondPlayerFigure": 0
    }
  ]
}
```

<h3>DB</h3>
![image](https://github.com/Anastasia1Minsk/RockPaperScissors/assets/92824314/6fe0017d-7142-4eca-ae0d-1f6765c298da)

