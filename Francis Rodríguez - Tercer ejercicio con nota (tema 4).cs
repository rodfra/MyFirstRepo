//Francis Rodríguez - DAM Semipresencial

/* Ejercicio con nota 3 (tema 4)
 * 
 * Crea un programa de C# que pueda almacenar hasta 10000 contactos 
 * (amistades, familiares, etc). Para cada contacto, debe permitir al 
 * usuario almacenar la siguiente información:
 * 
 * Nombre
 * Correo electrónico
 * Año de nacimiento
 * Aficiones
 * Estatura (en metros)
 * Comentarios
 * 
 * 
 * Esta versión mostrará un menú con las opciones:
 * 
 * 
 * 1. Añadir datos de un contacto.
 * 
 * 2. Buscar entre los contactos existentes.
 * 
 * 3. Ver detalles de un contacto.
 * 
 * 4. Modificar los datos de un contacto.
 * 
 * 5. Borrar un contacto.
 * 
 * 6. Ordenar datos.
 * 
 * 7. Ver estadísticas.
 * 
 * 8. Corregir errores frecuentes.
 * 
 * S. Salir.
 * 
 * Es decir, debe permitir al usuario realizar las siguientes operaciones:
 * 
 * 1 - Añadir un nuevo contacto (al final de los datos existentes). El 
 * nombre no debe estar vacío (si introduce un nombre vacío, se le 
 * volverá a pedir tantas veces como sea necesario). Si se introduce 
 * una cadena vacía como respuesta al año de nacimiento, éste se guardará 
 * como 0, y lo mismo ocurrirá con la estatura. No se debe realizar 
 * ninguna otra validación.
 * 
 * 2 - Buscar contactos que contengan un determinado texto (búsqueda 
 * parcial, en cualquier campo de texto, sin distinción de mayúsculas 
 * y minúsculas). Debe mostrar el número de registro y el nombre, en la 
 * misma línea, haciendo una pausa después de cada 22 líneas en pantalla.
 * 
 * 3 - Ver todos los datos de un contacto determinado, a partir de su 
 * número de registro. Se debe avisar (pero no volver a pedir) si el 
 * número no es válido.
 * 
 * 4 - Modificar un registro: pedirá al usuario su número (por ejemplo, 
 * 1 para la primera ficha), mostrará el valor anterior de cada campo 
 * (por ejemplo, dirá: "Nombre anterior: Elon Musk") y permitirá 
 * escribir un nuevo valor para ese campo, o bien pulsar Intro para 
 * dejarlo sin modificar. Se debe avisar al usuario (pero no volver a 
 * pedir) si introduce un número de registro incorrecto.
 * 
 * 5 - Eliminar un registro, en la posición indicada por el usuario. 
 * Se le debe avisar (pero no volver a preguntar) si introduce un número 
 * de registro incorrecto. Debe mostrar el registro que se va a eliminar 
 * y solicitar confirmación antes de la eliminación.
 * 
 * 6 - Ordenar los datos alfabéticamente, por nombre.
 * 
 * 7 - Ver estadísticas: mostrará la cantidad de contactos, la edad media 
 * (para cada edad supondremos que basta con restar al año actual, 2021, 
 * el año de nacimiento) de todos nuestros contactos (salvo los que tengan 
 * 0 como año de nacimiento) y la estatura media de nuestros contactos 
 * (salvo los que tengan 0 como estatura).
 * 
 * 8 - Corregir errores frecuentes: eliminará espacios finales, espacios 
 * iniciales y espacios duplicados en el nombre, aficiones y comentarios 
 * de todos los registros existentes. Si alguna estatura es negativa o 
 * superior a tres metros, se guardará un 0 en su lugar. Si algún año de 
 * nacimiento es anterior a 1850 o posterior a 2100, se guardará como 0.
 * 
 * S - Salir de la aplicación (como no guardamos la información en 
 * fichero, los datos se perderán).
 * 
 * 
 * El menú deberá repetirse hasta que el usuario escoja la opción "S" 
 * (que será aceptable tanto en mayúsculas como en minúsculas).
 * 
 * La estructura repetitiva del programa debe ser adecuada, y emplear 
 * un booleano de control. El fuente debe estar correctamente tabulado 
 * y resultar fácil de leer.
 * 
 * Debes entregar exclusivamente el fichero ".cs" (no todo el proyecto), 
 * sin comprimir, que deberá tener un comentario con tu nombre al principio. 
 * Haz que el nombre del fichero también incluya tu nombre. */

using System;

class Tercer_ejercicio_con_nota__tema4
{
    struct datos
    {
        public string nombre;
        public string correo;
        public string aficiones;
        public string comentarios;
        public ushort anyo;
        public float estatura;
    }

