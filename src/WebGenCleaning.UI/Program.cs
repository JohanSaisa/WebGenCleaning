// See https://aka.ms/new-console-template for more information

/*
 * Data ifrån API
 */

using WebGenCleaning.Lib;

string[] techniques = {"   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   "};
string[] messagesToClass = { "Glöm inte att övning ger färdighet!", "Öppna boken på sida 257." };

WebContentHelper.FormatSentences(new string[]
{
  "  Hej på dig. Jag är Ett Test!", "Hej igen.    Detta är en Inkomplett mening"
});
/*
 * Skriva ut data
 */
printPage();

void printStart()
{
  string start = "<!DOCTYPE html>\n<html>\n<body>\n<main>\n";
  Console.WriteLine(start);
}
void printWelcome(string className, string[] message)
{
  string welcome = $"<h1> Välkomna {className}! </h1>";

  string welcomeMessage = "";

  foreach (string msg in message)
  {
    welcomeMessage += $"\n<p><b> Meddelande: </b> {msg} </p>";
  }
    
  Console.WriteLine(welcome + welcomeMessage);
}
void printKurser()
{
  string kurser = courseGenerator(techniques);
  Console.WriteLine(kurser);
}
void printEnd()
{
  string end = "</main>\n</body>\n</html>";
  Console.WriteLine(end);
}


void printPage()
{
  printStart();
  printWelcome("Klass A", messagesToClass);
  printKurser();
  printEnd(); 
}


string courseGenerator(string[] techniques)
{
  string kurser = "";

  foreach (string technique in techniques)
  {
    string tmp = technique.Trim();
    kurser += "<p>" + tmp[0].ToString().ToUpper() + tmp.Substring(1).ToLower() + "</p>\n";
  }

  return kurser;
}