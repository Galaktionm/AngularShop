using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Services {
    public class UserSerializer : JsonConverter<User>
    {
        public override User? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, User user, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("username", user.UserName);
            writer.WriteString("email", user.Email);
            writer.WriteEndObject();


        }
    }
}
