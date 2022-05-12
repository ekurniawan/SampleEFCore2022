// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using SampleEF.Data;
using SampleEF.Domain;

SamuraiContext _context = new SamuraiContext();
_context.Database.EnsureCreated();

SwordContext _swordContext = new SwordContext();
_swordContext.Database.EnsureCreated();

//GetSamurais("Pertama kali sebelum tambah data");
//AddSamurai("Samurai 1", "Samurai 2", "Samurai 3", "Samurai 4");
//AddVariousTypes();
//GetSamurais("Setelah ditambahkan");
//GetBattles();
//QueryAggregates();
//RetrieveAndUpdate();
//RetrieveAndUpdateSamurai();
//RetrieveAndDeleteSamurai();
//InsertNewSamuraiWithQuote();
//AddQuotesToExistingSamurai();
//EagerLoadSamuraiWithQuotes();
//ProjectionSample();

//GetSamurais("result:");

//InsertSword();
GetSamuraiWithSword();

Console.Write("Press any key ...");
Console.ReadLine();


void GetSamurais(string text)
{
    var samurais = _context.Samurais.AsNoTracking().ToList();
    Console.WriteLine($"{text}: Jumlah Samurai - {samurais.Count} orang");
    foreach (var samurai in samurais)
    {
        Console.WriteLine($" {samurai.Id} - {samurai.Name}");
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
                      new Battle { Name = "Battle of Anegawa" },
                      new Battle { Name = "Battle of Nagashino" });
    _context.SaveChanges();
}
void GetBattles()
{
    var battles = _context.Battles.AsNoTracking().ToList();
    foreach (var battle in battles)
    {
        Console.WriteLine($"{battle.BattleId} - {battle.Name}");
    }
}
void QueryAggregates()
{
    //var name = "Samurai 1";
    //var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);
    var samurais = _context.Samurais.Where(s => s.Name.Contains("Tan")).AsNoTracking().ToList();
    foreach (var samurai in samurais)
    {
        Console.WriteLine(samurai.Name);
    }
}
void RetrieveAndUpdate()
{
    var samurai = _context.Samurais.FirstOrDefault(s => s.Id == 2);
    samurai.Name = "Kyojiro Rengoku";
    _context.SaveChanges();
}
void RetrieveAndUpdateSamurai()
{
    var samurai = _context.Samurais.OrderBy(s => s.Id).LastOrDefault();
    samurai.Name += " San";
    _context.Samurais.Add(new Samurai { Name = "Gyomei Hajima" });
    _context.SaveChanges();
}
void RetrieveAndDeleteSamurai()
{
    //var samurai = _context.Samurais.Find(1);
    //_context.Samurais.Remove(samurai);
    var samurais = _context.Samurais.Where(s => s.Name.StartsWith("Samurai"));
    _context.Samurais.RemoveRange(samurais);
    _context.SaveChanges();
}
void InsertNewSamuraiWithQuote()
{
    var samurai = new Samurai
    {
        Name = "Miyamoto Musashi",
        Quotes = new List<Quote>
        {
            new Quote{Text="Think lightly of yourself and deeply word"},
            new Quote{Text="Do nothing that is no use"}
        }
    };
    _context.Samurais.Add(samurai);
    _context.SaveChanges();
}
void AddQuotesToExistingSamurai()
{
    var samurai = _context.Samurais.Find(8);
    samurai.Quotes.Add(new Quote { Text = "Do not fear death" });
    _context.SaveChanges();
}
void EagerLoadSamuraiWithQuotes()
{
    //var samuraiwithquotes = _context.Samurais.Include(s => s.Quotes).ToList();
    var filterEntity = _context.Samurais.Where(s => s.Name.Contains("Miyamoto"))
        .Include(s => s.Quotes.Where(q => q.Text.Contains("fear"))).AsNoTracking().ToList();

    foreach (var samurai in filterEntity)
    {
        Console.WriteLine($" {samurai.Id} - {samurai.Name}");
        foreach (var quote in samurai.Quotes)
        {
            Console.WriteLine($"-- Quote: {quote.Text}");
        }
    }
}
void ProjectionSample()
{
    //var results = _context.Samurais.Select(s=> new { s.Id, s.Name }).ToList(); 
    //var idnameresult = _context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList(); 
    var resultwithcount = _context.Samurais.Include(s => s.Quotes).Select(s => new
    {
        s.Id,
        s.Name,
        NumOfQuotes = s.Quotes.Count()
    }).ToList();
    foreach (var samurai in resultwithcount)
    {
        Console.WriteLine($" {samurai.Id} - {samurai.Name} - {samurai.NumOfQuotes}");
    }
}

//menambahkan sword
void InsertSword()
{
    _swordContext.AddRange(
        new Sword { Name = "Sword 1", Weight = 20, SamuraiId = 2 },
        new Sword { Name = "Sword 2", Weight = 10, SamuraiId = 2 },
        new Sword { Name = "Sword 3", Weight = 10, SamuraiId = 8 },
        new Sword { Name = "Sword 4", Weight = 10, SamuraiId = 8 });
    _swordContext.SaveChanges();
}
void GetSamuraiWithSword()
{
    List<Samurai> samurais;
    using (var context = new SamuraiContext())
    {
        samurais = context.Samurais.AsNoTracking().ToList();
    }

    List<Sword> swords;
    using (var sContext = new SwordContext())
    {
        swords = sContext.Swords.AsNoTracking().ToList();
    }

    /*var results = from sa in samurais
                  join sw in swords on sa.Id equals sw.SamuraiId
                  select new SamuraiWithSword
                  {
                      SamuraiId = sa.Id,
                      SamuraiName = sa.Name,
                      SwordName = sw.Name,
                      SwordId = sw.Id,
                      Weight = sw.Weight
                  };*/

    var results = samurais.Join(swords, sa => sa.Id, sw => sw.SamuraiId, (sa, sw) => new SamuraiWithSword
    {
        SamuraiId = sa.Id,
        SamuraiName = sa.Name,
        SwordName = sw.Name,
        SwordId = sw.Id,
        Weight = sw.Weight
    });

    foreach (var result in results)
    {
        Console.WriteLine($"{result.SwordName} - {result.SamuraiName} - {result.Weight}");
    }
}

record SamuraiWithSword
{
    public int SamuraiId { get; set; }
    public string SamuraiName { get; set; }
    public string SwordName { get; set; }
    public int SwordId { get; set; }
    public double Weight { get; set; }
}

struct IdAndName
{
    public IdAndName(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id;
    public string Name;
}



