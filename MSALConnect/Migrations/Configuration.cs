using System.Collections.Generic;
using MSALConnect.Models;

namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MSALConnect.Models.DB_DIS>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MSALConnect.Models.DB_DIS context)
        {

                context.Degrees.AddOrUpdate(
                  p => p.degreeID,
                  new Degree
                  {
                      name = "Engenharia Inform�tica",
                      courses = new List<Course>()
                      {
                          new Course()
                          {
                              name = "Engenharia Organizacional"
                          }
                      }
                  },
                  new Degree
                  {
                      name = "Engenharia Eletr�nica"
                  },
                  new Degree
                  {
                      name = "Engenharia Civil"
                  }
                );
            
        }
    }
}
