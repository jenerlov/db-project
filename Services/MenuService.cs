// namespace db-project.Services
// {
    internal class MenuService
    {
        public async Task Menu()
        {
            {
                Console.Clear();
                Console.WriteLine("Huvudmeny");
                Console.WriteLine("Välj ett alternativ");
                Console.WriteLine("1.Skapa ärende");
                Console.WriteLine("2. Visa alla ärenden");
                Console.WriteLine("3. Skriv kommentar på ärende");
                Console.WriteLine("4. Ändra status på ärende");
                Console.WriteLine("5. Visa specifikt ärende");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateCase();
                        break;
                    case "2":
                        ShowAllCases();
                        break;
                    case "3":
                        CommentCase();
                        break;
                    case "4":
                        ChangeStatus();
                        break;
                    case "5":
                        ShowSpecific();
                        break;
                    default:
                        Console.WriteLine("Felaktig inmatning, försök igen");
                        break;
                    
                }

            }
            Console.WriteLine("Tack för ditt ärende!");
        }

        public async Task CreateCase()
        {
            // var form = new CaseRegistrationForm();
            
            Console.Clear();
            Console.WriteLine("Skapa nytt ärende");
            Console.WriteLine("");
        }
        public async Task ShowAllCases()
        {
            Console.Clear();
            Console.WriteLine("Visa alla ärenden");
            Console.WriteLine();
            // foreach (var registratedCase in await _caseService.GetAllAsync())
            // Console.WriteLine($"Ärende med ärendenummer: {result.caseId}");

        }
        public async Task CommentCase()
        {

        }
        public async Task ChangeStatus()
        {

        }
        public async Task ShowSpecific()
        {

        }
    }

// }