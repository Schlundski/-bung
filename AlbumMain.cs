using System;

class Program
{
    static void Main()
    {
        //An dieser Stelle, statt die Alben selbst zu deklarieren könntest mit einem foreach
        //den Reader benutzen 
        Album[] albums = new Album[]
        {
            new Album
            {
                Index = 0,
                Name = "album1",
                Songs = new string[] { "song1", "song2" }
            },
            new Album
            {
                Index = 1,
                Name = "album2",
                Songs = new string[] { "song1", "song2" }
            }
        };

        //Statt dem do while könntest du dann die alben so wiedergeben 
        //(Statt Console.Writeline gibst du es halt an dein Frontend weiter)  
        foreach (var album in albums)
        {
            Console.WriteLine($"Index: {album.Index}");
            Console.WriteLine($"Name: {album.Name}");
            Console.WriteLine("Songs: " + string.Join(", ", album.Songs));
            Console.WriteLine();
        }
    }
}
