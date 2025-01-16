var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:5046");
app.Urls.Add("http://*:5046");

List<Teacher> teachers = [
    new () {Name = "Micke"},
    new () {Name = "Alexander"},
    new () {Name = "Martin"}
];

app.MapGet("/", GetMe);
app.MapGet("/orb", GetAlso);
app.MapGet("/micke", GetMicke);
app.MapGet("/message", SayHello);
app.MapGet("/teachers", GetTeachers);
app.MapGet("/teacher/{n}", GetTeacher);


app.Run();



List<Teacher> GetTeachers()
{
    return teachers;
}

IResult GetTeacher(int n)
{
    if (n >= 0 && n < teachers.Count)
    {
        return Results.Ok(teachers[n]);
    }
    else
    {
        return Results.NotFound();
    }
}


static void SayHello(string message)
{
    System.Console.WriteLine(message);
}

static Teacher GetMicke()
{
    Teacher micke = new() {Name = "Micke"};
    return micke;
}

static string GetAlso()
{
    return "Hi, orb!";
}

static string GetMe()
{
    return "I know where you live";
}