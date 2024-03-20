var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

List<Person> persons = new List<Person>();

app.Run(async (context) =>
{
	var requset = context.Request;
	var responce = context.Response;
	if (requset.Path == "/")
	{
		responce.ContentType = "text/html";
		await responce.SendFileAsync("wwwroot/html/index.html");
	}
	else if(requset.Path == "/signup")
	{
		responce.ContentType = "text/html";
		await responce.SendFileAsync("wwwroot/html/signup.html");
	}
	else if(requset.Path == "/end")
	{
		persons.Add(new Person()
		{
			Cell = requset.Query["cell"].ToString() ?? " ",
			Email = requset.Query["email"].ToString() ?? " ",
			Name = requset.Query["name"].ToString() ?? " "
		});
		responce.ContentType = "text/html";
		//await responce.WriteAsJsonAsync(persons.Last());
		await responce.SendFileAsync("wwwroot/html/end.html");
	}
});

app.Run();

class Person
{
	public Person() { }
	public String? Name { get; set; }
	public String? Cell { get; set; }
	public String?  Email { get; set; }
}