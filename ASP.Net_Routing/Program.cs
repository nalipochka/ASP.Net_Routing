using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/{controller}/{action}/{id?}", OrderHandler);

app.Map("/Home/{action:maxlength(6)}/{id?}",(string action) =>
{
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("MAX LENGTH 6!");
    sb.AppendLine($"Action: {action}");
    return sb.ToString();
});

app.Map("/usersettings/{id:int:range(1,999)?}", (HttpContext context, int? id) =>
{
    context.Response.Redirect($"/user/settings/{id}");
});

app.Map("/Admin/{action:regex(^\\w+setup$)}", (string action) => $"Action: {action}");

app.Map("Shop/Archive/{date:datetime}", (HttpContext context, DateTime date) =>
{
    StringBuilder sb = new StringBuilder();
    sb.AppendLine($"{date.ToShortDateString()} SALE!!!");
    sb.AppendLine("iPhone 13 Pro MAX");
    sb.AppendLine("iPad 4 Pro");
    sb.AppendLine("Macbook 7 Lite");
    return sb.ToString();
});

app.Run();

string OrderHandler(string controller, string action, int? id)
{
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("Infinity length!");
    sb.AppendLine($"Controller: {controller}");
    sb.AppendLine($"Action: {action}");
    sb.AppendLine($"Id: {id}");
    return sb.ToString();
}