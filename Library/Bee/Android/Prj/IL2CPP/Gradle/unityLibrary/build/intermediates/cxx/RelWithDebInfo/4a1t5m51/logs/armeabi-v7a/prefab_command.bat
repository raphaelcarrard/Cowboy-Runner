@echo off
"E:\\Unity\\Hub\\Editor\\2023.2.11f1\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\OpenJDK\\bin\\java" ^
  --class-path ^
  "C:\\Users\\rapha\\.gradle\\caches\\modules-2\\files-2.1\\com.google.prefab\\cli\\2.0.0\\f2702b5ca13df54e3ca92f29d6b403fb6285d8df\\cli-2.0.0-all.jar" ^
  com.google.prefab.cli.AppKt ^
  --build-system ^
  cmake ^
  --platform ^
  android ^
  --abi ^
  armeabi-v7a ^
  --os-version ^
  23 ^
  --stl ^
  c++_shared ^
  --ndk-version ^
  23 ^
  --output ^
  "E:\\My Games\\Cowboy Runner\\.utmp\\RelWithDebInfo\\4a1t5m51\\prefab\\armeabi-v7a\\prefab-configure" ^
  "C:\\Users\\rapha\\.gradle\\caches\\transforms-3\\6c263f9b274272e8756b525bc7d98ffe\\transformed\\jetified-games-activity-2.0.2\\prefab"
