using System;
using System.Collections.Generic;

namespace Practica_Docker
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                ConnectionHandle con = new ConnectionHandle();
                string appOption = "";
                
                if (args.Length == 0)
                {
                    Console.WriteLine("Escribe la opción:\n- 1 Mostrar Personas Registradas\n- 2 Eliminar Personas Registradas\n- 3 agregar una persona\n- 4 Salir");
                    appOption = Console.ReadLine();
                    try {
                        opcion = Int32.Parse(appOption);
                    }
                    catch (Exception) {
                        Console.WriteLine("Es posible que haya ingresado una opcion incorrecta");
                    }
                    
                    Console.WriteLine(args.Length);
                }

                if (opcion == 1)
                {
                    try
                    {
                        // "select * from categorias"
                        string query = "";
                        string value = "";

                        if (args.Length > 0)
                        {
                            query = args[1];
                            value = args[2];
                        }
                        else
                        {
                            query = "select * from persona";
                            value = "nombre";
                          
                            
                            
                        }

                        List<string> values = con.ExecuteReader(query, value);
                        foreach (string item in values)
                        {
                            Console.WriteLine("{0}: {1}", value, item);
                        }
                        Console.WriteLine("\nCompleto");
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                }

                if (opcion == 2)
                {
                    try
                    {
                        string query = "";

                        if (args.Length > 0)
                        {
                            query = args[1];

                        }
                        else
                        {
                            Console.WriteLine("Ingrese el nombre del registro a eliminar");
                            string nombre = Console.ReadLine();
                            query = "delete from persona where nombre='" + nombre + "';";




                        }

                        con.ExecuteQuery(query);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                
                }

                if (opcion == 3)
                {
                    string query = "";
                     
                        Console.WriteLine("id Persona a registrar");
                        string idPersona = Console.ReadLine().Trim();
                        Console.WriteLine("nombre de la persona");
                        string nombrePersona = Console.ReadLine().Trim();
                        Console.WriteLine("Apellido de la persona a registrar");
                        string apellidoPersona = Console.ReadLine().Trim();
                        Console.WriteLine("id del numero");
                        string idnumero = Console.ReadLine().Trim();
                        Console.WriteLine("id de la direccion a registrar");
                        string iddireccion = Console.ReadLine().Trim();

                        query = String.Format(
                            "insert into persona (id, nombre, apellido, numero ,direccion) values ({0}, \"{1}\", \"{2}\", {3}, {4})",
                            idPersona, nombrePersona, apellidoPersona, idnumero, iddireccion);

                    if (!String.IsNullOrEmpty(query))
                    {
                        Console.WriteLine(query);
                        con.ExecuteQuery(query);
                    }


                }
                else if (opcion == 4)
                    break;
                else Console.WriteLine("Inválido");
            } while (opcion !=4);
        }
    }
    }

