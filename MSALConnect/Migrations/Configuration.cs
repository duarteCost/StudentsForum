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
                                name = "Engenharia Organizacional",
                                semester = 1,
                                year = 4
                                
                            },
                            new Course()
                            {
                                name = "Desenho e implementa��o de software",
                                semester = 1,
                                year = 4
                            },
                            new Course()
                            {
                                name = "Gest�o de sistemas e Redes",
                                semester = 1,
                                year = 4
                            },
                            new Course()
                            {
                                name = "Aplica��es Centradas em redes",
                                semester = 1,
                                year = 4
                            },

                      }
                  },
                  new Degree
                  {
                    name = "Engenharia Eletr�nica",
                    courses = new List<Course>()
                    {
                        new Course()
                        {
                            name = "Comunica��es digitais",
                            semester = 1,
                            year = 4

                        },
                         new Course()
                        {
                            name = "Eletr�nica da pot�ncia",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Comunica��es m�veis e sem fios",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Comunica��es �pticas",
                            semester = 1,
                            year = 4

                        }
                    }
                  },
                  new Degree
                  {
                      name = "Engenharia Civil",
                      courses = new List<Course>()
                    {
                        new Course()
                        {
                            name = "Estruturas de Bet�o Armado e Pr�-esfor�ado",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Funda��es e Estruturas de Suporte",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Tecnologia da Constru��o",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Hidr�ulica Urbana",
                            semester = 1,
                            year = 4

                        },
                    }
                  }
                );
            
        }
    }
}
