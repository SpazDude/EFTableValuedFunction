namespace EFTableValuedFunction
{
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using CodeFirstStoreFunctions;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<Table1> Table1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table1>().Property(e => e.Name).IsFixedLength();
            modelBuilder.Conventions.Add(new FunctionsConvention<Model1>("dbo"));
        }

        [DbFunction("Model1", "Function1")]
        public IQueryable<Table1> Function1(string name)
        {
            var nameParameter= name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
            return (this as IObjectContextAdapter).ObjectContext
                .CreateQuery<Table1>("Function1(@name)", nameParameter);
        }
    }
}
