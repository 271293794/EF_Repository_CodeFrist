using OpenAuth.Repository.Domain;
using OpenAuth.Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Repository
{
    public class OpenAuthDBContext : DbContext
    {
        //静态构造，始终会调用
        static OpenAuthDBContext()
        {
            // 数据库不存在时重新创建数据库
            // Database.SetInitializer<OpenAuthDBContext>(new CreateDatabaseIfNotExists<OpenAuthDBContext>());
            // 从不创建数据库，Map中的数据类型有变化时忽略
            Database.SetInitializer<OpenAuthDBContext>(null);
        }
        public OpenAuthDBContext()
    : base("Name=OpenAuthDBContext")
        {
            // 关闭语义可空判断（ 默认值为 false），开启后，会查不到 null 值
            //例：【SELECT  * FROM dbo.Stu  WHERE Class = NULL】 是查不到 null 值的。


            Configuration.UseDatabaseNullSemantics = true;

            //与变量的值为null比较
            //ef判断为null的时候，不能用变量比较：https://stackoverflow.com/questions/682429/how-can-i-query-for-null-values-in-entity-framework?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
            //(this as IObjectContextAdapter).ObjectContext.ContextOptions.UseCSharpNullComparisonBehavior = true;
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Type[] typesToRegister = new Type[] {
                typeof(CategoryMap)

            };
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);

        }
    }
}
