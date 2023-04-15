using System.Collections;

namespace LINQProject;

public class LinqQueries
{
    private List<Book>? librosCollection = new List<Book>();
    
    public LinqQueries()
    {
        using var reader = new StreamReader("./books.json");
        var json = reader.ReadToEnd();
        librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public IEnumerable<Book>? TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesdel2000()
    {
        //Extension Method
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);
        
        //Query Expresion
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosM250InAction()
    {
        //Extension Method
        //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));
        
        //Query Expresion
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool HayLibrosPublicadosEn2005()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosDePython()
    {
        return from l in librosCollection where l.Categories.Contains("Python") select l;
    }

    public IEnumerable<Book> LibrosDeJavaPorNombreAscendente()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> LibrosConMasDe450PaginasDescendentes()
    {
        return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> LibrosDeJavaMasRecientes()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);
    }

    public IEnumerable<Book> TercerYCuartoLibroDeMas400Pag()
    {
        return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);
    }

    public IEnumerable<Book> TresPrimeroLibrosDeLaColeccion()
    {
        return librosCollection.Take(3).Select(p => new Book() { Title = p.Title, PageCount = p.PageCount});
    }

    public int CantidadDeLibrosEntre200y500Pag()
    {
        return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime FechaDePublicacionMenor()
    {
        return librosCollection.Min(p => p.PublishedDate);
    }

    public int MayorNumerosDePaginas()
    {
        return librosCollection.Max(p => p.PageCount);
    }

    public Book? LibroConMenorNumeroDePaginas()
    {
        return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    public Book LibroMasReciente()
    {
        return librosCollection.MaxBy(p => p.PublishedDate);
    }

    public int SumaDeTodasLasPaginasDeLibrosEntre0y500()
    {
        return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p=> p.PageCount);
    }

    public string TitulosDeLibrosDespuesDel2015()
    {
        return librosCollection.Where(p => p.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) =>
        {
            if (TitulosLibros != string.Empty)
            {
                TitulosLibros += " - " + next.Title;
            }
            else
            {
                TitulosLibros += next.Title;
            }

            return TitulosLibros;
        });
    }

    public double PromedioCaracteresTitulo()
    {
        return librosCollection.Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000Agrupados()
    {
        return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p => p.Title[0], p => p);
    }

    public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Pag()
    {
        var LibrosDespuesDel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);

        var LibrosConMasDe500Pag = librosCollection.Where(p => p.PageCount > 500);

        return LibrosDespuesDel2005.Join(LibrosConMasDe500Pag, p => p.Title, x => x.Title, (p,x) => p);
    }
}