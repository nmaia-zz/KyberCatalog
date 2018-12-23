using Project.Domain.Entities;
using Project.Repository.Context;
using System.Linq;

namespace Project.Repository.Data
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            var context = new AppDbContext();
            context.Database.EnsureCreated();

            if (context.Kybers.Any())
            {
                return; //data already exists in database!
            }

            var kybers = new Kyber[]
            {
                new Kyber { Name = "Ankarres Sapphire", Color = "Blue", Planet = "Yavin IV", Meaning = "Associated with protection, justice and intellect." },
                new Kyber { Name = "Adegan", Color = "Green", Planet = "Ilum", Meaning = "Associated with peace, harmony and balance." },
                new Kyber { Name = "Kayburr", Color = "Pink", Planet = "Ilum", Meaning = "Provide the ability to heal allies who got injuried in combat." }
            };

            context.Kybers.AddRange(kybers);
            context.SaveChanges();
        }
    }
}
