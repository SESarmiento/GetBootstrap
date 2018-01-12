# GetBootstrap

This project created to ease the customization of CSharp Console Application and provide usefull adds-on that can help devs to their current and future console projects.

[![Master build status](https://ci.appveyor.com/api/projects/status/btq8youx0uc1lnxj/branch/master?svg=true&passingText=master%20•%20pass&failingText=master%20•%20fail&pendingText=master%20•%20pending)](https://ci.appveyor.com/project/devlsarmiento/getbootstrap/branch/master)
[![Pre-Master build status](https://ci.appveyor.com/api/projects/status/btq8youx0uc1lnxj/branch/pre-master?svg=true&passingText=pre-master%20•%20pass&failingText=pre-master%20•%20fail&pendingText=pre-master%20•%20pending)](https://ci.appveyor.com/project/devlsarmiento/getbootstrap/branch/pre-master)
[![Code-Integration build status](https://ci.appveyor.com/api/projects/status/btq8youx0uc1lnxj/branch/code-integration?svg=true&passingText=code-integration%20•%20pass&failingText=code-integration%20•%20fail&pendingText=code-integration%20•%20pending)](https://ci.appveyor.com/project/devlsarmiento/getbootstrap/branch/code-integration)

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

This project requires the following env:

```
.Net Framework 4.6 or greater
```

### Installing

```
Download the GetBootstrap and add it as reference in your Console Application
```

### Features

##### Customized Console Writer

```csharp
foreach(var name in Enum.GetNames(typeof(BootstrapType))) {
	Bootstrap.WriteLine($ "BOOTSTRAPER", style: BootsrapStyle.Text, type: (BootstrapType) Enum.Parse(typeof(BootstrapType), name));
	Bootstrap.WriteLine($ "BOOTSTRAPER", style: BootsrapStyle.Alert, type: (BootstrapType) Enum.Parse(typeof(BootstrapType), name), fill: true);
}
```

##### Console Typewriter

```csharp
foreach(var name in Enum.GetNames(typeof(BootstrapType))) {
	Typewriter.WriteLine($ "BOOTSTRAPER", style: BootsrapStyle.Text, type: (BootstrapType) Enum.Parse(typeof(BootstrapType), name));
	Typewriter.WriteLine($ "BOOTSTRAPER", style: BootsrapStyle.Alert, type: (BootstrapType) Enum.Parse(typeof(BootstrapType), name), fill: true);
}
```

##### Console ProgressBar

```csharp
ProgressBar probar = new ProgressBar() {
	Width = 100,
	Maximum = 100,
	ProgressColor = ConsoleColor.DarkCyan
};

for (int i = 0; i < probar.Maximum; i++) {
	probar.Increment();
	Bootstrap.Write($ "{i}");
	Thread.Sleep(100);
}
```

## Built With

* [Visual Studio 2017](https://www.visualstudio.com/downloads/) - The IDE used

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/devlsarmiento/GetBootstrap/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/devlsarmiento/GetBootstrap/tags). 

## Authors

* **Leonel Sarmiento** - *Initial work* - [devlsarmiento](https://github.com/devlsarmiento)

See also the list of [contributors](https://github.com/devlsarmiento/GetBootstrap/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/devlsarmiento/GetBootstrap/LICENSE) file for details

## Acknowledgments

* [CodeReview](https://codereview.stackexchange.com/search?q=Console+Application+Customization) - Forum that help me review my codes.
* [StackOverflow](https://stackoverflow.com/) - This forum help me alot.
* [GetBootstrap](https://getbootstrap.com/) - My favorite open source toolkit for web.
