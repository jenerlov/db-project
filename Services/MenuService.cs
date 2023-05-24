using dbproject.Models.Forms;
using dbproject.Models.Entities;
using dbproject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

namespace dbproject.Services
{
    internal class MenuService
    {
        private readonly CaseService _caseService = new CaseService();
        private readonly CommentService _commentServie = new CommentService();

        public async Task Menu()
        {
            Console.Clear();
            Console.WriteLine("Huvudmeny");
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("1. Skapa ärende");
            Console.WriteLine("2. Visa alla ärenden");
            Console.WriteLine("3. Skriv kommentar på ärende");
            Console.WriteLine("4. Ändra status på ärende");
            Console.WriteLine("5. Visa specifikt ärende");

            var input = Console.ReadLine();

            switch(input)
            {
                case "1":
                await CreateCase();
                break;
                case "2":
                await ShowAllCases();
                break;
                case "3":
                await CommentCase();
                break;
                case "4":
                await ChangeStatus();
                break;
                case "5":
                await ShowSpecific();
                break;
                default:
                Console.WriteLine("Felaktig inmatning, försök igen");
                break;                
            }

            Console.WriteLine("Tack för ditt ärende");

        }
        private async Task CreateCase()
        {
            var form = new CaseRegForm();

            Console.Clear();
            Console.WriteLine("Skapa nytt ärende");
            Console.WriteLine();

            var result = await _caseService.CreateAsync(form);
            Console.WriteLine($"Ärende med nummer {result.CaseId} har skapats");

        }

        private async Task ShowAllCases()
        {
            Console.Clear();
            Console.WriteLine("Visa alla ärenden");
            Console.WriteLine();

            foreach (var registratedCase in await _caseService.GetAllAsync())
            {
                Console.WriteLine($"{registratedCase.CaseId}, {registratedCase.Description}");
            }
        }
        private async Task CommentCase()
        {
            await ShowAllCases();

            Console.WriteLine("Ange ärendenummer");
            int.TryParse(Console.ReadLine(), out int caseId);

            if(caseId > 0)
            {
                var form = new CommentForm();

                Console.WriteLine("Skriv kommentar");
                Console.WriteLine();

                form.Comment = Console.ReadLine() ?? "";

                if (form.Comment != "" && caseId != null)
                {
                    var result = await _commentService.CreateAsync(caseId.ToString(), form);
                    Console.WriteLine("Kommentaren har lagts till");

                }
                    else 
                    {
                    Console.WriteLine("Kan inte lägga till kommentaren");

                    }
            }
        }
        public async Task ChangeStatus()
        {
            await ShowAllCases();

            Console.WriteLine("Ange ärendenummer");
            var caseId = Console.ReadLine();

            if (!string.IsNullOrEmpty(caseId))
            {
                var registratedCase = await _caseService.GetAsync(caseId);
                if (registratedCase != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Ändra status för ärende med nummer {registratedCase.CaseId}:");
                    Console.WriteLine("1. Under behandling");
                    Console.WriteLine("2. Pågående");
                    Console.WriteLine("3. Avslutat");
                    Console.Write("Ange ett av följande alternativ (1-3):");

                    var option = Console.ReadLine();
                    int statusTypeId;

                    switch (option)
                    {
                        case "1":
                            statusTypeId = 1;
                            break;
                        case "2":
                            statusTypeId = 3;
                            break;
                        case "3":
                            statusTypeId = 7;
                            break;
                        case "4":
                            statusTypeId = 5;
                            break;
                        default:
                            Console.WriteLine("Felaktikt alternativ");
                            return;
                            
                    }
                    await _caseService.ChangeStatusAsync(caseId, statusTypeId);
                    Console.WriteLine($"Statusen för ärende med nummer {registratedCase.CaseId} har ändrats till {registratedCase.Status.StatusName}");

                }
                else 
                {
                    Console.WriteLine($"Inget ärende med nummer {caseId }hittades");
                }
                // else 
                // {
                //     Console.WriteLine("Inget ärendenummer specifierades");
                // }
            };
        }
        public async Task ShowSpecific()
        {
            await ShowAllCases();

            Console.WriteLine("Ange 'ärendenummer:");
            var caseId = Console.ReadLine();

            if (!string.IsNullOrEmpty(caseId))
            {
                var registratedCase = await _caseService.GetAsync(caseId);
                if (registratedCase != null)
                {
                    Console.Clear();
                    Console.WriteLine("Ärendeinformation");
                    Console.WriteLine();

                }
            }
        }
    }
}

