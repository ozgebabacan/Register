namespace Register.Repository.Migrations
{
    using Register.Model.DatabaseModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Register.Repository.EFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Register.Repository.EFDBContext context)
        {
            #region Cities
            var city1 = new City() { Name = "Ankara" };
            var city2 = new City() { Name = "İstanbul" };
            var city3 = new City() { Name = "İzmir" };

            context.City.AddOrUpdate(city1);
            context.City.AddOrUpdate(city2);
            context.City.AddOrUpdate(city3);
            #endregion

            #region Districts

            var district1 = new District() { Name = "Çankaya", City = new City() };
            var district9 = new District() { Name = "Gölbaşı", City = new City() };
            var district2 = new District() { Name = "Kadıköy", City = new City() };
            var district3 = new District() { Name = "Üsküdar", City = new City() };
            var district4 = new District() { Name = "Beşiktaş", City = new City() };
            var district5 = new District() { Name = "Kınık", City = new City() };
            var district6 = new District() { Name = "Menemen", City = new City() };
            var district7 = new District() { Name = "Urla", City = new City() };
            var district8 = new District() { Name = "Keçiören", City = new City() };

            district1.City = city1;
            district9.City = city1;
            district2.City = city2;
            district3.City = city2;
            district4.City = city2;
            district5.City = city3;
            district6.City = city3;
            district7.City = city3;
            district8.City = city3;

            context.District.AddOrUpdate(district1);
            context.District.AddOrUpdate(district2);
            context.District.AddOrUpdate(district3);
            context.District.AddOrUpdate(district4);
            context.District.AddOrUpdate(district5);
            context.District.AddOrUpdate(district6);
            context.District.AddOrUpdate(district7);
            context.District.AddOrUpdate(district8);
            context.District.AddOrUpdate(district9);


            #endregion

            #region Students

            //var student1 = new Student() { Name = "xxx",Surname = "xxxx",MobilePhone = "3333333333",City = new City() ,District = new District(),Description = "xxxxxxxxxx"};
            //var student2 = new Student() { Name = "yyy", Surname = "yyyy", MobilePhone = "5555555555", City = new City(), District = new District(), Description = "yyyyyyyyy" };
            //var student3 = new Student() { Name = "zzz", Surname = "zzzz", MobilePhone = "4444444444", City = new City(), District = new District(), Description = "zzzzzzzzzzz" };
          

            //student1.City = city1;
            //student1.District = district1;
            //student2.City = city3;
            //student2.District = district5;
            //student3.City = city2;
            //student3.District = district3;
         

            //context.Student.AddOrUpdate(student1);
            //context.Student.AddOrUpdate(student2);
            //context.Student.AddOrUpdate(student3);
           


            #endregion
        }
    }
}
