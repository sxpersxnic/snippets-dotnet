using Microsoft.AspNetCore.Mvc;

namespace snippets_dotnet.Controllers;

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
  public string Welcome() 
  {
    return "Welcome to the Snippets api!";
  }
}