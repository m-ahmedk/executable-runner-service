# Batch and Executable Automation Service
The Batch and Executable Automation Service is a .NET Core application that automates the process of running a batch file and an executable file. The service runs the batch file first, then executes the associated executable file. This automation process is useful when the batch file is necessary to prepare the environment for the executable file.

## Features
- Automates the process of running a batch file and an executable file.
- Easy to integrate with existing .NET Core applications.
- Supports running the service as a Windows service.

## Getting Started

### Prerequisites
.NET Core SDK 3.1 or later

### Installation
1. Clone the repository: git clone https://github.com/m-ahmedk/executable-runner-service.git
2. Navigate to the project directory: cd ExecutableRunnerService
3. Build the project: dotnet build
4. Publish the project: dotnet publish --configuration Release --self-contained --runtime win-x64 --output D:\ExecutableRunnerService\publish
5. Create a Windows service from the published executable using PowerShell or a tool of your choice.

### Configuration
The file includes the following configuration options:

ExecutableFilePath: The path to the executable file that should be executed after the batch file.

### Usage
- Start the service by running the executable file.
- The service will run the batch file and then execute the associated executable file.
- The service can be stopped by pressing Ctrl + C in the command prompt.

## License
The Batch and Executable Automation Service is licensed under the MIT License. See the [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/m-ahmedk/executable-runner-service/blob/main/LICENSE) for more information.

## Support
If you have any questions or issues, please contact m.ahmedk287@gmail.com.