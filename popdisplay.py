import time
import json
import argparse

from monitorcontrol import get_monitors


if __name__ != '__main__':
    exit

monitors = get_monitors()
config_file_path = 'config.json'

def monitor_force_contrast(monitor_id: int, contrast: int):
    monitor = monitors[monitor_id]
    with monitor:
        while True:
            try:
                monitor.set_contrast(contrast)
                if monitor.get_contrast() == contrast:
                    print(f'Contrast set to {contrast} successfully!')
                    return
            except:
                pass

            time.sleep(0.1)

def monitor_force_brightness(monitor_id: int, brightness: int):
    monitor = monitors[monitor_id]
    with monitor:
        while True:
            try:
                monitor.set_luminance(brightness)
                if monitor.get_luminance() == brightness:
                    print(f'Brightness set to {brightness} successfully!')
                    return
            except:
                pass

            time.sleep(0.1)

parser = argparse.ArgumentParser()
parser.add_argument('-j', '--json')
parser.add_argument('-b', '--brightness')
parser.add_argument('-c', '--contrast')
parser.add_argument('-m', '--monitor_index')
args = parser.parse_args()

if args.json == None:
    # CLI Mode
    if args.monitor_index == None:
        print('No monitor index (--monitor_index/ -m) supplied!')
        exit

    if args.brightness != None:
        monitor_force_brightness(int(args.monitor_index), int(args.brightness))

    if args.contrast != None:
        monitor_force_contrast(int(args.monitor_index), int(args.contrast))
else:
    # JSON config mode
    try:
        with open(config_file_path, 'r') as json_string:
            config = json.load(json_string)
    except:
        print('config.json could not be read')
        exit

    chosen_configuration = config[args.json]
    print(chosen_configuration)
    configured_monitors = chosen_configuration['monitors']
    for configured_monitor_id in configured_monitors:
        configured_monitor = configured_monitors[configured_monitor_id]
        monitor_force_brightness(int(configured_monitor_id), int(configured_monitor['brightness']))
        monitor_force_contrast(int(configured_monitor_id), int(configured_monitor['contrast']))