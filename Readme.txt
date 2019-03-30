Note: trusted_Connection=true is used when using integrated authentication. for example if you have a windows authentication user set on the db, this will use
that user.

If you want to use a username and password AKA SQL Auth, switch to this, notice the Trusted_Connection=True is no longer needed.
dotnet ef dbcontext scaffold "Server=.\;Database=WebApp;UID=WebUser;PWD=P@ssw0rd" Microsoft.EntityFrameworkCore.SqlServer -o Model -c "WebAppContext" -d -f

how to generate dbcontext scaffold with data annotations
dotnet ef dbcontext scaffold "Server=.\;Database=WebApp;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Model -c "WebAppContext" -d

how to update model
dotnet ef dbcontext scaffold "Server=.\;Database=WebApp;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Model -c "WebAppContext" -d -f


