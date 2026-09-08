using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using OrbisaAsp.Data.Models;
using System.Security.Cryptography;
using System.Text;

namespace OrbisaAsp.Data.Services;

public class AuthService
{
    private readonly IAmazonCognitoIdentityProvider _cognito;

    //private const string CLIENT_ID = "79h91mgmf8sfnlm79522c2m1v8";
    private string CLIENT_ID => Environment.GetEnvironmentVariable("COGNITO_CLIENT_ID")
        ?? throw new Exception("COGNITO_CLIENT_ID no está configurado.");

    private string COGNITO_SECRET => Environment.GetEnvironmentVariable("COGNITO_CLIENT_SECRET")
    ?? throw new Exception("COGNITO_CLIENT_SECRET no está configurado.");

    public AuthService(IAmazonCognitoIdentityProvider cognito)
    {
        _cognito = cognito;
    }

    public async Task<SignUpResponse> Register(RegisterRequest request)
    {
        var signUpRequest = new SignUpRequest
        {
            ClientId = CLIENT_ID,
            Username = request.Email,
            Password = request.Password,
            SecretHash = CalculateSecretHash(request.Email),

            UserAttributes = new List<AttributeType>
            {
                new AttributeType
                {
                    Name = "name",
                    Value = request.Name
                },

                new AttributeType
                {
                    Name = "phone_number",
                    Value = request.Whatsapp
                }
            }
        };

        return await _cognito.SignUpAsync(signUpRequest);
    }

    public async Task<InitiateAuthResponse> Login(LoginRequest request)
    {
        var authRequest = new InitiateAuthRequest
        {
            ClientId = CLIENT_ID,

            AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,

            AuthParameters = new Dictionary<string, string>
            {
                ["USERNAME"] = request.Username,
                ["PASSWORD"] = request.Password,
                ["SECRET_HASH"] = CalculateSecretHash(request.Username)
            }
        };

        return await _cognito.InitiateAuthAsync(authRequest);
    }

    public async Task ConfirmRegister(ConfirmRegisterRequest request)
    {
        var confirmRequest = new ConfirmSignUpRequest
        {
            ClientId = CLIENT_ID,
            Username = request.Username,
            ConfirmationCode = request.ConfirmationCode,
            SecretHash = CalculateSecretHash(request.Username)
        };

        await _cognito.ConfirmSignUpAsync(confirmRequest);
    }

    

    private string CalculateSecretHash(string username)
    {

        using var hmac = new HMACSHA256(
            Encoding.UTF8.GetBytes(COGNITO_SECRET)
        );

        var hash = hmac.ComputeHash(
            Encoding.UTF8.GetBytes(username + CLIENT_ID)
        );

        return Convert.ToBase64String(hash);
    }
}