##### Client-Side Libraries

     File: libman.json

1. Create file in UI **libman.json**
2. Paste below content to **libman.json**

```json
{
  "version": "1.0",
  "defaultProvider": "cdnjs",
  "libraries": [
    {
      "provider": "unpkg",
      "library": "bootstrap@4.2.1",
      "destination": "wwwroot/lib/bootstrap/",
      "files": [
        "dist/css/bootstrap.min.css",
        "dist/css/bootstrap.min.css.map"
      ]
    },
    {
      "provider": "jsdelivr",
      "library": "font-awesome@4.7.0",
      "destination": "wwwroot/lib/font-awesome/",
      "files": [
        "css/font-awesome.css",
        "css/font-awesome.css.map",
        "css/font-awesome.min.css",
        "fonts/fontawesome-webfont.eot",
        "fonts/fontawesome-webfont.svg",
        "fonts/fontawesome-webfont.ttf",
        "fonts/fontawesome-webfont.woff",
        "fonts/fontawesome-webfont.woff2",
        "fonts/FontAwesome.otf"
      ]
    },
    {
      "library": "jquery@3.3.1",
      "destination": "wwwroot/lib/jquery/"
    },
    {
      "provider": "unpkg",
      "library": "jquery-validation-unobtrusive@3.2.11",
      "destination": "wwwroot/lib/jquery-validation-unobtrusive/",
      "files": [
        "dist/jquery.validate.unobtrusive.js",
        "dist/jquery.validate.unobtrusive.min.js"
      ]
    },
    {
      "provider": "unpkg",
      "library": "jquery-validation@1.19.1",
      "destination": "wwwroot/lib/jquery-validation/",
      "files": [
        "dist/jquery.validate.js",
        "dist/jquery.validate.min.js",
        "dist/additional-methods.js",
        "dist/additional-methods.min.js"
      ]
    },
    {
      "provider": "unpkg",
      "library": "jquery-ajax-unobtrusive@3.2.6",
      "destination": "wwwroot/lib/jquery-ajax-unobtrusive/",
      "files": [
        "dist/jquery.unobtrusive-ajax.js",
        "dist/jquery.unobtrusive-ajax.min.js"
      ]
    }
  ]
}
```
3. Right-Click **libman.json**
4. **Restore Client-Side Libraries**

       File: Startup.cs


5. Configure Application 
```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseAuthentication();
}
```
6. Setup services
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Error/403";

            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromHours(1);
        });

    services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", authBuilder =>
            {
                authBuilder.RequireRole("Admin");
            });
        });

    services.AddHttpContextAccessor();
}
```

##### Custom password hashers


```csharp
public interface IPasswordHasher
{
    byte[] GenerateSalt();

    byte[] HashPassword(byte[] salt, string password);

    bool IsPasswordVerified(byte[] salt, byte[] hashedPassword, string password);
}
```

```csharp
public class PasswordHasher : IPasswordHasher
{
    const int SaltSize = 128 / 8; // 128 bits

    public byte[] GenerateSalt()
    {
        RandomNumberGenerator rng = RandomNumberGenerator.Create();
        byte[] salt = new byte[SaltSize];

        rng.GetBytes(salt);

        return salt;
    }

    public byte[] HashPassword(byte[] salt, string password)
    {
        const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
        const int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
        const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits

        // Produce a version 2 text hash.
        byte[] subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

        var outputBytes = new byte[1 + SaltSize + Pbkdf2SubkeyLength];
        outputBytes[0] = 0x00; // format marker
        Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
        Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, Pbkdf2SubkeyLength);

        return outputBytes;
    }

    public bool IsPasswordVerified(byte[] salt, byte[] hashedPassword, string providedPassword)
    {
        var _hashedProvidedPass = HashPassword(salt, providedPassword);

        return _hashedProvidedPass.SequenceEqual(hashedPassword);
    }
}
```

Register dependency injection

```csharp
services.AddScoped<IPasswordHasher, PasswordHasher>();
```

##### Custom SignInManager

```csharp
public class SignInResult
{
    public bool IsLockedOut { get; protected set; }
    public bool IsNotAllowed { get; protected set; }
    public bool RequiresTwoFactor { get; protected set; }
    public bool Succeeded { get; protected set; }
    public string Message { get; set; }

    public static SignInResult Success
    {
        get
        {
            return new SignInResult
            {
                Succeeded = true
            };
        }
    }

    public static SignInResult Failed
    {
        get
        {
            return new SignInResult
            {
                Succeeded = false
            };
        }
    }
}
```

```csharp
public interface ISignInManager
{
    Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);

    Task<SignInResult> SignInAsync(string userName);

    Task SignOutAsync();
}
```

```csharp
public class SignInManager : ISignInManager
{
    private readonly IMediator mediator;
    private readonly IHttpContextAccessor contextAccessor;
    private readonly IPasswordHasher passwordHasher;

    public SignInManager(
        IMediator mediator,
        IHttpContextAccessor contextAccessor,
        IPasswordHasher passwordHasher)
    {
        this.mediator = mediator;
        this.contextAccessor = contextAccessor;
        this.passwordHasher = passwordHasher;
    }

    public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    {
        try
        {
            var _l = await dbContext.UserLogins
                .SingleOrDefaultAsync(a => a.Username == userName);

            if (_l == null)
            {
                throw new Exception("Invalid username or password");
            }

            if (!passwordHasher.IsPasswordVerified(_l.Salt, _l.Password, password))
            {
                throw new Exception("Invalid username or password");
            }

            return await SignInAsync(userName);
        }
        catch (Exception ex)
        {
            logger.Log(LogLevel.Trace, ex.Message);

            var _result = SignInResult.Failed;
            _result.Message = ex.Message;

            return _result;
        }
    }

    public async Task<SignInResult> SignInAsync(string userName)
    {
        try
        {
            var _user = await mediator.Send(new FindUserQuery { Username = userName });

            Guid _sessionUID = Guid.NewGuid();

            var _claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, _user.UID.ToString(), ClaimValueTypes.String),
                new Claim(ClaimTypes.Name, _user.Name, ClaimValueTypes.String),
                new Claim(ClaimTypes.Sid, _sessionUID.ToString(), ClaimValueTypes.String),
                new Claim(ClaimTypes.UserData, Json.Serializer().Serialize(_user), ClaimValueTypes.String)
            };

            foreach (var _role in _user.AccessRoles)
            {
                _claims.Add(new Claim(ClaimTypes.Role, _role.ToString(), ClaimValueTypes.String));
            }

            var _identity = new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var _principal = new ClaimsPrincipal(_identity);
                
            await contextAccessor.HttpContext.SignInAsync(_principal);

            return SignInResult.Success;
        }
        catch (Exception ex)
        {
            logger.Log(LogLevel.Trace, ex.Message);

            return SignInResult.Failed;
        }
    }

    public async Task SignOutImpersonateAsync()
    {
        contextAccessor.HttpContext.Session.Remove("Impersonate");
    }
}
```


Register dependency injection

```csharp
services.AddScoped<ISignInManager, SignInManager>();
```