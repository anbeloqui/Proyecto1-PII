using ProyectoPII.Modelos;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.DatosIniciales;

/// <summary>
/// Proporciona un conjunto inicial de películas para el catálogo del sistema.
/// </summary>
public static class PeliculasIniciales
{
    /// <summary>
    /// Agrega las películas iniciales a la fachada recibida.
    /// </summary>
    /// <param name="fachada">Fachada del sistema donde se cargarán las películas.</param>
    public static void Cargar(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);

        foreach (Pelicula pelicula in Obtener())
        {
            fachada.AgregarItem(pelicula);
        }
    }

    /// <summary>
    /// Obtiene la colección inicial de películas.
    /// </summary>
    /// <returns>Lista de películas predefinidas.</returns>
    public static List<Pelicula> Obtener()
    {
        return new List<Pelicula>
        {
            CrearPelicula(1001, "The Matrix", "Lana y Lilly Wachowski", "accion", "ciencia ficcion", "clasico"),
            CrearPelicula(1002, "Interstellar", "Christopher Nolan", "ciencia ficcion", "drama", "espacio"),
            CrearPelicula(1003, "El Señor de los Anillos: La Comunidad del Anillo", "Peter Jackson", "fantasia", "aventura", "epica"),
            CrearPelicula(1004, "El Señor de los Anillos: Las Dos Torres", "Peter Jackson", "fantasia", "aventura", "epica"),
            CrearPelicula(1005, "El Señor de los Anillos: El Retorno del Rey", "Peter Jackson", "fantasia", "aventura", "epica"),
            CrearPelicula(1006, "El Padrino", "Francis Ford Coppola", "drama", "crimen", "clasico"),
            CrearPelicula(1007, "El Padrino Parte II", "Francis Ford Coppola", "drama", "crimen", "clasico"),
            CrearPelicula(1008, "Toy Story", "John Lasseter", "animacion", "familia", "aventura"),
            CrearPelicula(1009, "Toy Story 2", "John Lasseter", "animacion", "familia", "aventura"),
            CrearPelicula(1010, "Toy Story 3", "Lee Unkrich", "animacion", "familia", "aventura"),

            CrearPelicula(1011, "Titanic", "James Cameron", "romantica", "drama", "clasico"),
            CrearPelicula(1012, "Avatar", "James Cameron", "ciencia ficcion", "aventura", "accion"),
            CrearPelicula(1013, "Avatar: El Camino del Agua", "James Cameron", "ciencia ficcion", "aventura", "accion"),
            CrearPelicula(1014, "Gladiador", "Ridley Scott", "accion", "drama", "historia"),
            CrearPelicula(1015, "Forrest Gump", "Robert Zemeckis", "drama", "comedia", "clasico"),
            CrearPelicula(1016, "Volver al Futuro", "Robert Zemeckis", "ciencia ficcion", "aventura", "comedia"),
            CrearPelicula(1017, "Volver al Futuro Parte II", "Robert Zemeckis", "ciencia ficcion", "aventura", "comedia"),
            CrearPelicula(1018, "Volver al Futuro Parte III", "Robert Zemeckis", "ciencia ficcion", "aventura", "western"),
            CrearPelicula(1019, "Jurassic Park", "Steven Spielberg", "aventura", "ciencia ficcion", "accion"),
            CrearPelicula(1020, "E.T. el Extraterrestre", "Steven Spielberg", "ciencia ficcion", "familia", "aventura"),

            CrearPelicula(1021, "Tiburón", "Steven Spielberg", "suspenso", "terror", "clasico"),
            CrearPelicula(1022, "Indiana Jones y los Cazadores del Arca Perdida", "Steven Spielberg", "aventura", "accion", "clasico"),
            CrearPelicula(1023, "Indiana Jones y la Última Cruzada", "Steven Spielberg", "aventura", "accion", "clasico"),
            CrearPelicula(1024, "La Lista de Schindler", "Steven Spielberg", "drama", "historia", "guerra"),
            CrearPelicula(1025, "Rescatando al Soldado Ryan", "Steven Spielberg", "guerra", "drama", "accion"),
            CrearPelicula(1026, "El Rey León", "Roger Allers y Rob Minkoff", "animacion", "familia", "musical"),
            CrearPelicula(1027, "Aladdin", "Ron Clements y John Musker", "animacion", "familia", "musical"),
            CrearPelicula(1028, "La Bella y la Bestia", "Gary Trousdale y Kirk Wise", "animacion", "familia", "musical"),
            CrearPelicula(1029, "Buscando a Nemo", "Andrew Stanton", "animacion", "familia", "aventura"),
            CrearPelicula(1030, "Los Increíbles", "Brad Bird", "animacion", "familia", "superheroes"),

            CrearPelicula(1031, "Up", "Pete Docter", "animacion", "familia", "aventura"),
            CrearPelicula(1032, "Coco", "Lee Unkrich", "animacion", "familia", "musical"),
            CrearPelicula(1033, "Intensa-Mente", "Pete Docter", "animacion", "familia", "comedia"),
            CrearPelicula(1034, "Monsters Inc.", "Pete Docter", "animacion", "familia", "comedia"),
            CrearPelicula(1035, "Shrek", "Andrew Adamson y Vicky Jenson", "animacion", "comedia", "familia"),
            CrearPelicula(1036, "Shrek 2", "Andrew Adamson", "animacion", "comedia", "familia"),
            CrearPelicula(1037, "Kung Fu Panda", "Mark Osborne y John Stevenson", "animacion", "accion", "familia"),
            CrearPelicula(1038, "Cómo Entrenar a tu Dragón", "Chris Sanders y Dean DeBlois", "animacion", "aventura", "familia"),
            CrearPelicula(1039, "Madagascar", "Eric Darnell y Tom McGrath", "animacion", "comedia", "familia"),
            CrearPelicula(1040, "Mi Villano Favorito", "Pierre Coffin y Chris Renaud", "animacion", "comedia", "familia"),

            CrearPelicula(1041, "Star Wars: Una Nueva Esperanza", "George Lucas", "ciencia ficcion", "aventura", "accion"),
            CrearPelicula(1042, "Star Wars: El Imperio Contraataca", "Irvin Kershner", "ciencia ficcion", "aventura", "accion"),
            CrearPelicula(1043, "Star Wars: El Retorno del Jedi", "Richard Marquand", "ciencia ficcion", "aventura", "accion"),
            CrearPelicula(1044, "Star Wars: La Amenaza Fantasma", "George Lucas", "ciencia ficcion", "aventura", "accion"),
            CrearPelicula(1045, "Star Wars: La Venganza de los Sith", "George Lucas", "ciencia ficcion", "aventura", "accion"),
            CrearPelicula(1046, "Rogue One", "Gareth Edwards", "ciencia ficcion", "accion", "aventura"),
            CrearPelicula(1047, "Harry Potter y la Piedra Filosofal", "Chris Columbus", "fantasia", "aventura", "familia"),
            CrearPelicula(1048, "Harry Potter y la Cámara Secreta", "Chris Columbus", "fantasia", "aventura", "familia"),
            CrearPelicula(1049, "Harry Potter y el Prisionero de Azkaban", "Alfonso Cuarón", "fantasia", "aventura", "familia"),
            CrearPelicula(1050, "Harry Potter y el Cáliz de Fuego", "Mike Newell", "fantasia", "aventura", "familia"),

            CrearPelicula(1051, "Harry Potter y la Orden del Fénix", "David Yates", "fantasia", "aventura", "drama"),
            CrearPelicula(1052, "Harry Potter y el Misterio del Príncipe", "David Yates", "fantasia", "aventura", "drama"),
            CrearPelicula(1053, "Harry Potter y las Reliquias de la Muerte Parte 1", "David Yates", "fantasia", "aventura", "drama"),
            CrearPelicula(1054, "Harry Potter y las Reliquias de la Muerte Parte 2", "David Yates", "fantasia", "aventura", "drama"),
            CrearPelicula(1055, "Piratas del Caribe: La Maldición del Perla Negra", "Gore Verbinski", "aventura", "accion", "fantasia"),
            CrearPelicula(1056, "Piratas del Caribe: El Cofre de la Muerte", "Gore Verbinski", "aventura", "accion", "fantasia"),
            CrearPelicula(1057, "Piratas del Caribe: En el Fin del Mundo", "Gore Verbinski", "aventura", "accion", "fantasia"),
            CrearPelicula(1058, "El Hobbit: Un Viaje Inesperado", "Peter Jackson", "fantasia", "aventura", "epica"),
            CrearPelicula(1059, "El Hobbit: La Desolación de Smaug", "Peter Jackson", "fantasia", "aventura", "epica"),
            CrearPelicula(1060, "El Hobbit: La Batalla de los Cinco Ejércitos", "Peter Jackson", "fantasia", "aventura", "epica"),

            CrearPelicula(1061, "Batman: El Caballero de la Noche", "Christopher Nolan", "accion", "crimen", "superheroes"),
            CrearPelicula(1062, "Batman Inicia", "Christopher Nolan", "accion", "crimen", "superheroes"),
            CrearPelicula(1063, "Batman: El Caballero de la Noche Asciende", "Christopher Nolan", "accion", "crimen", "superheroes"),
            CrearPelicula(1064, "Joker", "Todd Phillips", "drama", "crimen", "suspenso"),
            CrearPelicula(1065, "Superman", "Richard Donner", "superheroes", "accion", "clasico"),
            CrearPelicula(1066, "El Hombre de Acero", "Zack Snyder", "superheroes", "accion", "ciencia ficcion"),
            CrearPelicula(1067, "Wonder Woman", "Patty Jenkins", "superheroes", "accion", "aventura"),
            CrearPelicula(1068, "Aquaman", "James Wan", "superheroes", "accion", "aventura"),
            CrearPelicula(1069, "Spider-Man", "Sam Raimi", "superheroes", "accion", "aventura"),
            CrearPelicula(1070, "Spider-Man 2", "Sam Raimi", "superheroes", "accion", "aventura"),

            CrearPelicula(1071, "Spider-Man: Sin Camino a Casa", "Jon Watts", "superheroes", "accion", "aventura"),
            CrearPelicula(1072, "Spider-Man: Un Nuevo Universo", "Bob Persichetti, Peter Ramsey y Rodney Rothman", "animacion", "superheroes", "accion"),
            CrearPelicula(1073, "Iron Man", "Jon Favreau", "superheroes", "accion", "ciencia ficcion"),
            CrearPelicula(1074, "Capitán América: El Primer Vengador", "Joe Johnston", "superheroes", "accion", "aventura"),
            CrearPelicula(1075, "Capitán América: El Soldado del Invierno", "Anthony y Joe Russo", "superheroes", "accion", "suspenso"),
            CrearPelicula(1076, "Capitán América: Civil War", "Anthony y Joe Russo", "superheroes", "accion", "aventura"),
            CrearPelicula(1077, "Thor", "Kenneth Branagh", "superheroes", "accion", "fantasia"),
            CrearPelicula(1078, "Thor: Ragnarok", "Taika Waititi", "superheroes", "accion", "comedia"),
            CrearPelicula(1079, "Guardianes de la Galaxia", "James Gunn", "superheroes", "accion", "comedia"),
            CrearPelicula(1080, "Guardianes de la Galaxia Vol. 2", "James Gunn", "superheroes", "accion", "comedia"),

            CrearPelicula(1081, "Los Vengadores", "Joss Whedon", "superheroes", "accion", "ciencia ficcion"),
            CrearPelicula(1082, "Avengers: Infinity War", "Anthony y Joe Russo", "superheroes", "accion", "ciencia ficcion"),
            CrearPelicula(1083, "Avengers: Endgame", "Anthony y Joe Russo", "superheroes", "accion", "ciencia ficcion"),
            CrearPelicula(1084, "Black Panther", "Ryan Coogler", "superheroes", "accion", "aventura"),
            CrearPelicula(1085, "Doctor Strange", "Scott Derrickson", "superheroes", "fantasia", "accion"),
            CrearPelicula(1086, "Deadpool", "Tim Miller", "superheroes", "accion", "comedia"),
            CrearPelicula(1087, "Logan", "James Mangold", "superheroes", "accion", "drama"),
            CrearPelicula(1088, "X-Men", "Bryan Singer", "superheroes", "accion", "ciencia ficcion"),
            CrearPelicula(1089, "X-Men: Días del Futuro Pasado", "Bryan Singer", "superheroes", "accion", "ciencia ficcion"),
            CrearPelicula(1090, "El Club de la Pelea", "David Fincher", "drama", "suspenso", "clasico"),

            CrearPelicula(1091, "Seven", "David Fincher", "crimen", "suspenso", "misterio"),
            CrearPelicula(1092, "Zodiac", "David Fincher", "crimen", "misterio", "suspenso"),
            CrearPelicula(1093, "La Red Social", "David Fincher", "drama", "biografica", "tecnologia"),
            CrearPelicula(1094, "Perdida", "David Fincher", "suspenso", "misterio", "drama"),
            CrearPelicula(1095, "Pulp Fiction", "Quentin Tarantino", "crimen", "drama", "clasico"),
            CrearPelicula(1096, "Kill Bill Vol. 1", "Quentin Tarantino", "accion", "crimen", "venganza"),
            CrearPelicula(1097, "Kill Bill Vol. 2", "Quentin Tarantino", "accion", "crimen", "venganza"),
            CrearPelicula(1098, "Django Sin Cadenas", "Quentin Tarantino", "western", "accion", "drama"),
            CrearPelicula(1099, "Bastardos Sin Gloria", "Quentin Tarantino", "guerra", "drama", "accion"),
            CrearPelicula(1100, "Había una vez en Hollywood", "Quentin Tarantino", "drama", "comedia", "cine"),

            CrearPelicula(1101, "Goodfellas", "Martin Scorsese", "crimen", "drama", "clasico"),
            CrearPelicula(1102, "Taxi Driver", "Martin Scorsese", "drama", "crimen", "clasico"),
            CrearPelicula(1103, "El Lobo de Wall Street", "Martin Scorsese", "biografica", "drama", "comedia"),
            CrearPelicula(1104, "Los Infiltrados", "Martin Scorsese", "crimen", "suspenso", "drama"),
            CrearPelicula(1105, "Casino", "Martin Scorsese", "crimen", "drama", "clasico"),
            CrearPelicula(1106, "El Irlandés", "Martin Scorsese", "crimen", "drama", "historia"),
            CrearPelicula(1107, "Scarface", "Brian De Palma", "crimen", "drama", "clasico"),
            CrearPelicula(1108, "Los Intocables", "Brian De Palma", "crimen", "drama", "accion"),
            CrearPelicula(1109, "El Silencio de los Inocentes", "Jonathan Demme", "suspenso", "crimen", "misterio"),
            CrearPelicula(1110, "Psicosis", "Alfred Hitchcock", "terror", "suspenso", "clasico"),

            CrearPelicula(1111, "Vértigo", "Alfred Hitchcock", "suspenso", "misterio", "clasico"),
            CrearPelicula(1112, "La Ventana Indiscreta", "Alfred Hitchcock", "suspenso", "misterio", "clasico"),
            CrearPelicula(1113, "El Resplandor", "Stanley Kubrick", "terror", "suspenso", "clasico"),
            CrearPelicula(1114, "2001: Odisea del Espacio", "Stanley Kubrick", "ciencia ficcion", "clasico", "espacio"),
            CrearPelicula(1115, "Naranja Mecánica", "Stanley Kubrick", "drama", "ciencia ficcion", "clasico"),
            CrearPelicula(1116, "Cara de Guerra", "Stanley Kubrick", "guerra", "drama", "clasico"),
            CrearPelicula(1117, "La Naranja Mecánica", "Stanley Kubrick", "drama", "ciencia ficcion", "clasico"),
            CrearPelicula(1118, "Blade Runner", "Ridley Scott", "ciencia ficcion", "drama", "clasico"),
            CrearPelicula(1119, "Blade Runner 2049", "Denis Villeneuve", "ciencia ficcion", "drama", "suspenso"),
            CrearPelicula(1120, "Dune", "Denis Villeneuve", "ciencia ficcion", "aventura", "epica"),

            CrearPelicula(1121, "Dune: Parte Dos", "Denis Villeneuve", "ciencia ficcion", "aventura", "epica"),
            CrearPelicula(1122, "La Llegada", "Denis Villeneuve", "ciencia ficcion", "drama", "misterio"),
            CrearPelicula(1123, "Sicario", "Denis Villeneuve", "crimen", "suspenso", "accion"),
            CrearPelicula(1124, "Prisioneros", "Denis Villeneuve", "suspenso", "crimen", "drama"),
            CrearPelicula(1125, "Memento", "Christopher Nolan", "suspenso", "misterio", "drama"),
            CrearPelicula(1126, "El Origen", "Christopher Nolan", "ciencia ficcion", "accion", "suspenso"),
            CrearPelicula(1127, "Tenet", "Christopher Nolan", "ciencia ficcion", "accion", "suspenso"),
            CrearPelicula(1128, "Dunkerque", "Christopher Nolan", "guerra", "drama", "historia"),
            CrearPelicula(1129, "Oppenheimer", "Christopher Nolan", "biografica", "drama", "historia"),
            CrearPelicula(1130, "El Gran Truco", "Christopher Nolan", "misterio", "drama", "suspenso"),

            CrearPelicula(1131, "Misión Imposible", "Brian De Palma", "accion", "suspenso", "espionaje"),
            CrearPelicula(1132, "Misión Imposible: Protocolo Fantasma", "Brad Bird", "accion", "suspenso", "espionaje"),
            CrearPelicula(1133, "Misión Imposible: Nación Secreta", "Christopher McQuarrie", "accion", "suspenso", "espionaje"),
            CrearPelicula(1134, "Misión Imposible: Repercusión", "Christopher McQuarrie", "accion", "suspenso", "espionaje"),
            CrearPelicula(1135, "Top Gun", "Tony Scott", "accion", "drama", "clasico"),
            CrearPelicula(1136, "Top Gun: Maverick", "Joseph Kosinski", "accion", "drama", "aventura"),
            CrearPelicula(1137, "Terminator", "James Cameron", "accion", "ciencia ficcion", "clasico"),
            CrearPelicula(1138, "Terminator 2: El Juicio Final", "James Cameron", "accion", "ciencia ficcion", "clasico"),
            CrearPelicula(1139, "Alien", "Ridley Scott", "terror", "ciencia ficcion", "clasico"),
            CrearPelicula(1140, "Aliens", "James Cameron", "accion", "ciencia ficcion", "terror"),

            CrearPelicula(1141, "Depredador", "John McTiernan", "accion", "ciencia ficcion", "terror"),
            CrearPelicula(1142, "Duro de Matar", "John McTiernan", "accion", "clasico", "suspenso"),
            CrearPelicula(1143, "Mad Max: Furia en el Camino", "George Miller", "accion", "ciencia ficcion", "aventura"),
            CrearPelicula(1144, "John Wick", "Chad Stahelski", "accion", "crimen", "suspenso"),
            CrearPelicula(1145, "John Wick 2", "Chad Stahelski", "accion", "crimen", "suspenso"),
            CrearPelicula(1146, "John Wick 3", "Chad Stahelski", "accion", "crimen", "suspenso"),
            CrearPelicula(1147, "John Wick 4", "Chad Stahelski", "accion", "crimen", "suspenso"),
            CrearPelicula(1148, "Rápidos y Furiosos", "Rob Cohen", "accion", "autos", "crimen"),
            CrearPelicula(1149, "Rápidos y Furiosos 5", "Justin Lin", "accion", "autos", "crimen"),
            CrearPelicula(1150, "Rápidos y Furiosos 7", "James Wan", "accion", "autos", "crimen"),

            CrearPelicula(1151, "Rocky", "John G. Avildsen", "drama", "deporte", "motivacional"),
            CrearPelicula(1152, "Rocky IV", "Sylvester Stallone", "drama", "deporte", "motivacional"),
            CrearPelicula(1153, "Creed", "Ryan Coogler", "drama", "deporte", "motivacional"),
            CrearPelicula(1154, "Karate Kid", "John G. Avildsen", "drama", "deporte", "familia"),
            CrearPelicula(1155, "Million Dollar Baby", "Clint Eastwood", "drama", "deporte", "emocional"),
            CrearPelicula(1156, "Rush", "Ron Howard", "drama", "deporte", "biografica"),
            CrearPelicula(1157, "Ford v Ferrari", "James Mangold", "drama", "deporte", "autos"),
            CrearPelicula(1158, "La La Land", "Damien Chazelle", "musical", "romantica", "drama"),
            CrearPelicula(1159, "Whiplash", "Damien Chazelle", "drama", "musical", "motivacional"),
            CrearPelicula(1160, "El Gran Showman", "Michael Gracey", "musical", "drama", "familia"),

            CrearPelicula(1161, "Moulin Rouge", "Baz Luhrmann", "musical", "romantica", "drama"),
            CrearPelicula(1162, "Chicago", "Rob Marshall", "musical", "crimen", "drama"),
            CrearPelicula(1163, "Mamma Mia!", "Phyllida Lloyd", "musical", "comedia", "romantica"),
            CrearPelicula(1164, "Grease", "Randal Kleiser", "musical", "romantica", "clasico"),
            CrearPelicula(1165, "Cantando Bajo la Lluvia", "Gene Kelly y Stanley Donen", "musical", "romantica", "clasico"),
            CrearPelicula(1166, "El Diario de una Pasión", "Nick Cassavetes", "romantica", "drama", "emocional"),
            CrearPelicula(1167, "Orgullo y Prejuicio", "Joe Wright", "romantica", "drama", "clasico"),
            CrearPelicula(1168, "Antes del Amanecer", "Richard Linklater", "romantica", "drama", "dialogo"),
            CrearPelicula(1169, "500 Días con Ella", "Marc Webb", "romantica", "comedia", "drama"),
            CrearPelicula(1170, "Cuestión de Tiempo", "Richard Curtis", "romantica", "comedia", "drama"),

            CrearPelicula(1171, "Realmente Amor", "Richard Curtis", "romantica", "comedia", "navidad"),
            CrearPelicula(1172, "Notting Hill", "Roger Michell", "romantica", "comedia", "clasico"),
            CrearPelicula(1173, "Mujer Bonita", "Garry Marshall", "romantica", "comedia", "clasico"),
            CrearPelicula(1174, "Loco y Estúpido Amor", "Glenn Ficarra y John Requa", "romantica", "comedia", "drama"),
            CrearPelicula(1175, "¿Qué Pasó Ayer?", "Todd Phillips", "comedia", "fiesta", "aventura"),
            CrearPelicula(1176, "Superbad", "Greg Mottola", "comedia", "juventud", "fiesta"),
            CrearPelicula(1177, "American Pie", "Paul Weitz", "comedia", "juventud", "fiesta"),
            CrearPelicula(1178, "Son Como Niños", "Dennis Dugan", "comedia", "familia", "amistad"),
            CrearPelicula(1179, "La Máscara", "Chuck Russell", "comedia", "fantasia", "clasico"),
            CrearPelicula(1180, "Mentiroso Mentiroso", "Tom Shadyac", "comedia", "familia", "clasico"),

            CrearPelicula(1181, "El Show de Truman", "Peter Weir", "drama", "comedia", "clasico"),
            CrearPelicula(1182, "Una Mente Brillante", "Ron Howard", "biografica", "drama", "emocional"),
            CrearPelicula(1183, "En Busca de la Felicidad", "Gabriele Muccino", "drama", "biografica", "motivacional"),
            CrearPelicula(1184, "El Discurso del Rey", "Tom Hooper", "biografica", "drama", "historia"),
            CrearPelicula(1185, "Bohemian Rhapsody", "Bryan Singer", "biografica", "musical", "drama"),
            CrearPelicula(1186, "Rocketman", "Dexter Fletcher", "biografica", "musical", "drama"),
            CrearPelicula(1187, "El Pianista", "Roman Polanski", "drama", "guerra", "biografica"),
            CrearPelicula(1188, "La Vida es Bella", "Roberto Benigni", "drama", "guerra", "emocional"),
            CrearPelicula(1189, "Parásitos", "Bong Joon-ho", "drama", "suspenso", "comedia"),
            CrearPelicula(1190, "El Laberinto del Fauno", "Guillermo del Toro", "fantasia", "drama", "guerra"),

            CrearPelicula(1191, "Roma", "Alfonso Cuarón", "drama", "historia", "emocional"),
            CrearPelicula(1192, "Birdman", "Alejandro González Iñárritu", "drama", "comedia", "cine"),
            CrearPelicula(1193, "El Renacido", "Alejandro González Iñárritu", "aventura", "drama", "supervivencia"),
            CrearPelicula(1194, "Gravity", "Alfonso Cuarón", "ciencia ficcion", "drama", "espacio"),
            CrearPelicula(1195, "El Proyecto de la Bruja de Blair", "Daniel Myrick y Eduardo Sánchez", "terror", "suspenso", "misterio"),
            CrearPelicula(1196, "El Conjuro", "James Wan", "terror", "suspenso", "sobrenatural"),
            CrearPelicula(1197, "It", "Andy Muschietti", "terror", "suspenso", "sobrenatural"),
            CrearPelicula(1198, "Actividad Paranormal", "Oren Peli", "terror", "suspenso", "sobrenatural"),
            CrearPelicula(1199, "Hereditary", "Ari Aster", "terror", "drama", "suspenso"),
            CrearPelicula(1200, "Midsommar", "Ari Aster", "terror", "drama", "suspenso")
        };
    }

    /// <summary>
    /// Crea una película con sus datos principales y atributos asociados.
    /// </summary>
    /// <param name="id">Identificador único de la película.</param>
    /// <param name="nombre">Nombre de la película.</param>
    /// <param name="director">Director de la película.</param>
    /// <param name="atributos">Atributos utilizados para recomendar la película.</param>
    /// <returns>Película creada.</returns>
    private static Pelicula CrearPelicula(
        int id,
        string nombre,
        string director,
        params string[] atributos)
    {
        return new Pelicula
        {
            Id = id,
            Nombre = nombre,
            Director = director,
            Atributos = new List<string>(atributos)
        };
    }
}