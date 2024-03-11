using Football.Domain;
using Microsoft.AspNetCore.SignalR;

namespace Football.API.Hubs
{
    public class FootballHub : Hub
    {
        /// <summary>
        /// Сообщает клиентам о том, что был добавлен новый игрок.
        /// </summary>
        /// <param name="player">Игрок который был добавлен</param>
        /// <param name="teamName">Название команды игрока</param>
        public async Task AddPlayer(Player player, string teamName)
        {
            await Clients.All.SendAsync("PlayerAdded", player, teamName);
        }

        /// <summary>
        /// Сообщает клиентам об обновлении данных игрока.
        /// </summary>
        /// <param name="player">Эксемпляр обновленного игрока</param>
        public async Task UpdatePlayer(Player player)
        {
            await Clients.All.SendAsync("PlayerUpdated", player);
        }

        /// <summary>
        /// Сообщает клиентам о том, что игрок с id был удалён.
        /// </summary>
        /// <param name="id">Guid удаленного игрока</param>
        public async Task DeletePlayer(Guid id) 
        {
            await Clients.All.SendAsync("PlayerDeleted", id);
        }

        /// <summary>
        /// Сообщает клиентам о добавлении новой команды.
        /// </summary>
        /// <param name="team">Добавленная команда</param>
        public async Task AddTeam(Team team)
        {
            await Clients.All.SendAsync("TeamAdded", team);
        }
    }
}
