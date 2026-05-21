\ *************************************
\ tests for IPv6
\    Filename:      tests.fs
\    Date:          22 apr 2026
\    Updated:       21 may 2026
\    File Version:  1.0
\    MCU:           ESP32
\    Forth:         ESP32forth all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/tests.fs

page ." test in progress..." cr cr

\ *** WiFi Scan ****************************************************************
net-scan

<EOF>

