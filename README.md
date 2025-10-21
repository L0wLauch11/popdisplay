# PopDisplay - Manage your displays Brightness and Contrast on Windows using the keyboard!

<p align="center">
<img width="680" height="450" alt="demo" src="https://github.com/user-attachments/assets/3f6473d7-b197-4883-bb5d-217b4b08c0bd" />
</p>

https://github.com/user-attachments/assets/f0fefcbe-fd6a-4599-8bfc-49c6daadc753


## Why?
I wanted a less bloated, keyboard oriented alternative to Twinkle Tray.

## Usage
### Installation
1. Install python from the [official website](https://www.python.org/)
2. Download the `.zip` release and extract it somewhere safe.

### Running on Login
You can run the process on login by creating a shortcut of `popdisplay_daemon.exe` and moving it to `Win + R -> 'shell:startup'`.

### Configuring
Copy `config.example.json` to `config.json`. Replace `WINDOWS_MONITOR_ID` with the ID of the monitor shown in the Windows Settings (-1!) you want to change properties for. You can even have multiple monitors adjusted in one config entry by e. g. declaring `"monitors"`->`"0"` and `"monitors"`->`"1"` respectively.

### Running
Finally, run `popdisplay_daemon.exe` which by default opens the GUI on `Shift+Alt+D`. Right now, the only way to modify this is by recompiling the `.ahk` file.
