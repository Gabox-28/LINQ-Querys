// See https://aka.ms/new-console-template for more information

using LINQProject;

LinqQueries queries = new LinqQueries();

//Tola la coleccion
//ImprimirValores(queries.TodaLaColeccion());

//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesdel2000());

//Libros que tienen mas de 250 paginas y tienen en el titulo la frase in Action
//ImprimirValores(queries.LibrosM250InAction());

//Todos los libros tienen status
//Console.WriteLine($" ¿Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");

//Hay libros publicados en 2005
//Console.WriteLine($" ¿Hay libros que hayan sido publicados en 2005 ? - {queries.HayLibrosPublicadosEn2005()}");

//Libros de python
//ImprimirValores(queries.LibrosDePython());

//Libros de Java ordenados por nombre
//ImprimirValores(queries.LibrosDeJavaPorNombreAscendente());

//Libros con mas de 450 paginas ordenados de manera descendente
//ImprimirValores(queries.LibrosConMasDe450PaginasDescendentes());

//Los 3 libros de java mas recientes
//ImprimirValores(queries.LibrosDeJavaMasRecientes());

//Tercer y cuarto libros con mas de 400 paginas
//ImprimirValores(queries.TercerYCuartoLibroDeMas400Pag());

//Tres primero libtros filtrados con Select
//ImprimirValores(queries.TresPrimeroLibrosDeLaColeccion());

//Cantidad de libros que tienen entre 200 y 500 paginas
//Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500 paginas: {queries.CantidadDeLibrosEntre200y500Pag()}");

//Fecha de publicacion menor de todos los libros
//Console.WriteLine($"La fecha de publicacion menor es: {queries.FechaDePublicacionMenor()}");

//Mayor cantidad de paginas de un libro
//Console.WriteLine($"La mayor cantidad de paginas que tiene un libro es: {queries.MayorNumerosDePaginas()}");

//Libro con menor numero de paginas
//var libroMenor = queries.LibroConMenorNumeroDePaginas();
//Console.WriteLine($"{libroMenor.Title} - {libroMenor.PageCount}");

//Libro mas reciente
//var libroReciente = queries.LibroMasReciente();
//Console.WriteLine($"{libroReciente.Title} - {libroReciente.PublishedDate.ToShortDateString()}");

//Suma de paginas de libros entre 0 y 500
//Console.WriteLine($"La suma total de paginas: {queries.SumaDeTodasLasPaginasDeLibrosEntre0y500()}");

//Libros publicados despues del 2015
//Console.WriteLine(queries.TitulosDeLibrosDespuesDel2015());

//El promedio de caracteres del titulo de los libros
//Console.WriteLine($"El promedio de caracteres de los titulos es: {queries.PromedioCaracteresTitulo()}");

//Libros publicados despues del 2000 agrupados
//ImprimirGrupo(queries.LibrosDespuesDel2000Agrupados());

//Diccionario de libros agrupados por primera letra del titulo
//var diccionarioLookup = queries.DiccionariosDeLibrosPorLetra();
//ImprimirDiccionario(diccionarioLookup, 'P');

//Libros filtrados con la clausula join
ImprimirValores(queries.LibrosDespuesDel2005ConMasDe500Pag());

void ImprimirValores(IEnumerable<Book>? listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in listadelibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> bookList, char letter)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in bookList[letter])
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
    }

}