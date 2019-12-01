using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class DBInitializer
    {
        public static void Initialize(PollContext context)
        {
            context.Database.EnsureCreated();

            if (context.Polls.Any())
            {
                return;   // DB has been seeded
            }

            //database vullen met testdata
            Poll poll1 = new Poll { Vraag = "Wat is je favoriete kleur?" };
            Poll poll2 = new Poll { Vraag = "Heb je een rijbewijs?" };
            Poll poll3 = new Poll { Vraag = "Hou je van pizza?" };
            Antwoord antwoord1 = new Antwoord { Respons = "blauw", Poll = poll1 };
            Antwoord antwoord2 = new Antwoord { Respons = "geel", Poll = poll1 };
            Antwoord antwoord3 = new Antwoord { Respons = "rood", Poll = poll1 };
            Antwoord antwoord4 = new Antwoord { Respons = "groen", Poll = poll1 };
            Antwoord antwoord5 = new Antwoord { Respons = "Ja", Poll = poll2 };
            Antwoord antwoord6 = new Antwoord { Respons = "Nee", Poll = poll2 };
            Antwoord antwoord7 = new Antwoord { Respons = "Ja", Poll = poll3 };
            Antwoord antwoord8 = new Antwoord { Respons = "Nee", Poll = poll3 };
            Gebruiker gebruiker1 = new Gebruiker { Email = "tijl@gmail.com", Gebruikersnaam = "tijl123", Wachtwoord = "tijl123" };
            Gebruiker gebruiker2 = new Gebruiker { Email = "jan@gmail.com", Gebruikersnaam = "jan123", Wachtwoord = "jan123" };
            Gebruiker gebruiker3 = new Gebruiker { Email = "bert@gmail.com", Gebruikersnaam = "bert123", Wachtwoord = "bert123" };
            Gebruiker gebruiker4 = new Gebruiker { Email = "gert@gmail.com", Gebruikersnaam = "gert123", Wachtwoord = "gert123" };
            Stem stem1 = new Stem { Gebruiker = gebruiker1, Antwoord = antwoord1 };
            Stem stem2 = new Stem { Gebruiker = gebruiker2, Antwoord = antwoord2 };
            Stem stem3 = new Stem { Gebruiker = gebruiker3, Antwoord = antwoord5 };
            PollGebruiker pollGebruiker1 = new PollGebruiker { Geaccepteerd = true, Gebruiker = gebruiker1, Poll = poll1 };
            PollGebruiker pollGebruiker2 = new PollGebruiker { Geaccepteerd = false, Gebruiker = gebruiker1, Poll = poll2 };
            PollGebruiker pollGebruiker3 = new PollGebruiker { Geaccepteerd = true, Gebruiker = gebruiker2, Poll = poll1 };
            PollGebruiker pollGebruiker4 = new PollGebruiker { Geaccepteerd = true, Gebruiker = gebruiker3, Poll = poll2 };
            PollGebruiker pollGebruiker5 = new PollGebruiker { Geaccepteerd = false, Gebruiker = gebruiker1, Poll = poll3 };
            Vriend vriend1 = new Vriend { Ontvanger = gebruiker1, Verzender = gebruiker2, Geaccepteerd = false };
            Vriend vriend2 = new Vriend { Ontvanger = gebruiker1, Verzender = gebruiker3, Geaccepteerd = true };
            Vriend vriend3 = new Vriend { Ontvanger = gebruiker1, Verzender = gebruiker4, Geaccepteerd = false };
            context.Polls.AddRange(
                poll1, poll2, poll3);
            context.Antwoorden.AddRange(
                antwoord1, antwoord2, antwoord3, antwoord4, antwoord5, antwoord6, antwoord7, antwoord8);
            context.Gebruikers.AddRange(
                gebruiker1, gebruiker2, gebruiker3, gebruiker4);
            context.Stemmen.AddRange(
                stem1, stem2, stem3);
            context.PollGebruikers.AddRange(
                pollGebruiker1, pollGebruiker2, pollGebruiker3, pollGebruiker4, pollGebruiker5);
            context.Vrienden.AddRange(
                vriend1, vriend2, vriend3);
            context.SaveChanges();
        }
    }
}
