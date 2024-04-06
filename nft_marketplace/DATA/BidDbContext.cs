using Microsoft.EntityFrameworkCore;
using nft_marketplace.Models;

namespace nft_marketplace.DATA
{
    public class BidDbContext:DbContext
    {
        public BidDbContext(DbContextOptions<BidDbContext> o) : base(o)
        {

        }

        public DbSet<createBid> CreateBid {  get; set; }
    }
}
