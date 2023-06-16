using WereWolfGameBackEnd.Data;
using WereWolfGameBackEnd.Models;

namespace WereWolfGameBackEnd.Service.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly WereWolfGameDbContext _dbContext;
        public AdminService(WereWolfGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeletePlayer(string id)
        {
            Player player = _dbContext.Players.Where(i => i.PlayerId == id).FirstOrDefault();
            if (player != null)
            {
                _dbContext.Players.Remove(player);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Player> GetPlayersList()
        {
            return _dbContext.Players.OrderBy(i => i.PlayerId).ToList();
        }

        public List<Transaction> GetTransactionsList()
        {
            return _dbContext.Transactions.OrderBy(i => i.TransactionId).ToList();
        }
    }
}
