\ *************************************
\ wifi congig
\    Filename:      config.fs
\    Date:          23 apr 2026
\    Updated:       23 apr 2026
\    File Version:  1.0
\    MCU:           ESP32
\    Forth:         ESP32forth all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/config.fs

\ router parameters
z" Livebox-1390L"      constant WIFI_SSID
z" z4S3RuPgdopjekrNQC" constant WIFI_PSWD


<EOF>
