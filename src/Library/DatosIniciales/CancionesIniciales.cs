using System;
using System.Collections.Generic;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.DatosIniciales;

/// <summary>
/// Carga canciones iniciales en el catálogo del sistema.
/// </summary>
public static class CancionesIniciales
{
    /// <summary>
    /// Agrega canciones iniciales a la fachada recibida.
    /// </summary>
    /// <param name="fachada">Fachada del sistema donde se cargarán las canciones.</param>
    public static void Cargar(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);

        Agregar(fachada, 1, "Bohemian Rhapsody", "Queen", "rock", "clasico", "vocal");
        Agregar(fachada, 2, "Imagine", "John Lennon", "pop", "clasico", "piano");
        Agregar(fachada, 3, "Billie Jean", "Michael Jackson", "pop", "clasico", "baile");
        Agregar(fachada, 4, "Thriller", "Michael Jackson", "pop", "clasico", "baile");
        Agregar(fachada, 5, "Smells Like Teen Spirit", "Nirvana", "rock", "grunge", "clasico");
        Agregar(fachada, 6, "Like a Rolling Stone", "Bob Dylan", "rock", "clasico", "folk");
        Agregar(fachada, 7, "Hotel California", "Eagles", "rock", "clasico", "guitarra");
        Agregar(fachada, 8, "Hey Jude", "The Beatles", "rock", "clasico", "vocal");
        Agregar(fachada, 9, "Let It Be", "The Beatles", "rock", "clasico", "piano");
        Agregar(fachada, 10, "Yesterday", "The Beatles", "pop", "clasico", "romantica");
        Agregar(fachada, 11, "Rolling in the Deep", "Adele", "pop", "soul", "vocal");
        Agregar(fachada, 12, "Someone Like You", "Adele", "pop", "romantica", "vocal");
        Agregar(fachada, 13, "Shape of You", "Ed Sheeran", "pop", "moderno", "baile");
        Agregar(fachada, 14, "Perfect", "Ed Sheeran", "pop", "romantica", "vocal");
        Agregar(fachada, 15, "Blinding Lights", "The Weeknd", "pop", "electronica", "moderno");
        Agregar(fachada, 16, "Starboy", "The Weeknd", "pop", "electronica", "moderno");
        Agregar(fachada, 17, "Uptown Funk", "Mark Ronson ft. Bruno Mars", "pop", "funk", "baile");
        Agregar(fachada, 18, "Locked Out of Heaven", "Bruno Mars", "pop", "funk", "baile");
        Agregar(fachada, 19, "Just the Way You Are", "Bruno Mars", "pop", "romantica", "vocal");
        Agregar(fachada, 20, "Thinking Out Loud", "Ed Sheeran", "pop", "romantica", "vocal");
        Agregar(fachada, 21, "Viva La Vida", "Coldplay", "pop", "rock", "moderno");
        Agregar(fachada, 22, "Yellow", "Coldplay", "rock", "alternativo", "romantica");
        Agregar(fachada, 23, "Paradise", "Coldplay", "pop", "rock", "moderno");
        Agregar(fachada, 24, "Fix You", "Coldplay", "rock", "emocional", "vocal");
        Agregar(fachada, 25, "Wonderwall", "Oasis", "rock", "alternativo", "clasico");
        Agregar(fachada, 26, "Don't Look Back in Anger", "Oasis", "rock", "alternativo", "clasico");
        Agregar(fachada, 27, "Creep", "Radiohead", "rock", "alternativo", "emocional");
        Agregar(fachada, 28, "No Surprises", "Radiohead", "rock", "alternativo", "tranquila");
        Agregar(fachada, 29, "Losing My Religion", "R.E.M.", "rock", "alternativo", "clasico");
        Agregar(fachada, 30, "Everybody Hurts", "R.E.M.", "rock", "emocional", "clasico");
        Agregar(fachada, 31, "Sweet Child O' Mine", "Guns N' Roses", "rock", "clasico", "guitarra");
        Agregar(fachada, 32, "November Rain", "Guns N' Roses", "rock", "clasico", "romantica");
        Agregar(fachada, 33, "Back in Black", "AC/DC", "rock", "clasico", "guitarra");
        Agregar(fachada, 34, "Highway to Hell", "AC/DC", "rock", "clasico", "fiesta");
        Agregar(fachada, 35, "Enter Sandman", "Metallica", "metal", "rock", "guitarra");
        Agregar(fachada, 36, "Nothing Else Matters", "Metallica", "metal", "rock", "romantica");
        Agregar(fachada, 37, "Another Brick in the Wall", "Pink Floyd", "rock", "clasico", "progresivo");
        Agregar(fachada, 38, "Wish You Were Here", "Pink Floyd", "rock", "clasico", "romantica");
        Agregar(fachada, 39, "Comfortably Numb", "Pink Floyd", "rock", "clasico", "guitarra");
        Agregar(fachada, 40, "Stairway to Heaven", "Led Zeppelin", "rock", "clasico", "guitarra");
        Agregar(fachada, 41, "Kashmir", "Led Zeppelin", "rock", "clasico", "progresivo");
        Agregar(fachada, 42, "Livin' on a Prayer", "Bon Jovi", "rock", "clasico", "motivacional");
        Agregar(fachada, 43, "It's My Life", "Bon Jovi", "rock", "motivacional", "fiesta");
        Agregar(fachada, 44, "Eye of the Tiger", "Survivor", "rock", "motivacional", "clasico");
        Agregar(fachada, 45, "We Will Rock You", "Queen", "rock", "clasico", "motivacional");
        Agregar(fachada, 46, "We Are the Champions", "Queen", "rock", "clasico", "motivacional");
        Agregar(fachada, 47, "Another One Bites the Dust", "Queen", "rock", "funk", "baile");
        Agregar(fachada, 48, "Don't Stop Me Now", "Queen", "rock", "fiesta", "clasico");
        Agregar(fachada, 49, "I Want to Break Free", "Queen", "rock", "pop", "clasico");
        Agregar(fachada, 50, "Africa", "Toto", "pop", "rock", "clasico");
        Agregar(fachada, 51, "Take On Me", "a-ha", "pop", "electronica", "clasico");
        Agregar(fachada, 52, "Sweet Dreams", "Eurythmics", "pop", "electronica", "clasico");
        Agregar(fachada, 53, "Girls Just Want to Have Fun", "Cyndi Lauper", "pop", "fiesta", "clasico");
        Agregar(fachada, 54, "Dancing Queen", "ABBA", "pop", "disco", "baile");
        Agregar(fachada, 55, "Mamma Mia", "ABBA", "pop", "clasico", "fiesta");
        Agregar(fachada, 56, "Stayin' Alive", "Bee Gees", "disco", "funk", "baile");
        Agregar(fachada, 57, "September", "Earth, Wind & Fire", "funk", "disco", "baile");
        Agregar(fachada, 58, "Bad Guy", "Billie Eilish", "pop", "moderno", "electronica");
        Agregar(fachada, 59, "Ocean Eyes", "Billie Eilish", "pop", "triste", "moderno");
        Agregar(fachada, 60, "Levitating", "Dua Lipa", "pop", "disco", "baile");
        Agregar(fachada, 61, "Don't Start Now", "Dua Lipa", "pop", "disco", "baile");
        Agregar(fachada, 62, "New Rules", "Dua Lipa", "pop", "baile", "moderno");
        Agregar(fachada, 63, "Flowers", "Miley Cyrus", "pop", "moderno", "vocal");
        Agregar(fachada, 64, "Wrecking Ball", "Miley Cyrus", "pop", "emocional", "vocal");
        Agregar(fachada, 65, "Poker Face", "Lady Gaga", "pop", "baile", "electronica");
        Agregar(fachada, 66, "Bad Romance", "Lady Gaga", "pop", "baile", "electronica");
        Agregar(fachada, 67, "Shallow", "Lady Gaga and Bradley Cooper", "pop", "romantica", "vocal");
        Agregar(fachada, 68, "Halo", "Beyonce", "pop", "rnb", "vocal");
        Agregar(fachada, 69, "Crazy in Love", "Beyonce ft. Jay-Z", "pop", "rnb", "baile");
        Agregar(fachada, 70, "Single Ladies", "Beyonce", "pop", "baile", "rnb");
        Agregar(fachada, 71, "Umbrella", "Rihanna ft. Jay-Z", "pop", "rnb", "baile");
        Agregar(fachada, 72, "Diamonds", "Rihanna", "pop", "rnb", "vocal");
        Agregar(fachada, 73, "We Found Love", "Rihanna", "pop", "electronica", "baile");
        Agregar(fachada, 74, "Work", "Rihanna ft. Drake", "pop", "rnb", "baile");
        Agregar(fachada, 75, "Hotline Bling", "Drake", "rap", "rnb", "moderno");
        Agregar(fachada, 76, "God's Plan", "Drake", "rap", "hiphop", "moderno");
        Agregar(fachada, 77, "One Dance", "Drake", "pop", "baile", "moderno");
        Agregar(fachada, 78, "Lose Yourself", "Eminem", "rap", "hiphop", "motivacional");
        Agregar(fachada, 79, "Without Me", "Eminem", "rap", "hiphop", "fiesta");
        Agregar(fachada, 80, "Stan", "Eminem", "rap", "hiphop", "triste");
        Agregar(fachada, 81, "In Da Club", "50 Cent", "rap", "hiphop", "fiesta");
        Agregar(fachada, 82, "Empire State of Mind", "Jay-Z and Alicia Keys", "rap", "pop", "motivacional");
        Agregar(fachada, 83, "California Love", "2Pac", "rap", "hiphop", "clasico");
        Agregar(fachada, 84, "Changes", "2Pac", "rap", "hiphop", "clasico");
        Agregar(fachada, 85, "Juicy", "The Notorious B.I.G.", "rap", "hiphop", "clasico");
        Agregar(fachada, 86, "Hey Ya!", "OutKast", "pop", "funk", "fiesta");
        Agregar(fachada, 87, "Ms. Jackson", "OutKast", "rap", "hiphop", "clasico");
        Agregar(fachada, 88, "Seven Nation Army", "The White Stripes", "rock", "alternativo", "guitarra");
        Agregar(fachada, 89, "Mr. Brightside", "The Killers", "rock", "alternativo", "fiesta");
        Agregar(fachada, 90, "Somebody Told Me", "The Killers", "rock", "alternativo", "fiesta");
        Agregar(fachada, 91, "Chasing Cars", "Snow Patrol", "rock", "romantica", "emocional");
        Agregar(fachada, 92, "Boulevard of Broken Dreams", "Green Day", "rock", "alternativo", "emocional");
        Agregar(fachada, 93, "American Idiot", "Green Day", "rock", "punk", "fiesta");
        Agregar(fachada, 94, "Basket Case", "Green Day", "rock", "punk", "clasico");
        Agregar(fachada, 95, "Numb", "Linkin Park", "rock", "alternativo", "emocional");
        Agregar(fachada, 96, "In the End", "Linkin Park", "rock", "rap", "emocional");
        Agregar(fachada, 97, "Crawling", "Linkin Park", "rock", "alternativo", "emocional");
        Agregar(fachada, 98, "Californication", "Red Hot Chili Peppers", "rock", "alternativo", "clasico");
        Agregar(fachada, 99, "Under the Bridge", "Red Hot Chili Peppers", "rock", "emocional", "clasico");
        Agregar(fachada, 100, "Scar Tissue", "Red Hot Chili Peppers", "rock", "alternativo", "clasico");
        Agregar(fachada, 101, "Hey, Soul Sister", "Train", "pop", "alegre", "romantica");
        Agregar(fachada, 102, "Counting Stars", "OneRepublic", "pop", "rock", "motivacional");
        Agregar(fachada, 103, "Apologize", "OneRepublic", "pop", "triste", "vocal");
        Agregar(fachada, 104, "Radioactive", "Imagine Dragons", "rock", "pop", "moderno");
        Agregar(fachada, 105, "Believer", "Imagine Dragons", "rock", "motivacional", "moderno");
        Agregar(fachada, 106, "Demons", "Imagine Dragons", "rock", "emocional", "moderno");
        Agregar(fachada, 107, "Wake Me Up", "Avicii", "electronica", "pop", "motivacional");
        Agregar(fachada, 108, "Levels", "Avicii", "electronica", "baile", "fiesta");
        Agregar(fachada, 109, "Hey Brother", "Avicii", "electronica", "country", "motivacional");
        Agregar(fachada, 110, "Titanium", "David Guetta ft. Sia", "electronica", "pop", "motivacional");
        Agregar(fachada, 111, "Chandelier", "Sia", "pop", "vocal", "emocional");
        Agregar(fachada, 112, "Cheap Thrills", "Sia", "pop", "baile", "fiesta");
        Agregar(fachada, 113, "Get Lucky", "Daft Punk ft. Pharrell Williams", "disco", "funk", "baile");
        Agregar(fachada, 114, "One More Time", "Daft Punk", "electronica", "baile", "fiesta");
        Agregar(fachada, 115, "Around the World", "Daft Punk", "electronica", "baile", "clasico");
        Agregar(fachada, 116, "Lean On", "Major Lazer and DJ Snake", "electronica", "baile", "moderno");
        Agregar(fachada, 117, "Closer", "The Chainsmokers ft. Halsey", "pop", "electronica", "moderno");
        Agregar(fachada, 118, "Something Just Like This", "The Chainsmokers and Coldplay", "pop", "electronica", "moderno");
        Agregar(fachada, 119, "Faded", "Alan Walker", "electronica", "triste", "moderno");
        Agregar(fachada, 120, "Animals", "Martin Garrix", "electronica", "baile", "fiesta");
        Agregar(fachada, 121, "Despacito", "Luis Fonsi ft. Daddy Yankee", "latino", "reggaeton", "baile");
        Agregar(fachada, 122, "Gasolina", "Daddy Yankee", "reggaeton", "latino", "fiesta");
        Agregar(fachada, 123, "La Bicicleta", "Carlos Vives and Shakira", "latino", "pop", "baile");
        Agregar(fachada, 124, "Hips Don't Lie", "Shakira ft. Wyclef Jean", "latino", "pop", "baile");
        Agregar(fachada, 125, "Waka Waka", "Shakira", "latino", "pop", "fiesta");
        Agregar(fachada, 126, "Whenever, Wherever", "Shakira", "latino", "pop", "baile");
        Agregar(fachada, 127, "Felices los 4", "Maluma", "reggaeton", "latino", "romantica");
        Agregar(fachada, 128, "Tusa", "Karol G and Nicki Minaj", "reggaeton", "latino", "baile");
        Agregar(fachada, 129, "Bichota", "Karol G", "reggaeton", "latino", "fiesta");
        Agregar(fachada, 130, "Provenza", "Karol G", "reggaeton", "latino", "baile");
        Agregar(fachada, 131, "Mi Gente", "J Balvin and Willy William", "reggaeton", "latino", "baile");
        Agregar(fachada, 132, "Ginza", "J Balvin", "reggaeton", "latino", "baile");
        Agregar(fachada, 133, "Safaera", "Bad Bunny", "reggaeton", "latino", "fiesta");
        Agregar(fachada, 134, "Dakiti", "Bad Bunny and Jhay Cortez", "reggaeton", "latino", "moderno");
        Agregar(fachada, 135, "Titi Me Pregunto", "Bad Bunny", "reggaeton", "latino", "fiesta");
        Agregar(fachada, 136, "Me Porto Bonito", "Bad Bunny and Chencho Corleone", "reggaeton", "latino", "baile");
        Agregar(fachada, 137, "I Like It", "Cardi B, Bad Bunny and J Balvin", "rap", "latino", "baile");
        Agregar(fachada, 138, "Bailando", "Enrique Iglesias", "latino", "pop", "baile");
        Agregar(fachada, 139, "Hero", "Enrique Iglesias", "pop", "romantica", "latino");
        Agregar(fachada, 140, "Vivir Mi Vida", "Marc Anthony", "salsa", "latino", "motivacional");
        Agregar(fachada, 141, "Valio la Pena", "Marc Anthony", "salsa", "latino", "romantica");
        Agregar(fachada, 142, "La Gozadera", "Gente de Zona ft. Marc Anthony", "salsa", "latino", "fiesta");
        Agregar(fachada, 143, "Danza Kuduro", "Don Omar and Lucenzo", "reggaeton", "latino", "fiesta");
        Agregar(fachada, 144, "Pobre Diabla", "Don Omar", "reggaeton", "latino", "romantica");
        Agregar(fachada, 145, "Ella y Yo", "Aventura", "bachata", "latino", "romantica");
        Agregar(fachada, 146, "Obsesion", "Aventura", "bachata", "latino", "romantica");
        Agregar(fachada, 147, "Propuesta Indecente", "Romeo Santos", "bachata", "latino", "romantica");
        Agregar(fachada, 148, "Eres Mia", "Romeo Santos", "bachata", "latino", "romantica");
        Agregar(fachada, 149, "La Bachata", "Manuel Turizo", "bachata", "latino", "romantica");
        Agregar(fachada, 150, "Ai Se Eu Te Pego", "Michel Telo", "latino", "pop", "baile");
        Agregar(fachada, 151, "Mas Que Nada", "Sergio Mendes", "latino", "fiesta", "clasico");
        Agregar(fachada, 152, "Macarena", "Los Del Rio", "latino", "baile", "fiesta");
        Agregar(fachada, 153, "Livin' la Vida Loca", "Ricky Martin", "latino", "pop", "baile");
        Agregar(fachada, 154, "La Copa de la Vida", "Ricky Martin", "latino", "pop", "motivacional");
        Agregar(fachada, 155, "Oye Como Va", "Santana", "latino", "rock", "guitarra");
        Agregar(fachada, 156, "Smooth", "Santana ft. Rob Thomas", "rock", "latino", "guitarra");
        Agregar(fachada, 157, "Corazon Espinado", "Santana ft. Mana", "rock", "latino", "romantica");
        Agregar(fachada, 158, "Rayando el Sol", "Mana", "rock", "latino", "romantica");
        Agregar(fachada, 159, "En el Muelle de San Blas", "Mana", "rock", "latino", "emocional");
        Agregar(fachada, 160, "De Musica Ligera", "Soda Stereo", "rock", "latino", "clasico");
        Agregar(fachada, 161, "Persiana Americana", "Soda Stereo", "rock", "latino", "clasico");
        Agregar(fachada, 162, "Tratame Suavemente", "Soda Stereo", "rock", "latino", "emocional");
        Agregar(fachada, 163, "Lamento Boliviano", "Enanitos Verdes", "rock", "latino", "clasico");
        Agregar(fachada, 164, "La Flaca", "Jarabe de Palo", "rock", "latino", "clasico");
        Agregar(fachada, 165, "Flaca", "Andres Calamaro", "rock", "latino", "romantica");
        Agregar(fachada, 166, "Mil Horas", "Los Abuelos de la Nada", "rock", "latino", "clasico");
        Agregar(fachada, 167, "Matador", "Los Fabulosos Cadillacs", "rock", "latino", "ska");
        Agregar(fachada, 168, "Mariposa Tecknicolor", "Fito Paez", "rock", "latino", "alegre");
        Agregar(fachada, 169, "El Amor Despues del Amor", "Fito Paez", "rock", "latino", "romantica");
        Agregar(fachada, 170, "Crimen", "Gustavo Cerati", "rock", "latino", "emocional");
        Agregar(fachada, 171, "Puente", "Gustavo Cerati", "rock", "latino", "moderno");
        Agregar(fachada, 172, "Zona de Promesas", "Gustavo Cerati", "rock", "latino", "emocional");
        Agregar(fachada, 173, "Colgando en tus Manos", "Carlos Baute and Marta Sanchez", "pop", "latino", "romantica");
        Agregar(fachada, 174, "Color Esperanza", "Diego Torres", "pop", "latino", "motivacional");
        Agregar(fachada, 175, "Limon y Sal", "Julieta Venegas", "pop", "latino", "romantica");
        Agregar(fachada, 176, "Me Voy", "Julieta Venegas", "pop", "latino", "emocional");
        Agregar(fachada, 177, "Andar Conmigo", "Julieta Venegas", "pop", "latino", "romantica");
        Agregar(fachada, 178, "La Camisa Negra", "Juanes", "pop", "latino", "fiesta");
        Agregar(fachada, 179, "A Dios le Pido", "Juanes", "pop", "latino", "motivacional");
        Agregar(fachada, 180, "Photograph", "Ed Sheeran", "pop", "romantica", "vocal");
        Agregar(fachada, 181, "All of Me", "John Legend", "pop", "romantica", "piano");
        Agregar(fachada, 182, "Stay With Me", "Sam Smith", "pop", "soul", "triste");
        Agregar(fachada, 183, "I'm Not the Only One", "Sam Smith", "pop", "soul", "triste");
        Agregar(fachada, 184, "Take Me to Church", "Hozier", "pop", "soul", "emocional");
        Agregar(fachada, 185, "Someone You Loved", "Lewis Capaldi", "pop", "triste", "vocal");
        Agregar(fachada, 186, "Drivers License", "Olivia Rodrigo", "pop", "triste", "moderno");
        Agregar(fachada, 187, "Good 4 U", "Olivia Rodrigo", "pop", "rock", "moderno");
        Agregar(fachada, 188, "Shake It Off", "Taylor Swift", "pop", "baile", "fiesta");
        Agregar(fachada, 189, "Blank Space", "Taylor Swift", "pop", "moderno", "romantica");
        Agregar(fachada, 190, "Love Story", "Taylor Swift", "country", "pop", "romantica");
        Agregar(fachada, 191, "Anti-Hero", "Taylor Swift", "pop", "moderno", "emocional");
        Agregar(fachada, 192, "As It Was", "Harry Styles", "pop", "moderno", "baile");
        Agregar(fachada, 193, "Watermelon Sugar", "Harry Styles", "pop", "baile", "moderno");
        Agregar(fachada, 194, "Sign of the Times", "Harry Styles", "pop", "emocional", "vocal");
        Agregar(fachada, 195, "Senorita", "Shawn Mendes and Camila Cabello", "pop", "latino", "romantica");
        Agregar(fachada, 196, "Havana", "Camila Cabello ft. Young Thug", "pop", "latino", "baile");
        Agregar(fachada, 197, "Old Town Road", "Lil Nas X", "country", "rap", "fiesta");
        Agregar(fachada, 198, "Dynamite", "BTS", "kpop", "pop", "baile");
        Agregar(fachada, 199, "Butter", "BTS", "kpop", "pop", "baile");
        Agregar(fachada, 200, "Gangnam Style", "PSY", "kpop", "pop", "baile");
    }

    /// <summary>
    /// Agrega una canción al catálogo evitando repetir la creación de listas en cada línea.
    /// </summary>
    private static void Agregar(
        FachadaProyecto fachada,
        int id,
        string nombre,
        string artista,
        params string[] atributos)
    {
        fachada.AgregarCancion(id, nombre, artista, new List<string>(atributos));
    }
}