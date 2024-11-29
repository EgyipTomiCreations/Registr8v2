namespace Registr8
{
    public static class Globals
    {
        public static HttpClient client { get; set; } = new HttpClient();
        private static Token _token;
        public static Token token
        {
            get => _token; set
            {
                _token = value;
                if (_token != null)
                {
                    switch (_token.FelhKategoria)
                    {
                        case Auth.FelhKategoria.Szervezo:
                            HomeUrl = "/szervezoi-felulet";
                            break;
                        case Auth.FelhKategoria.Iskola:
                            HomeUrl = "/iskolai-felulet";
                            break;
                        case Auth.FelhKategoria.Versenyzo:
                            HomeUrl = "/versenyzoi-felulet";
                            break;
                        default:
                            HomeUrl = "/";
                            break;
                    }
                }
                else
                {
                    HomeUrl = "/";
                }
            }
        }
        public static string HomeUrl { get; set; } = "/";
        public static void Init()
        {
            client.DefaultRequestHeaders.Accept.Add(new("application/json"));
            client.BaseAddress = new Uri("https://duszapi.runasp.net");
        }
    }
}
