// See https://aka.ms/new-console-template for more information

using SampleEF.Data;
using SampleEF.Domain;

SamuraiContext _context = new SamuraiContext();
_context.Database.EnsureCreated();

GetSamurais("Pertama kali sebelum tambah data");
AddSamurai("Kamado Tanjiro");
GetSamurais("Setelah ditambahkan");


Console.Write("Press any key ...");
Console.ReadLine();


void GetSamurais(string text)
{
    var samurais = _context.Samurais.ToList();
    Console.WriteLine($"{text}: Jumlah Samurai - {samurais.Count} orang");
    foreach(var samurai in samurais)
    {
        Console.WriteLine(samurai.Name);
    }
}

void AddSamurai(string name)
{
    var samurai = new Samurai { Name = name };
    _context.Samurais.Add(samurai);
    _context.SaveChanges();
}
