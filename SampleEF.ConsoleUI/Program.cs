// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using SampleEF.Data;
using SampleEF.Domain;

SamuraiContext _context = new SamuraiContext();
_context.Database.EnsureCreated();

//GetSamurais("Pertama kali sebelum tambah data");
//AddSamurai("Samurai 1", "Samurai 2", "Samurai 3", "Samurai 4");
//AddVariousTypes();
//GetSamurais("Setelah ditambahkan");
GetBattles();

Console.Write("Press any key ...");
Console.ReadLine();


void GetSamurais(string text)
{
    var samurais = _context.Samurais.AsNoTracking().ToList();
    Console.WriteLine($"{text}: Jumlah Samurai - {samurais.Count} orang");
    foreach (var samurai in samurais)
    {
        Console.WriteLine(samurai.Name);
    }
}
void AddSamurai(params string[] names)
{
    foreach (string name in names)
    {
        _context.Samurais.Add(new Samurai { Name = name });
    }
    _context.SaveChanges();
}
void AddVariousTypes()
{
    _context.AddRange(new Samurai { Name = "Kamado Tanjiro" }, 
                      new Samurai { Name = "Sanemi" },
                      new Battle { Name="Battle of Anegawa"},
                      new Battle { Name="Battle of Nagashino" });
    _context.SaveChanges();
}
void GetBattles()
{
    var battles = _context.Battles.AsNoTracking().ToList();
    foreach(var battle in battles)
    {
        Console.WriteLine($"{battle.BattleId} - {battle.Name}");
    }
}
