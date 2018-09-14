using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TodoList.Data;

namespace TodoList.Migrations
{
    public class Configuration : DbMigrationsConfiguration<TodoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}