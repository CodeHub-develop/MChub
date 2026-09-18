using System.Text.Json.Serialization;

namespace MChub.Bedrock.Xbox;

public sealed class XboxSisuResponse
{
	[JsonPropertyName("AuthorizationToken")]
	public XboxTokenResponse AuthorizationToken { get; init; } = new XboxTokenResponse();
}
