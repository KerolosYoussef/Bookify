using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Admin;

[Authorize(Roles = "Admin")]
public class BaseAdminController : Controller
{ }