<p align="center">
  <a href="" rel="noopener">
 <img width=100px height=100px src="src/NotesApp.WebUI.Server/wwwroot/favicon.png" alt="Project logo"></a>
</p>

<h3 align="center">Note Editor with Blazor</h3>

---

<p align="center"> The note-taking service was developed for the purposes of practice at Blazor
    <br> 
</p>

## 🏁 Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

You need to install PostgreSQL Server locally or use next Docker command to run container which will be available on **port 5432** _(if you have postgres locally installed, it is better to reassign container to another free port)_.

```
docker run --name NoteAppDb -p 5432:5432 -e POSTGRES_PASSWORD=yoursecretpassword -d postgres
```

### Installing

Go to the WebUI.Server project folder and run user-secrets manager to set your connection string.

```
cd .\src\NotesApp.WebUI.Server\
```

```
dotnet user-secrets init
```

```
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost; Port=5432; Database=NotesApp; Username=postgres; Password=yoursecretpassword"
```

And to run project you need go with next command in same folder _(remove "watch" while not developing)._

```
dotnet watch run .\NotesApp.WebUI.Server.csproj
```

<!---
## 🔧 Running the tests

Explain how to run the automated tests for this system.

### Break down into end to end tests

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```
-->

## ⛏️ Built Using <a name = "built_using"></a>

- [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) - Full-stack Web Framework
- [PostgreSQL](https://www.postgresql.org/) - Database
