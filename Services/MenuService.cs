using dbproject.Models.Entities;
using dbproject.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

namespace dbproject.Services;

    internal class MenuService
    {
        private readonly CaseService _caseService = new CaseService();
        // private readonly CommentService _commentService = new CommentService();
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
            var form = new CaseRegForm();
            
            Console.Clear();
            Console.WriteLine("Skapa nytt ärende");
            Console.WriteLine("");

            var result = await _caseService.CreateAsync(form);
            Console.WriteLine($"Ärendet med nummer {result.caseId} har skapats");
        }
        public async Task ShowAllCases()
        {
            Console.Clear();
            Console.WriteLine("Visa alla ärenden");
            Console.WriteLine();
            foreach (var registratedCase in await _caseService.GetAllAsync())
            Console.WriteLine($"{registratedCase.CaseId}, {registratedCase.Description}");

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

