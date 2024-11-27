using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace snippets.Controllers;

public class HomeController: Controller 
{

  //
  // GET: /api/v1
  public string Index() 
  {
    return "This is the snippets api v1!";
  }

  //
  // GET: /api/v1/Welcome
  public string Welcome(string name = "World", ulong id = 1) 
  {
    return HtmlEncoder.Default.Encode($"Welcome {name}, ID: {id}");
  }
}