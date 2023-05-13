using System.Diagnostics;
using System.Text;



string[] csvFile = File.ReadAllLines("../../../Data/Data.csv");

var headerLine = csvFile[0];

var columns = headerLine.Split(';').Select((v, i) => new { ColumnName = v, ColumnIndex = i });

StringBuilder table = new();

table.AppendLine("<table border=\"1\">");

table.AppendLine("<thead>");

table.AppendLine("</thead>");

foreach (var column in columns)
{
    table.Append("<th>" + column.ColumnName + "</th>");
}

table.AppendLine("<tbody>");

var dataLines = csvFile.Skip(1);

dataLines.ToList().ForEach(line =>
{
    var data = line.Split(";");

    table.AppendLine("<tr>");

    foreach (var column in columns)
    {
        table.AppendLine("<td>" + data[column.ColumnIndex].Replace("\"", "") + "</td>");
    }

    table.AppendLine("</tr>");
});
table.AppendLine("</tbody>");

table.AppendLine("</table>");

Console.WriteLine(table.ToString());

// writing table to html file 
File.WriteAllText("../../../Html/user.html", table.ToString());
Console.WriteLine("Html File Created.");
Console.ReadLine();



