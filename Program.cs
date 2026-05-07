using System.Linq;
List<Account> cuentas = new List<Account>();
int siguienteId = 1;
bool salir = false;

while (!salir)
{
    Console.Clear();
    Console.WriteLine("==Gestor de Contraseñas ==");
    Console.WriteLine("1. Generar contraseña sugerida");
    Console.WriteLine("2. Guardar Cuenta");
    Console.WriteLine("3. Ver cuentas guardadas");
    Console.WriteLine("4. Buscar cuenta");
    Console.WriteLine("5. Eliminar cuentas");
    Console.WriteLine("6 Exportar reporte");
    Console.WriteLine("7. Salir");
    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
           Console.WriteLine("Generar contraseña sugerida");
           Console.Write("Ingrese la longitud de la contraseña: ");
           string inputLength = Console.ReadLine() ?? "";
           if(!int.TryParse(inputLength, out int length))
           {
               Console.WriteLine("La longitud debe ser un número.");
               break;
           }
           if(length < 6)
            {
                Console.WriteLine("La contraseña debe tener al menos 6 caracteres");
                break;
            }

           Console.Write("Desea incluir mayúsculas? (s/n): ");
           string includeUppercaseInput = Console.ReadLine() ?? "";
           bool includeUppercase = includeUppercaseInput.ToLower() == "s";
           
           Console.Write("Desea incluir números? (s/n): ");
           string includeNumbersInput = Console.ReadLine() ?? "";
           bool includeNumbers = includeNumbersInput.ToLower() == "s";

           Console.Write("Desea incluir símbolos? (s/n): ");
           string includeSymbolsInput = Console.ReadLine() ?? "";
           bool includeSymbols = includeSymbolsInput.ToLower() == "s";

           string generatedPassword = PasswordGenerator.GeneratePassword(
            length,
            includeUppercase,
            includeNumbers,
            includeSymbols
           );

           Console.WriteLine();
           Console.WriteLine($"Contraseña sugerida: {generatedPassword}");

           break;

        case "2":
           Console.WriteLine("==Guardar Cuenta==");

           Console.Write("Sitio o aplicación: ");
           string sitio = Console.ReadLine()??"";
           Console.Write("Usuario o correo: ");
           string user = Console.ReadLine() ?? "";
           Console.Write("Contraseña: ");
           string password = Console.ReadLine() ?? "";
           Console.Write("Categoría: ");
           string category = Console.ReadLine() ?? "";

           Console.Write("¿Desea generar una contraseña automáticamente? (s/n): ");
           string generarPasswordInput = Console.ReadLine() ?? "";

           string password = "";
           if(respuestaGenerar.ToLower() == "s")
           {
                Console.Write("Ingrese la longitud de la contraseña: ");
                string inputLength = Console.ReadLine() ?? "";
                if(!int.TryParse(inputLength, out int length))
                {
                    Console.WriteLine("La longitud debe ser un número.");
                    break;
                }
                if(length < 6)
                {
                    Console.WriteLine("La contraseña debe tener al menos 6 caracteres");
                    break;
                }

                Console.Write("Desea incluir mayúsculas? (s/n): ");
                string includeUppercaseInput = Console.ReadLine() ?? "";
                bool includeUppercase = includeUppercaseInput.ToLower() == "s";
                
                Console.Write("Desea incluir números? (s/n): ");
                string includeNumbersInput = Console.ReadLine() ?? "";
                bool includeNumbers = includeNumbersInput.ToLower() == "s";

                Console.Write("Desea incluir símbolos? (s/n): ");
                string includeSymbolsInput = Console.ReadLine() ?? "";
                bool includeSymbols = includeSymbolsInput.ToLower() == "s";

                password = PasswordGenerator.GeneratePassword(
                    length,
                    includeUppercase,
                    includeNumbers,
                    includeSymbols
                   );

                   Console.WriteLine($"Contraseña generada sugerida: {password}");
           }
           else
           {
            Console.Write("Ingrese la contraseña: ");
            password = Console.ReadLine() ?? "";
           }

           if(string.IsNullOrWhiteSpace(sitio) ||
            string.IsNullOrWhiteSpace(user) ||
            string.IsNullOrWhiteSpace(category)||
            string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("No se puede guardar una cuenta con datos vacíos.");
                break;
            }

           Account nuevaCuenta = new Account
           {
               Id = siguienteId,
               Site = sitio,
               User = user,
               Password = password,
               Category = category,
               DateCreation = DateTime.Now
           };
           cuentas.Add(nuevaCuenta);
           siguienteId++;

           Console.WriteLine("Cuenta guardada exitosamente.");
           break;

        case "3":
           Console.WriteLine("Ver cuentas guardadas");

           if(cuentas.Count == 0)
           {
               Console.WriteLine("No hay cuentas guardadas.");
           }
           else
           {
               foreach (Account cuenta in cuentas)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"Id: {cuenta.Id}");
                    Console.WriteLine($"Sitio: {cuenta.Site}");
                    Console.WriteLine($"Usuario: {cuenta.User}");
                    Console.WriteLine($"Categoría: {cuenta.Category}");
                    Console.WriteLine($"Contraseña: ****************");
                    Console.WriteLine($"Fecha de creacion: {cuenta.DateCreation}");
                }
           }
           break;

        case "4":
           Console.WriteLine("///Buscar cuenta///");
           if(cuentas.Count == 0)
            {
                Console.WriteLine("No hay cuentas guardadas para buscar.");
                break;
            }

            Console.Write("Ingrese el sitio, usuario o categoría a buscar: ");
            string criterioBusqueda = Console.ReadLine() ?? "";

            if(string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                Console.WriteLine("Debe escribir algo para buscar.");
                break;
            }

            List<Account> resultadosBusqueda = cuentas.Where(c =>
                c.Site.Contains(criterioBusqueda, StringComparison.OrdinalIgnoreCase) ||
                c.User.Contains(criterioBusqueda, StringComparison.OrdinalIgnoreCase) ||
                c.Category.Contains(criterioBusqueda, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            if(resultadosBusqueda.Count == 0)
            {
                Console.WriteLine("No se encontraron cuentas que coincidan con el criterio de búsqueda.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Resultados de la búsqueda:");
                foreach (Account cuenta in resultadosBusqueda)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"Id: {cuenta.Id}");
                    Console.WriteLine($"Sitio: {cuenta.Site}");
                    Console.WriteLine($"Usuario: {cuenta.User}");
                    Console.WriteLine($"Categoría: {cuenta.Category}");
                    Console.WriteLine($"Contraseña: ****************");
                    Console.WriteLine($"Fecha de creacion: {cuenta.DateCreation}");
                }
            }

           break;

        case "5":
           Console.WriteLine("///Eliminar cuenta///");
           if(cuentas.Count == 0)
            {
                Console.WriteLine("No hay cuentas guardadas para eliminar.");
                break;
            }
            Console.Write("Ingrese el Id de la cuenta a eliminar: ");
            string inputId = Console.ReadLine() ?? "";

            if(!int.TryParse(inputId, out int idEliminar))
            {
                Console.WriteLine("El Id debe ser un número.");
                break;
            }

            Account? cuentaEliminar = cuentas.FirstOrDefault(c => c.Id == idEliminar);
            if(cuentaEliminar == null)
            {
                Console.WriteLine("No se encontró una cuenta con el Id proporcionado.");
                break;
            }
            
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Id: {cuentaEliminar.Id}");
            Console.WriteLine($"Sitio: {cuentaEliminar.Site}");
            Console.WriteLine($"Usuario: {cuentaEliminar.User}");
            Console.WriteLine($"Categoría: {cuentaEliminar.Category}");
            Console.WriteLine("--------------------------------");

            Console.Write("¿Está seguro que desea eliminar esta cuenta? (s/n): ");
            string confirmacionEliminar = Console.ReadLine() ?? "";
            if(confirmacionEliminar.ToLower() == "s")
            {
                cuentas.Remove(cuentaEliminar);
                Console.WriteLine("Cuenta eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
           break;
        case "6":
           Console.WriteLine("Exportar reporte");
           break;

        case "7":
           salir = true;
           break;

        default:
              Console.WriteLine("Opción no válida. Presione Enter para continuar.");
              Console.ReadLine();
              break;

        
    }
    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();  
}