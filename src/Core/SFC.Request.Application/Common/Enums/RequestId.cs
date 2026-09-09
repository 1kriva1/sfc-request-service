namespace SFC.Request.Application.Common.Enums;
public enum RequestId
{
    // main
    DatabaseReset,
    // data
    InitData,
    ResetData,
    // identity
    CreateUser,
    CreateUsers,
    // player
    CreatePlayer,
    UpdatePlayer,
    CreatePlayers,
    // team
    ResetTeamData,
    CreateTeam,
    UpdateTeam,
    CreateTeams,
    // team player
    CreateTeamPlayer,
    UpdateTeamPlayer,
    CreateTeamPlayers,
    // game
    ResetGameData,
    CreateGame,
    UpdateGame,
    CreateGames,
    // game player
    CreateGamePlayer,
    UpdateGamePlayer,
    CreateGamePlayers,
    // game team
    CreateGameTeam,
    UpdateGameTeam,
    CreateGameTeams,
    // core
    GetAllRequestData,
    CreateTeamPlayerRequest,
    UpdateTeamPlayerRequest,
    GetTeamPlayerRequest,
    GetAllTeamPlayerRequests,
    GetTeamPlayerRequests,
    // request game player
    CreateGamePlayerRequest,
    CreateGamePlayerRequests,
    UpdateGamePlayerRequest,
    ExistGamePlayerRequest,
    GetGamePlayerRequest,
    GetsGamePlayerRequest,
    GetGamePlayerRequests,
    // request game team
    CreateGameTeamRequest,
    CreateGameTeamRequests,
    UpdateGameTeamRequest,
    ExistGameTeamRequest,
    GetGameTeamRequest,
    GetsGameTeamRequest,
    GetGameTeamRequests,
}