    enum opciones { ANYADIR = '1', BUSCAR, DETALLES, MODIFICAR, BORRAR, ORDENAR,
        ESTADISTICAS, CORREGIR, SALIR = 'S', SALIR2 = 's'}

    static void Main()
    {
        const ushort CAPACIDAD = 10000;
        datos[] contacto = new datos[CAPACIDAD];

        string respuesta, texto;
        char eleccionUsuario, confirmar;
        ushort contador = 0, numero = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("Agenda de Contactos");
            Console.WriteLine();

            Console.WriteLine((char)opciones.ANYADIR +
                ".Añadir un contacto nuevo");
            Console.WriteLine((char)opciones.BUSCAR +
                ".Buscar un contacto");
            Console.WriteLine((char)opciones.DETALLES +
                ".Detalles un contacto");
            Console.WriteLine((char)opciones.MODIFICAR +
                ".Modificar un contacto");
            Console.WriteLine((char)opciones.BORRAR +
                 ".Borrar un contacto");
            Console.WriteLine((char)opciones.ORDENAR +
                 ".Ordenar alfabéticamente");
            Console.WriteLine((char)opciones.ESTADISTICAS +
                ".Mostrar estadísticas");
            Console.WriteLine((char)opciones.CORREGIR +
                ".Corregir errores frecuentes");
            Console.WriteLine((char)opciones.SALIR +
                ".Pulsa la letra \"S\" para SALIR\n");

            Console.Write("Elige una opción: ");
            eleccionUsuario = Convert.ToChar(Console.ReadLine());

            switch (eleccionUsuario)
            {
                case (char)opciones.ANYADIR:
                    Console.WriteLine("Añadir");
                    Console.WriteLine();
                    
                    if(contador >= CAPACIDAD)
                    {
                        Console.WriteLine("No caben más contactos");
                    }
                    
                    else
                    {
                        do
                        { 
                            Console.Write("Introduce el nombre: ");
                            contacto[contador].nombre = Console.ReadLine();
                        }
                        while(contacto[contador].nombre == "");
                        
                        
                        Console.Write("Introduce el correo: ");
                        contacto[contador].correo = Console.ReadLine();
                        
                        Console.Write("Introduce el año de nacimiento: ");
                        respuesta = Console.ReadLine();
                        if(respuesta == "")
                        {
                            contacto[contador].anyo = Convert.ToUInt16(0);
                        }
                        
                        else
                        {
                            contacto[contador].anyo = 
                                Convert.ToUInt16(respuesta);
                        }
                        
                        Console.Write("Introduce las aficiones: ");
                        contacto[contador].aficiones = Console.ReadLine();
                        
                        Console.Write("Introduce la estatura en (m): ");
                        respuesta = Console.ReadLine();
                        if(respuesta == "")
                        {
                            contacto[contador].estatura = Convert.ToSingle(0);
                        }
                        
                        else
                        {
                            contacto[contador].estatura = 
                                Convert.ToSingle(respuesta);
                        }
                        
                        Console.Write("Comentarios: ");
                        contacto[contador].comentarios = Console.ReadLine();
                    }
                    Console.WriteLine();
                    contador++;
                    break;


                case (char)opciones.BUSCAR:
                    Console.WriteLine("Buscar");
                    Console.WriteLine();
                    
                    if(contador == 0)
                    {
                        Console.WriteLine("No hay contactos");
                    }
                    
                    else
                    {
                        Console.Write("Texto: ");
                        texto = Console.ReadLine();
                        bool encontrado = false;
                        for (ushort i = 0; i < contador; i++)
                        {
                            if (contacto[i].nombre.ToUpper().
                                    Contains(texto.ToUpper())
                                ||contacto[i].correo.ToUpper().
                                    Contains(texto.ToUpper())
                                ||contacto[i].aficiones.ToUpper().
                                    Contains(texto.ToUpper())
                                ||contacto[i].comentarios.ToUpper().
                                    Contains(texto.ToUpper()))
                                {
                                    Console.WriteLine((i+1) + "- "
                                        + contacto[i].nombre);
                                        encontrado = true;
                                }
                        } 
                            
                        if (!encontrado)
                        {
                            Console.WriteLine("No encontrado");
                        }   
                    }                     
                    Console.WriteLine();
                    break;


                case (char)opciones.DETALLES:
                    Console.WriteLine("Detalles");
                    Console.WriteLine();
                    
                    if(contador == 0)
                    {
                        Console.WriteLine("No hay contactos");
                    }
                    
                    else
                    {
                        Console.Write("Número contacto: ");
                        numero = Convert.ToUInt16(Console.ReadLine());
                    
                        if (numero > contador || numero <= 0)
                        {
                            Console.WriteLine("Contacto erróneo");
                        }
                        
                        else
                        {
                            Console.WriteLine("Contacto {0}",
                                numero);
                            Console.WriteLine("Nombre: {0}", 
                                contacto[numero-1].nombre);
                            Console.WriteLine("Correo electrónico: {0}", 
                                contacto[numero-1].correo);
                            Console.WriteLine("Año de nacimiento: {0}", 
                                contacto[numero-1].anyo);
                            Console.WriteLine("Aficiones: {0}", 
                                contacto[numero-1].aficiones);
                            Console.WriteLine("Estatura: {0}", 
                                contacto[numero-1].estatura);
                            Console.WriteLine("Comentarios: {0}", 
                                contacto[numero-1].comentarios);
                        }
                    }
                    Console.WriteLine();
                    break;


                case (char)opciones.MODIFICAR:
                    Console.WriteLine("Modificar");
                    Console.WriteLine();
                    
                     if(contador == 0)
                    {
                        Console.WriteLine("No hay contactos");
                    }
                    
                    else
                    {
                        Console.Write("Número de contacto a modificar: ");
                        numero = Convert.ToUInt16(Console.ReadLine());
                    
                        if(numero > contador)
                        {
                            Console.WriteLine("Contacto erróneo");
                        }
                        
                        else
                        {
                            Console.WriteLine
                                ("Contacto {0}",numero);
                            Console.Write
                                ("Nombre: {0} / Modificar o pulsar INTRO para dejar: ", 
                                contacto[numero-1].nombre);
                                
                            respuesta = Console.ReadLine();
                            
                            if (respuesta == "")
                            {
                                contacto[numero-1].nombre = 
                                    contacto[numero-1].nombre;
                            }
                            
                            else
                            {
                                contacto[numero-1].nombre = respuesta;
                            }
                            
                            Console.Write
                                ("Correo electrónico: {0} / Modificar o " +
                                    "pulsar INTRO para dejar: ", 
                                    contacto[numero-1].correo);
                                    
                            respuesta = Console.ReadLine();
                            
                            if (respuesta == "")
                            {
                                contacto[numero-1].correo = 
                                    contacto[numero-1].correo;
                            }
                            
                            else
                            {
                                contacto[numero-1].correo = respuesta;
                            }
                            
                            Console.Write("Año de nacimiento: {0} / " +
                                "Modificar o pulsar INTRO para dejar: ", 
                                contacto[numero-1].anyo);
                                
                            respuesta = Console.ReadLine();
                            
                            if (respuesta == "")
                            {
                                contacto[numero-1].anyo = 
                                    contacto[numero-1].anyo;
                            }
                            
                            else
                            {
                                contacto[numero-1].anyo = 
                                    Convert.ToUInt16(respuesta);
                            }
                            
                            Console.Write("Aficiones: {0} / " +
                                "Modificar o pulsar INTRO para dejar: ", 
                                contacto[numero-1].aficiones);
                                
                            respuesta = Console.ReadLine();
                            
                            if (respuesta == "")
                            {
                                contacto[numero-1].aficiones = 
                                    contacto[numero-1].aficiones;
                            }
                            
                            else
                            {
                                contacto[numero-1].aficiones = respuesta;
                            }
                            
                            Console.Write("Estatura: {0} / Modificar o " +
                                "pulsar INTRO para dejar: ", 
                                contacto[numero-1].estatura);
                                
                            respuesta = Console.ReadLine();
                            
                            if (respuesta == "")
                            {
                                contacto[numero-1].estatura = 
                                    contacto[numero-1].estatura;
                            }
                            
                            else
                            {
                                contacto[numero-1].estatura = 
                                    Convert.ToSingle(respuesta);
                            }
                            
                            Console.Write("Comentarios: {0} / Modificar" +
                                "  o pulsar INTRO para dejar: ", 
                                contacto[numero-1].comentarios);
                                
                            respuesta = Console.ReadLine();
                            
                            if (respuesta == "")
                            {
                                contacto[numero-1].comentarios = 
                                    contacto[numero-1].comentarios;
                            }
                            
                            else
                            {
                                contacto[numero-1].comentarios = respuesta;
                            }
                        }
                    }
                    
                    Console.WriteLine();
                    break;

                case (char)opciones.BORRAR:
                    Console.WriteLine("Borrar");
                    Console.WriteLine();
                    
                    if(contador == 0)
                    {
                        Console.WriteLine("No hay contactos");
                    }
                    
                    else
                    {
                        Console.Write("Número de contacto a eliminar: ");
                        int num = Convert.ToInt32(Console.ReadLine()) -1;
                    
                        if(num >= contador || contador == 0)
                        {
                            Console.WriteLine("Contacto erróneo");
                        }
                        
                        else
                        {
                            Console.Write
                                ((num) + ". " +
                                contacto[num].nombre + ", " +
                                contacto[num].correo + " (nacido en " +
                                contacto[num].anyo + ") "+
                                contacto[num].aficiones + ", (con " +
                                contacto[num].estatura + "m) " +
                                contacto[num].comentarios);
                            
                            Console.Write
                                (" Seguro que quieres eliminar? (Y/N): ");
                            confirmar = Convert.ToChar(Console.ReadLine());
                            
                            if (confirmar == 'y' || confirmar == 'Y')
                            {
                                for (int i = num; i < contador; i++)
                                {
                                    contacto[i] = contacto[i + 1];
                                }
                                contador--;
                                Console.WriteLine("Contacto borrado");
                            }
                            
                            else if(confirmar == 'n' || confirmar == 'N')
                            {
                                contacto[num] = contacto[num];
                                Console.WriteLine("Opción cancelada");
                            }
                            
                            else
                            {
                                Console.WriteLine("Opcción incorrecta");
                            }
                        }
                    }
                    
                    Console.WriteLine();
                    break;

                case (char)opciones.ORDENAR:
                    Console.WriteLine("Ordenar");
                    Console.WriteLine();
                    
                    if(contador == 0)
                    {
                        Console.WriteLine("No hay contactos");
                    }
                    
                    else
                    {
                        for(int i = 0; i < contador -1 ; i++)
                        {
                            for(int j = i +1; j < contador; j++)
                            {
                                if (String.Compare(contacto[i].nombre,
                                    contacto[j].nombre, true) > 0)
                                    {
                                        datos aux = contacto[i];
                                        contacto[i] = contacto[j];
                                        contacto[j] = aux;
                                    }
                            }
                        }
                        
                        Console.WriteLine("Contactos ordenados");
                    }
                    
                    break;

                case (char)opciones.ESTADISTICAS:
                    Console.WriteLine("Estadísticas");
                    Console.WriteLine();
                    
                    if(contador == 0)
                    {
                        Console.WriteLine("No hay contactos");
                    }
                    
                    else
                    {
                        float resultado = 0;
                        float  suma = 0;
                        int  contador2 = 0, contador3 = 0; 
                        
                        Console.WriteLine("Número de contactos: {0}", contador);
                        Console.Write("Edad media total: ");
                        for(int i = 0; i < contador; i++)
                        {
                            if(contacto[i].anyo == 0)
                            {
                                suma = 0;
                                contador2++;
                            }
                            
                            else
                            {
                                suma = 2021 - contacto[i].anyo;
                                contador3++;
                            }
                            
                            resultado += suma;
                        }
                        
                        Console.WriteLine
                            ((resultado/(contador3 - contador2)).ToString("N2")); 
                        
                        contador3 = 0;
                        contador2 = 0;
                        resultado = 0;
                        suma = 0;
                        Console.Write("Estatura media total: ");
                        for(int i = 0; i < contador; i++)
                        {
                            if(contacto[i].estatura == 0)
                            {
                                suma = 0;
                                contador2++;
                            }
                            
                            else
                            {
                                suma = contacto[i].estatura;
                                contador3++;
                            }
                            
                            resultado += suma;
                        }
                        
                        Console.WriteLine
                            ((resultado/(contador3 - contador2)).ToString("N2")); 
                    }
                    
                    break;

                case (char)opciones.CORREGIR:
                    Console.WriteLine("Corregir");
                    Console.WriteLine();
                    
                    if(contador == 0)
                    {
                        Console.WriteLine("No hay contactos");
                    }
                    
                    else
                    {
                        for (int i = 0; i < contador; i++)
                        {
                            contacto[i].nombre.Trim();
                            contacto[i].aficiones.Trim();
                            contacto[i].comentarios.Trim();
                            
                            if(contacto[i].estatura < 0 || 
                                contacto[i].estatura > 3)
                                {
                                    contacto[i].estatura = 0;
                                }
                            
                            if(contacto[i].anyo < 1850 || 
                                contacto[i].anyo > 2100)
                                {
                                    contacto[i].anyo = 0;
                                }
                        }
                    
                    Console.WriteLine("Errores corregidos");
                    
                    }
                    
                    break;

                case 's':
                case 'S':
                    Console.WriteLine("Salir");
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Elección incorrecta");
                    break;
            }
            
            Console.WriteLine("Pulsa INTRO para continuar...");
            Console.ReadLine();
        }

        while (eleccionUsuario != 's' && eleccionUsuario != 'S');

        Console.WriteLine("Agenda cerrada");
    }
}
