using WereWolfGameBackEnd.Models;

namespace WereWolfGameBackEnd.Service.AdminService
{
    public interface IAdminService
    {
        //Player Service
        List<Player> GetPlayersList();
        bool DeletePlayer(string id);

        //Transaction Service
        List<Transaction> GetTransactionsList();
    }
}
