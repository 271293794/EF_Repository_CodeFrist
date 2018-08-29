using NFine.Data;
using OpenAuth.Repository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Repository
{
    class Program
    {

        static void Main(string[] args)
        {
            RepositoryBase repository = new RepositoryBase();
            var category = new Category { Name="流行" };
            repository.Insert<Category>(category);
        }
    }
}
