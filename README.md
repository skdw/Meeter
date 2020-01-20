# Meeter
## App documentation
![Meeter](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/wwwroot/meeter.svg)

An app helping to choose the best place for you and your friends to meet. 

### Introduction

*Meeter* is a recommending system suggesting a group of friends which place to choose for their meeting. 

The proposed local will be chosen based on the preferences of each friend, according to types of their favourite food, drinks and the general type of desired place, like restaurant, bar or café. 

Another factor will be the distance of each user to the place, rating and the degree of congestion. The data will be gathered from Google API as well as from the users themselves. 

![Routes](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/routes-screen.png)
Routes of each friend (A) to the selected place (B).

### Use-cases

List of roles:
* User - everyone who is logged-in 
* Group member - user who has joined a specific group
* Group member (virtual) - a person who participates in the meeting but does not have their Meeter account
* Group leader - user who has created a specified group
* Administrator - user with special permissions, sees all of the created groups and has the access to the users' data

![Use-case](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/use-case.svg)

### Database
![Use-case](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/diagram.svg)

## Prerequisites

* Linux / Windows PC
  * For Mac OS, app works only with in-memory database. To build, replace in *Startup.cs*:

        services.AddDbContext<NormalDataContext>(options => options.UseSqlServer(connection));
        
    with:

        services.AddDbContext<NormalDataContext>(opts => opts.UseInMemoryDatabase("MeeterDatabase"));
  

* Visual Studio 2017/2019 with .NET Core 2.1
* SQL Server

## User guide
Before starting the program, you can create SQL database; otherwise you have to create InMemoryDatabase.
Using SSMS (SQL Server Management Studio), connect to local database:
            
    (LocalDb)\MSSQLLocalDB

![Connect to Server](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/connect-to-server.png)

Write command in Package Menager Console:

    Update-database

Refresh *(LocalDb)\MSSQLLocalDB* by right click on it and choose *Refresh*.

Check if in folder Databases exists: *MeeterAplicationDB* with tables:
![Tables](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/tables.png)

If operation succeeded, you can start the application. 

### Checking Authorization
If you would like to check the authorization mode, go to *Startup.cs* and set e-mail to yours in *CreateUserRoles* method.

    private async Task CreateUserRoles(IServiceProvider serviceProvider)
    {
        ...
        User user = await UserManager.FindByEmailAsync("[YOUR E-MAIL]");
        ...
    }

Then start the application login using this e-mail, stop debugging. Check in database if in table *AspNetUserRoles* is your id (you can see your id in *AspNetUsers* table) and Role Admin id (you can check it in *AspNetRoles* table). At the end start the application one more time and login using admin email.
Check Admin sites:
http://localhost:5000/api/Group/Index
http://localhost:5000/api/Event/Index

### Usage demonstration

![Splashscreen](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/splashscreen.png)

Application starts from login/registration site. If the application is visited for the first time, user registration is obligatory to see next views. The browser can remember user data in a cookie and log him in automatically. 
![Register](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/register.png)

To update the user location in database, we can go to *SetLocation* endpoint and choose our location on the map. After that, the address is determined by Google Maps API. It is also possible to obtain the location from the client browser, it proceeds after clicking *Get current location*. After the correct location is set, we can save it to update the database record. 
![Set Location](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/setlocation.png)

Users have the ability to create groups. Once a new group is created, its creator becomes the first user. 
![Create group](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/groupcreate.png)

![Group info](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/groupinfo.png)

After creating a group, other users can be added. 
![New member](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/newmember.png)

![Event info](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/eventinfo.png)

Users can define their preferences for the meeting points types. The type can be selected from the list provided by 
<a href=https://developers.google.com/places/supported_types#table1>Google Places</a>. 
![User preference](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/userpreference.png)

Once the users are added to the database and they participate in events, they can list down all of their groups and events. 
![Groups](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/groups.png)

![Events](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/events.png)

![Created groups](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/createdgroups2.png)

