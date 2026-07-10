[![GitHub release](https://img.shields.io/github/release/assistance-system-labs/omniclean.svg)](https://github.com/assistance-system-labs/omniclean/releases)


# OmniClean PC
OmniClean PC is a free (as in speech) program uninstaller. It excels at removing large amounts of applications with minimal user input. It can clean up leftovers, detect orphaned applications, run uninstallers according to premade lists, and much more! Even though it was made with IT pros in mind, it can be used by anyone with a basic understanding of how applications are installed/uninstalled in Windows.

OmniClean PC is fully compatible with Windows Store Apps, Steam, Windows Features and has special support for many uninstalling systems (NSIS, InnoSetup, Msiexec, and many other). 

OmniClean PC is licensed under Apache 2.0 open source license, and can be used in both private and commercial settings for free and with no obligations, as long as no conditions of the license are broken.

[Read the online documentation](https://htmlpreview.github.io/?https://github.com/assistance-system-labs/omniclean/blob/master/doc/BCU_manual.html) if you have any questions or issues (the help file included with all releases). If you didn't find an answer to your question, feel free to [open a new issue](https://github.com/assistance-system-labs/omniclean/issues/new).

## Download
You can get the latest version from the [releases page](https://github.com/assistance-system-labs/omniclean/releases).

#### Nightly builds
If you want to get the latest features and fixes as soon as they are available, you can download a nightly build from the [actions page](https://github.com/assistance-system-labs/omniclean/actions/workflows/ci.yaml).

## System requirements
- Earliest supported OS: Windows 10
- Requirements: .NET 8 desktop runtime (not needed for portable)

## How can I help?
Please check the [contribution](CONTRIBUTING.md) notes!

## Compiling
Development is done on Visual Studio 2022. The solution should just load and build without doing anything extra, provided necessary VS features are installed.
The installer is compiled with InnoSetup v6.4. To make a release you have to first run the `publish.bat` script.
