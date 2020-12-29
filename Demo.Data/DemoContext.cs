using Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
	public class DemoContext: DbContext //DbContext里面有数据库交互,变化追踪等功能
	{
		/*
		1. DbSet<>属性能让 Demo.Domain里面的model在Context里面正常工作
		2. 将三个DbSet<>属性映射到数据库的三个表
		3. 数据库需要数据库连接串和数据库提供商Data Provider
		*/
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB;Initial Catalog=Demo");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)//对model进行设置
		{
			modelBuilder.Entity<GamePlayer>().HasKey(x => new { x.PlayerId, x.GameId });//设置联合主键
			modelBuilder.Entity<Resume>()
				.HasOne(x => x.Player)
				.WithOne(x => x.Resume)
				.HasForeignKey<Resume>(x => x.PlayerId);//最后的泛型最重要,表示给Resume表添加一个外键playerId
		}
		public DbSet<League> Leagues { get; set; }

		public DbSet<Club> Clubs { get; set; }

		public DbSet<Player> Players { get; set; }
	}
}