Furthermore, Places API provides the information about the points related to the users' preferences and specifically the closest to the selected point. 
![Places API](http://pages.mini.pw.edu.pl/~gorzynskik/HTMLPostGIS/Meeter/placesapi.png)

## Technologies used

* Client-side
  * HTML
  * CSS
  * JavaScript
  * AJAX
  * Google Maps API

* Server-side
  * ASP .NET Core 2.1
  * Microsoft SQL Server

## Conclusions

* Due to the .NET's just-in-time compilation, some errors do not prevent launching the application. It causes the app to start faster, but also to be harder to debug. 
* Passing data between the backend and frontend by sending HTTP requests manually and fetching them is tedious. When app becomes larger, rewriting code to Razor and using Views makes it much cleaner and simpler. 
* Models work just like database tables, that's why they should be coded not like the traditional classes nested one in another, but like the related tables, binded by marking the members as virtual. Unfortunately, we are still facing problems trying to get all the data via the relations and avoiding searching it manually by the id. 
* Authentication and authorization are a real tough nut to crack when doing it for the first time. Range of different methods makes it hard to look for advice in online tutorials. 
* The salary of full-stack developer is definitely deserved! 🤑

## Developer guide

## Services

    services.AddDbContext<NormalDataContext>(options => options.UseSqlServer(connection));

### Identity services

    services.AddIdentity<User, IdentityRole>(config =>
      {
          config.Password.RequireDigit = false;
          config.Password.RequiredLength = 4;
          config.Password.RequireUppercase = false;
          config.Password.RequireNonAlphanumeric = false;
      })
          .AddEntityFrameworkStores<NormalDataContext>()
          .AddDefaultTokenProviders()
          .AddRoles<IdentityRole>();

### Database

Creating the database with users inheriting from IdentityUser. 


    public class NormalDataContext : IdentityDbContext<User, IdentityRole, string>
    

Loading static data from json file automatically on database update.

    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var myJsonString = File.ReadAllText("preferences.json");
            List<Type> ptypes = JsonConvert.DeserializeObject<List<Type>>(myJsonString);
            builder.Entity<Type>().HasData(ptypes.ToArray());
            // Customize the ASP.NET Core Identity model and override the defaults if needed. 

            //builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
        }

Hiding the secret information in *appsettings.Secret.json* file (ignored by git). 

    {
      "Logging": {
        "LogLevel": {
          "Default": "Debug",
          "System": "Information",
          "Microsoft": "Information"
        }
      }, 
      "AdminEmail": "YOUR_EMAIL",
      "GoogleKey": "YOUR_GOOGLE_KEY"
    }


Adding to database 

    await normalDataContext.Groups.AddAsync(model);
                await normalDataContext.GroupMembers.AddAsync(
                    new GroupMember
                {
                    GroupId = model.Id,
                    User = model.Creator
                    //Userid = model.Creator.Id
                });
                await normalDataContext.SaveChangesAsync();


Removing from database  

    normalDataContext.Groups.Remove(normalDataContext.Groups.Find(id));
                await normalDataContext.SaveChangesAsync();

### Authorization

Thanks to the mechanism of IdentityRoles, it is possible to prevent normal users from seeing sites which are available only for admin. If needed, another roles can be defined as well. 

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> IndexAdmin()
    {
        ...
    }

### Razor-Controller communication

Way of communication between .NET server and Razor form.

    @using (Html.BeginForm("Create"))
            {
                @Html.AntiForgeryToken()
                ...

                <div class="form-group">
                  <button type="submit" class="btn btn-primary">Create<button>
                </div>
            }
or:

    @Html.ActionLink(eve.Group.Name, "GetGroupInfo", "Group", new { id = eve.Group.Id }, new { @class = "btn btn-dark" })</td>

### Controller communication

    [Route("api/[controller]/[action]")]
    public class GroupController : Controller
    {
        private readonly NormalDataContext normalDataContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public GroupController(
            UserManager<User> usm,
            SignInManager<User> sim,
            NormalDataContext normalD)
        {
            userManager = usm;
            signInManager = sim;

            normalDataContext = normalD;
        }



## Authors and acknowledgment
* Anna Buchman
* Kamil Górzyński
---
* Graphics <a href="http://www.freepik.com">designed by pikisuperstar / Freepik</a>
* Font designed by <a href="https://fonts.adobe.com/designers/hayato-yamasaki">Hayato Yamasaki</a>, <a href="https://fonts.adobe.com/designers/kazunori-shiina">Kazunori Shiina</a>, and <a href="https://fonts.adobe.com/designers/robyn-makinson">Robyn Makinson</a>. From <a href="https://fonts.adobe.com/foundries/fontself">Fontself</a>.
