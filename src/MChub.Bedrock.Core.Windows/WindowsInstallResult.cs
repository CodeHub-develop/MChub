using Windows.Management.Deployment;

namespace MChub.Bedrock.Core.Windows;

public class WindowsInstallResult : InstallResult
{
	public DeploymentResult? DeploymentResult { get; set; }
}
