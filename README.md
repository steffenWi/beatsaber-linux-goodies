# Beat Saber Linux Goodies

# Install Method 1: QBeat
QBeat is currently under development still but is functional enough to get things working. 
If you'd prefer a GUI for installing mods then see method 2 instead.

QBeat can be used to setup wine/proton, download mods, and patch beat saber in a relatively easy manner.
The scripts from method 2 are included with QBeat and will continue to be maintained for use with other mod installers.

QBeat releases: [Github release page](https://github.com/geefr/beatsaber-linux-goodies/releases) 
QBeat Docs:  [See Here, scroll down](https://github.com/geefr/beatsaber-linux-goodies/tree/QBeat/QBeat)

# Install Method 2: Beatdrop + script hacks
Beatdrop can also be used for mod installation, there's a work in progress port for Linux.

This is close to complete but I don't think I'll be finishing the port. If you're good with electron/node.js and want to help it shouldn't be too difficult. Going forward I plan to maintain QBeat instead, fresh start and a more familiar language.

[My BeatDrop Fork](https://github.com/geefr/BeatDrop/releases). This is a Linux port of BeatDrop with a few tweaks here and there.

In addition to the mod downloads you'll need to patch the game correctly, see the [scripts directory](scripts/README.md) for instructions/further detail.


# What
Mod installation scripts and other goodies for running Beat Saber on Linux.

This repository is mainly for gathering information, and implementations of scripts/etc that aren't tied to any one tool.

The eventual target is to update existing modding tools to work on Linux directly, and allow 1-click installs for Beat Saber mods.

# Why
Beat Saber itself has run perfectly on Linux for quite some time, yet mod installation remains difficult.

There are some folks that want to use their Linux boxes for BS, however can't live without mods.

# How
- Research and gather information in this repo for the power users.
- Work on integrating the lower level scripts/etc into popular modding tools for folks that don't want to open the terminal or do things manually.

# Bugs/Support
If you're having issues on Linux it's probably best if you don't pester the BeatDrop/ModAssistant/Mod devs directly for now.
Raising a ticket here is probably a better plan, and will keep the Linux-specific hacks in one place.
