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
                      name = "Engenharia Informática",
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
                                name = "Desenho e implementação de software",
                                semester = 1,
                                year = 4
                            },
                            new Course()
                            {
                                name = "Gestão de sistemas e Redes",
                                semester = 1,
                                year = 4
                            },
                            new Course()
                            {
                                name = "Aplicações Centradas em redes",
                                semester = 1,
                                year = 4
                            },
                      },
                      
                      students =  new List<Student>()
                      {
                          new Student()
                          {
                              studentNumber = 2084813,
                              name = "Jacinto Duarte Afonso Costa",
                              email = "2084813@student.uma.pt"
                          },
                          new Student()
                          {
                              studentNumber = 2071213,
                              name = "Pedro António Gouveia Mendonça",
                              email = "2071213@student.uma.pt"
                          },
                          new Student()
                          {
                              studentNumber = 2063210,
                              name = "Jorge Duarte Lomelino Calaça",
                              email = "2063210@student.uma.pt"
                          },

                      }


                  },
                  new Degree
                  {
                    name = "Engenharia Eletrónica",
                    courses = new List<Course>()
                    {
                        new Course()
                        {
                            name = "Comunicações digitais",
                            semester = 1,
                            year = 4

                        },
                         new Course()
                        {
                            name = "Eletrónica da potência",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Comunicações móveis e sem fios",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Comunicações ópticas",
                            semester = 1,
                            year = 4

                        },
                    },

                      students = new List<Student>()
                      {
                          new Student()
                          {
                              studentNumber = 2084713,
                              name = "Amaro Afonso Costa",
                              email = "2084713@student.uma.pt"
                          },
                          new Student()
                          {
                              studentNumber = 2081213,
                              name = "vitor António Gouveia Mendonça",
                              email = "2081213@student.uma.pt"
                          },
                          new Student()
                          {
                              studentNumber = 2063710,
                              name = "Ruben Lomelino Calaça",
                              email = "2063710@student.uma.pt"
                          },

                      }
                  },
                  new Degree
                  {
                      name = "Engenharia Civil",
                      courses = new List<Course>()
                    {
                        new Course()
                        {
                            name = "Estruturas de Betão Armado e Pré-esforçado",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Fundações e Estruturas de Suporte",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Tecnologia da Construção",
                            semester = 1,
                            year = 4

                        },
                        new Course()
                        {
                            name = "Hidráulica Urbana",
                            semester = 1,
                            year = 4

                        },
                    }
                  }
                );
            
        }
    }
}
