<h2>This is a small, usable PS1 emulator developed entirely in C#.</h2>

! [License](https://img.shields.io/badge/license-MIT-blue) ! [GitHub Release](https://img.shields.io/github/v/release/unknowall/ScePSX?label=Release) ! [Language](https://img.shields.io/github/languages/top/unknowall/ScePSX) ! [Build Status](https://img.shields.io/badge/build-passing-brightgreen) [! [Gitee Repo](https://img.shields.io/badge/Gitee-Mirror-FFB71B)](https://gitee.com/unknowall/ScePSX)
## Main features 🎮
- **Instant Archive/Read Archive**: Save and load game progress at any time.
- **Multi-Renderer Support**: Dynamically switch between D2D, D3D, OpenGL, and Vulkan renderers for different hardware configurations.
- **ReShade Integration**: D3D, OpenGL, Vulkan support ReShade post-processing effects to enhance image quality.
- **Resolution Adjustment**: Customize internal resolution (e.g. 2x, 4x) to enhance visual experience.
- **Memory Tools**: Provides memory editing and search functions for advanced users to modify game behavior.
- **Gold Finger Support**: Enable cheat function to unlock hidden content or adjust game difficulty.
- **Network Battle**: Support online battle, relive the fun of the classic game.
- **Archive Management**: Conveniently manage multiple game archives.

<b>The english version is available starting from Beta 0.1.0.</b>.

**The project has been synchronized to Gitee, giving domestic users priority access to accelerate downloads. Mirror repositories are automatically synchronized to ensure consistent content**.

## Performance 🚀

| Render Mode | Memory Usage | Recommended Hardware |
|----------|----------|----------|
| D2D | ~32MB | Older Machines |
| D3D | ~52MB | Older Machines |
| OpenGL | ~86MB | Modern Devices |
| Vulkan | ~120MB | Modern Devices |

> **Smooth Running Test**: Smooth running at 60 FPS on Intel Celeron i3 3215u.
*No gamedb, no reshade.

! [capture1](https://github.com/user-attachments/assets/27f7ac35-f296-4bdc-9164-498ea4342314)
! [capture](https://github.com/user-attachments/assets/88c1f283-127c-4f74-9cbe-7e64def43962)

### How to use 🛠️

#### 1. Setting up the BIOS 🔑
> **Note**: Due to legal restrictions, the emulator does not come with a BIOS file, so please obtain a legal BIOS yourself.
- For example, extract the BIOS file from your PlayStation console (e.g. SCPH1001.BIN)
- Place the file in the `bios` folder of the emulator:
- /ScePSx
- ├─ bios/ │ └─ SCPH1001.BIN
- │ └── SCPH1001.bin
- ├─ saves/ └─ ScePSx
- └── ScePSX.exe

#### 2. Using ReShade 🎨
- ReShade is available in OpenGL and Vulkan rendering modes.
- D3D requires additional reShade installation.
- Press **Home** to open the ReShade Settings screen.
- Preset shader files (located in `ReShade/` folder) can be loaded.
  
#### 3. Multi-Disc Games 📀
- **Memory Card 1**: Each disc is used independently.
- **Memory Card 2**: Common for all discs, recommended for multi-disc games.
  
#### 4. Control Settings ⌨️🎮
- Keyboard setup is done in the File menu.
- The joystick requires no additional setup and is plug and play.


  
## Frequently Asked Questions ❓

### Q: Why can't I start the game?
A: Please make sure:
1. the BIOS file has been set up correctly.
2. the game image is in the correct format (e.g. `.bin/.cue` or `.img/.cue` or `.iso`).

### Q: How do I get more ReShade Shaders?
A: Visit the [official ReShade website](https://reshade.me/) to download the shader files and place them in the `reshade/` folder.
- /ScePSx
- ├─ reshade/
- │ └── Put it here
- ├── saves/
- └── ScePSX.exe

### Q: What games are supported by the emulator?
A: Most of the common games are supported.

### Q: What should I do if my CPU usage is high?
A: If the CPU usage is too high, we recommend using a D2D renderer or lowering the internal resolution.

### Q: Does it support cross-platform?
A: Currently only Windows is supported, in the future we plan to implement Linux/macOS support through .NET MAUI or Avalonia.



### How to compile
1. The project is in the .net 8.0 framework.
2. SDL declaration file is already included in the code, put the SDL2 DLL into the generated directory.
3. OpenGL can install OpenGL.NET NuGet package (.net 4.7 framework, there are compatibility issues), or manually add dependencies to use OpenGL.dll (.net 8.0 compilation)
4. Use the vk NuGet package for Vulkan, or manually add a dependency to use vk.dll.
5. If you are using a framework lower than .net 8.0, you can manually modify the project files.
6. Core part of the code is based on https://github.com/BluestormDNA/ProjectPSX
   
**Feedback**: Submit an issue on the [Issues](https://github.com/unknowall/ScePSX/issues) page.

# Downloads 📥.

- **Light version (1.42 MB)**: Includes only core functionality, good for a quick experience.
- **Full Version (7.81 MB)**: Includes all features (e.g. ReShade integration).
- **GameDB Database**: Optional download that automatically recognizes and loads game configurations.
- > **Note**: Due to legal restrictions, the emulator does not come with a BIOS file, so please get your own legal BIOS.

[Click here to download the latest version](https://github.com/unknowall/ScePSX/releases)
